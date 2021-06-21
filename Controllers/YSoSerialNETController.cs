using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerializedPayloadGenerator.Models;

namespace SerializedPayloadGenerator.Controllers
{
    public class YSoSerialNETController : Controller
    {
        private static string strAppDataPath = Path.Combine(HttpRuntime.AppDomainAppPath, "Resource");
        private static string strYSoSerialNetPath = String.Format(@"{0}\ysoserialnet\ysoserial.exe", strAppDataPath);

        // GET: YSoSerialJava
        public ActionResult Index(YSoSerialNET ySoSerialNET)
        {
            if (TempData.ContainsKey("ySoSerialNET"))
            {
                ySoSerialNET = (YSoSerialNET)TempData["ySoSerialNET"];
            }
            return View(ySoSerialNET);
        }

        public bool ValidateParams(YSoSerialNET ySoSerialNET)
        {
            if (MvcApplication.ValidateInput(ySoSerialNET.appPath) &&
                MvcApplication.ValidateInput(ySoSerialNET.command) &&
                MvcApplication.ValidateInput(ySoSerialNET.decryptionAlgo.ToString()) &&
                MvcApplication.ValidateInput(ySoSerialNET.decryptionKey) &&
                MvcApplication.ValidateInput(ySoSerialNET.ecnrypted.ToString()) &&
                MvcApplication.ValidateInput(ySoSerialNET.file) &&
                MvcApplication.ValidateInput(ySoSerialNET.format) &&
                MvcApplication.ValidateInput(ySoSerialNET.formatter.ToString()) &&
                MvcApplication.ValidateInput(ySoSerialNET.gadget.ToString()) &&
                MvcApplication.ValidateInput(ySoSerialNET.generator) &&
                MvcApplication.ValidateInput(ySoSerialNET.legacy.ToString()) &&
                MvcApplication.ValidateInput(ySoSerialNET.minify.ToString()) &&
                MvcApplication.ValidateInput(ySoSerialNET.mode) &&
                MvcApplication.ValidateInput(ySoSerialNET.output.ToString()) &&
                MvcApplication.ValidateInput(ySoSerialNET.path) &&
                MvcApplication.ValidateInput(ySoSerialNET.payload) &&
                MvcApplication.ValidateInput(ySoSerialNET.plugin.ToString()) &&
                MvcApplication.ValidateInput(ySoSerialNET.useSimpleType.ToString()) &&
                MvcApplication.ValidateInput(ySoSerialNET.validationAlgo.ToString()) &&
                MvcApplication.ValidateInput(ySoSerialNET.validationKey) &&
                MvcApplication.ValidateInput(ySoSerialNET.viewStateUserKey) &&
                MvcApplication.ValidateInput(ySoSerialNET.ysoserialNetCommand))
            {
                return true;
            }
            return false;
        }

        public String GenerateCommand(YSoSerialNET ySoSerialNET)
        {
            String strYSoSerialNETCommand = string.Empty;
            if (ValidateParams(ySoSerialNET))
            {
                String strPlugin = ySoSerialNET.plugin.ToString();
                if (strPlugin == "ViewState")
                {
                    strYSoSerialNETCommand = String.Format(" -p {0} -g {1} {2} {3} -c \"{4}\" {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}", 
                        strPlugin,
                        ySoSerialNET.gadget.ToString(),
                        ySoSerialNET.legacy == BoolType.True ? "--islegecy" : "",
                        ySoSerialNET.ecnrypted == BoolType.True ? "--isencrypted" : "",
                        ySoSerialNET.command,
                        String.IsNullOrEmpty(ySoSerialNET.path) ? "": "--path="+ ySoSerialNET.path,
                        String.IsNullOrEmpty(ySoSerialNET.appPath) ? "" : "--apppath=" + ySoSerialNET.appPath,
                        String.IsNullOrEmpty(ySoSerialNET.generator) ? "" : "--generator=" + ySoSerialNET.generator,
                        String.IsNullOrEmpty(ySoSerialNET.viewStateUserKey) ? "" : "--viewstateuserkey=" + ySoSerialNET.generator,
                        String.IsNullOrEmpty(ySoSerialNET.decryptionAlgo.ToString()) ? "" : "--decryptionalg=" + ySoSerialNET.decryptionAlgo.ToString(),
                        String.IsNullOrEmpty(ySoSerialNET.decryptionKey) ? "" : "--decryptionkey=" + ySoSerialNET.decryptionKey,
                        String.IsNullOrEmpty(ySoSerialNET.validationAlgo.ToString()) ? "" : "--validationalg=" + ySoSerialNET.validationAlgo.ToString(),
                        String.IsNullOrEmpty(ySoSerialNET.validationKey) ? "" : "--validationkey=" + ySoSerialNET.validationKey,
                        ySoSerialNET.minify == BoolType.True ? "--minify" : "",
                        ySoSerialNET.useSimpleType == BoolType.True ? "--usesimpletype" : "");
                }
                else
                {
                    strYSoSerialNETCommand = String.Format("{0} -g {1} -f {2} -c \"{3}\" {4} {5} {6} {7} {8}",
                        strPlugin == "Generic" ? "" : " -p " + strPlugin,
                        ySoSerialNET.gadget.ToString(),
                        ySoSerialNET.formatter.ToString(),
                        ySoSerialNET.command,
                        ySoSerialNET.minify == BoolType.True ? "--minify" : "",
                        ySoSerialNET.useSimpleType == BoolType.True ? "--usesimpletype" : "",
                        String.IsNullOrEmpty(ySoSerialNET.file) ? "" : "--file=" + ySoSerialNET.file,
                        String.IsNullOrEmpty(ySoSerialNET.format) ? "" : "--format=" + ySoSerialNET.format,
                        String.IsNullOrEmpty(ySoSerialNET.mode) ? "" : "--mode=" + ySoSerialNET.mode);
                }
            }
            else
            {
                strYSoSerialNETCommand = "Validation Failed";
            }
            return strYSoSerialNETCommand;
        }

        [HttpPost]
        public ActionResult Generate(YSoSerialNET ySoSerialNET)
        {
            if (ValidateParams(ySoSerialNET))
            {
                string strYSoSerialNetCommand = GenerateCommand(ySoSerialNET);
                string strCommandOutput = MvcApplication.executeCommand(strYSoSerialNetPath, strYSoSerialNetCommand);
                ySoSerialNET.payload = strCommandOutput;
                ySoSerialNET.ysoserialNetCommand = String.Format("ysoserial.exe {0}", strYSoSerialNetCommand);
                TempData["ySoSerialNET"] = ySoSerialNET;
            }
            else
            {
                ySoSerialNET.ysoserialNetCommand = "Invalid options: '&' and '|' not allowed";
                TempData["ySoSerialNET"] = ySoSerialNET;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CommandHelp(string plugin)
        {
            string strYSoSerialNetCommand = string.Empty;
            if (plugin == "Generic")
                strYSoSerialNetCommand = string.Format(" --help ", plugin);
            else
                strYSoSerialNetCommand = string.Format(" -p {0} --help ", plugin);
            string strCommandOutput = HttpUtility.HtmlEncode(MvcApplication.executeCommand(strYSoSerialNetPath, strYSoSerialNetCommand));
            return Json(strCommandOutput, JsonRequestBehavior.AllowGet);
        }
    }
}