using DeserializationHelper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeserializationHelper.Controllers
{
    public class PythonController : Controller
    {
        private static string strAppDataPath = Path.Combine(HttpRuntime.AppDomainAppPath, "Resource");
        private static string strPythonPath = String.Format(@"{0}\python\python.exe", strAppDataPath);
        private static string strPyPickleFile = String.Format(@"{0}\python_support\pickle_deser.py", strAppDataPath);
        private static string strPyPickleDictFile = String.Format(@"{0}\python_support\pickle_deser_dict.py", strAppDataPath);

        // GET: Python
        public ActionResult Index(Python python)
        {
            if (TempData.ContainsKey("pickle"))
            {
                python = (Python)TempData["pickle"];
            }
            return View(python);
        }

        public bool ValidateParams(Python python)
        {
            if (MvcApplication.ValidateInput(python.command) &&
                MvcApplication.ValidateInput(python.payload) &&
                MvcApplication.ValidateInput(python.output.ToString()) &&
                MvcApplication.ValidateInput(python.type.ToString()))
            {
                return true;
            }
            return false;
        }

        private ActionResult SendYAMLFile(Python python)
        {
            string strFileName = "exploit.yaml";
            string srtFilePath = String.Format(@"{0}\python\{1}", strAppDataPath, strFileName);

            string srtTempFilePath = String.Format(@"{0}\TempFiles\{1}_{2}", strAppDataPath, strFileName, (new Random()).Next(1, 1000));
            string text = System.IO.File.ReadAllText(srtFilePath);
            text = text.Replace("$COMMAND$", python.command);
            System.IO.File.WriteAllText(srtTempFilePath, text);

            byte[] byteFileData = System.IO.File.ReadAllBytes(srtTempFilePath);
            string strContentType = MimeMapping.GetMimeMapping(srtFilePath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = strFileName,
                Inline = true,
            };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            System.IO.File.Delete(srtTempFilePath);
            return File(byteFileData, strContentType);
        }

        private ActionResult SendDictinoryFile(Python python, string srtFilePath)
        {
            byte[] byteFileData = System.IO.File.ReadAllBytes(srtFilePath);
            string strContentType = MimeMapping.GetMimeMapping(srtFilePath);
            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "PickleDict.bin",
                Inline = true,
            };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            System.IO.File.Delete(srtFilePath);
            return File(byteFileData, strContentType);
        }

        [HttpPost]
        public ActionResult Generate(Python python)
        {
            if (python.type == PyDeserType.Pickle)
            {
                if (ValidateParams(python))
                {
                    if (python.output == PythonOutput.Base64)
                    {
                        string strPickleCommand = string.Format("{0} \"{1}\"", strPyPickleFile, python.command);
                        string strCommandOutput = MvcApplication.executeCommand(strPythonPath, strPickleCommand);
                        try
                        {
                            python.payload = strCommandOutput.Substring(2, strCommandOutput.Length - 5);
                        }
                        catch (Exception e)
                        {
                            python.payload = e.Message;
                        }
                        TempData["pickle"] = python;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        string strTempFilePath = String.Format(@"{0}\TempFiles\PythonDict_{1}.bin", strAppDataPath, (new Random()).Next(1, 1000));
                        string strPickleCommand = string.Format("{0} \"{1}\" \"{2}\"", strPyPickleDictFile, python.command, strTempFilePath);
                        MvcApplication.executeCommand(strPythonPath, strPickleCommand);
                        if (System.IO.File.Exists(strTempFilePath))
                        {
                            return SendDictinoryFile(python, strTempFilePath);
                        }
                        else
                        {
                            python.payload = "Failed to Generate Dictionary payload";
                            TempData["pickle"] = python;
                            return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    python.payload = "Invalid options: '&' and '|' not allowed";
                    TempData["pickle"] = python;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return SendYAMLFile(python);
            }
        }
    }
}