using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DeserializationHelper
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public static bool ValidateInput(string data)
        {
            if (!String.IsNullOrEmpty(data))
            {
                if (data.IndexOf('&') > -1 ||
                    data.IndexOf('|') > -1)
                    return false;
            }
            return true;
        }
        public static string executeCommand(string filename, string commandlineArgument, bool base64 = false)
        {
            string Output = string.Empty;

            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();

            //strCommand is path and file name of command to run
            pProcess.StartInfo.FileName = filename;

            //strCommandParameters are parameters to pass to program
            pProcess.StartInfo.Arguments = commandlineArgument;

            pProcess.StartInfo.UseShellExecute = false;

            //Set output of program to be written to process output stream
            pProcess.StartInfo.RedirectStandardOutput = true;

            //Start the process
            pProcess.Start();

            if (base64)
            {
                using (var ms = new MemoryStream())
                {
                    pProcess.StandardOutput.BaseStream.CopyTo(ms);
                    Output = System.Convert.ToBase64String(ms.ToArray());
                } 
            }
            else
            {
                Output = pProcess.StandardOutput.ReadToEnd();
            }

            //Wait for process to finish
            pProcess.WaitForExit();

            return Output;
        }
    }
}
