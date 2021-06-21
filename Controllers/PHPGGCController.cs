using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerializedPayloadGenerator.Models;

namespace SerializedPayloadGenerator.Controllers
{
    public class PHPGGCController : Controller
    {
        private static string strAppDataPath = Path.Combine(HttpRuntime.AppDomainAppPath, "Resource");
        private static string strPHPPath = String.Format(@"{0}\php\php.exe", strAppDataPath);
        private static string strPhpGGCPath = String.Format(@"{0}\phpggc\phpggc-master\phpggc", strAppDataPath);

        // GET: PHPGGC
        public ActionResult Index(PhpGGC phpggc)
        {
            if (TempData.ContainsKey("phpggc"))
            {
                phpggc = (PhpGGC)TempData["phpggc"];
            }
            return View(phpggc);
        }

        public string SelectEncoding(Encoding encType)
        {
            if (encType == Encoding.Base64Output)
                return " --base64 ";
            else if (encType == Encoding.SoftURLEncode)
                return " --soft ";
            else if (encType == Encoding.URLEncode)
                return " --url ";
            else if (encType == Encoding.JsonOutput)
                return " --json ";
            else
                return " ";
        }

        public bool ValidateParams(PhpGGC phpggc)
        {
            if (MvcApplication.ValidateInput(phpggc.encoding.ToString()) &&
               MvcApplication.ValidateInput(phpggc.enhancement.ToString()) &&
               MvcApplication.ValidateInput(phpggc.functionName) &&
               MvcApplication.ValidateInput(phpggc.functionParameter) &&
               MvcApplication.ValidateInput(phpggc.gadget.ToString()) &&
               MvcApplication.ValidateInput(phpggc.outputType.ToString()) &&
               MvcApplication.ValidateInput(phpggc.payload) &&
               MvcApplication.ValidateInput(phpggc.phar.ToString()))
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        public ActionResult Generate(PhpGGC phpggc)
        {
            if (ValidateParams(phpggc))
            {
                string strPhpGGCCommand = string.Empty;
                if (phpggc.outputType == OutputType.Console)
                {
                    strPhpGGCCommand = string.Format(" {0} {1} {2}{3}", phpggc.gadget.ToString().Replace("_", "/"), phpggc.functionName, phpggc.functionParameter, SelectEncoding(phpggc.encoding));
                    phpggc.phpggcCommand = String.Format("phpggc {0}", strPhpGGCCommand);
                    string strCommandOutput = MvcApplication.executeCommand(strPHPPath, strPhpGGCPath + strPhpGGCCommand);
                    phpggc.payload = strCommandOutput;
                    TempData["phpggc"] = phpggc;
                }
                else
                {
                    string strTempFilePath = String.Format(@"{0}\TempFiles\phpggc_{1}.txt", strAppDataPath, (new Random()).Next(1, 1000));
                    strPhpGGCCommand = string.Format(" {0} {1} {2}{3}--output {4}", phpggc.gadget.ToString().Replace("_", "/"), phpggc.functionName, phpggc.functionParameter, SelectEncoding(phpggc.encoding), strTempFilePath);
                    MvcApplication.executeCommand(strPHPPath, strPhpGGCPath + strPhpGGCCommand);
                    strPhpGGCCommand = string.Format(" {0} {1} {2} --output file.txt", phpggc.gadget.ToString().Replace("_", "/"), phpggc.functionName, phpggc.functionParameter);
                    phpggc.phpggcCommand = String.Format("phpggc {0}", strPhpGGCCommand);

                    byte[] byteFileData = System.IO.File.ReadAllBytes(strTempFilePath);
                    string strContentType = MimeMapping.GetMimeMapping(strTempFilePath);

                    var cd = new System.Net.Mime.ContentDisposition
                    {
                        FileName = "payload.txt",
                        Inline = true,
                    };
                    Response.AppendHeader("Content-Disposition", cd.ToString());
                    System.IO.File.Delete(strTempFilePath);
                    return File(byteFileData, strContentType);
                }

            }
            else
            {
                phpggc.phpggcCommand = "Invalid options: '&' and '|' not allowed";
                TempData["phpggc"] = phpggc;
            }
            return RedirectToAction("Index");
        }
    }
}