using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeserializationHelper.Models;

namespace DeserializationHelper.Controllers
{
    public class YSoSerialJavaController : Controller
    {
        private static string strAppDataPath = Path.Combine(HttpRuntime.AppDomainAppPath, "Resource");
        private static string strJavaPath = String.Format(@"{0}\java\bin\java.exe", strAppDataPath);
        private static string strYSoSerialJarPath = String.Format(@"{0}\ysoserial.jar", strAppDataPath);

        // GET: YSoSerialJava
        public ActionResult Index(YSoSerialJava ySoSerialJava)
        {
            if (TempData.ContainsKey("ySoSerialJava"))
            {
                ySoSerialJava = (YSoSerialJava)TempData["ySoSerialJava"];
            }
            return View(ySoSerialJava);
        }

        public bool ValidateParams(YSoSerialJava ySoSerialJava)
        {
            if (MvcApplication.ValidateInput(ySoSerialJava.command) &&
                MvcApplication.ValidateInput(ySoSerialJava.gadget.ToString()) &&
                MvcApplication.ValidateInput(ySoSerialJava.output.ToString()) &&
                MvcApplication.ValidateInput(ySoSerialJava.payload))
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        public ActionResult Generate(YSoSerialJava ySoSerialJava)
        {
            if(ValidateParams(ySoSerialJava))
            {
                string strYSoSerialCommand = string.Format("-jar {0} {1} \"{2}\"", strYSoSerialJarPath, ySoSerialJava.gadget.ToString(), ySoSerialJava.command);
                string strCommandOutput = MvcApplication.executeCommand(strJavaPath, strYSoSerialCommand, ySoSerialJava.output == JavaOutput.Base64 ? true : false);
                ySoSerialJava.payload = strCommandOutput;
                ySoSerialJava.ysoserialCommand = String.Format("java -jar ysoserial.jar {0} '{1}'", ySoSerialJava.gadget.ToString(), ySoSerialJava.command);
                TempData["ySoSerialJava"] = ySoSerialJava;
            }
            else
            {
                ySoSerialJava.ysoserialCommand = "Invalid options: '&' and '|' not allowed";
                TempData["ySoSerialJava"] = ySoSerialJava;
            }
            return RedirectToAction("Index");
        }
    }
}