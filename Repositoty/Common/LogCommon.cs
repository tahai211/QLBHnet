
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace Repository.Common
{
    public class LogCommon
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LogCommon()
        {
            //BasicConfigurator.Configure();
            //XmlConfigurator.Configure(null);
        }

        public static void WriteLogInfo(string msg)
        {
            _logger.Info(msg);
            //write(msg);
            // WriteError(msg);
        }

        public static void WriteLogError(object msg)
        {
            _logger.Error(msg);
            //write(msg);
            // WriteError(msg);
        }

        public static void WriteLogFatal(string msg)
        {
            _logger.Fatal(msg);
        }

        public static void WriteLogDebug(string msg)
        {
            _logger.Debug(msg);
        }

        public static void WriteLogWarning(string msg)
        {
            _logger.Warn(msg);
        }
        public static string PhysicalPath;

        public static void write(object log)
        {
            //log
            try
            {
                var GetDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "npc_api");
                if (!Directory.Exists(Path.Combine(GetDirectory, "logs"))) Directory.CreateDirectory(Path.Combine(GetDirectory, "logs"));

                StreamWriter sr;
                string[] realDirectory = { GetDirectory, "logs", DateTime.Now.ToShortDateString().Replace("/", "-") };
                if (File.Exists(Path.Combine(realDirectory) + ".log"))
                    sr = File.AppendText(Path.Combine(realDirectory) + ".log");
                else
                {
                    sr = File.CreateText(Path.Combine(realDirectory) + ".log");
                }
                sr.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ") + log);
                sr.Flush();
                sr.Close();
            }
            catch
            {
                // write(log);
            }
        }
        public static void WriteError(string errorMessage)
        {
            try
            {
                string folder = "Log"; //ConfigurationCommon.GetValueKeyAppSetting("fileLog:value");
                string path = folder + DateTime.Today.ToString("dd-MM-yy") + ".log";
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                using (StreamWriter w = File.AppendText(path))
                {
                    w.WriteLine("\r\nLog Entry : ");
                    w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    string err = "Error Message:" + errorMessage;
                    w.WriteLine(err);
                    w.WriteLine("__________________________");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }
        }

        public static void WriteError(string errorMessage, string FunctionName)
        {
            try
            {
                string path = "Log"; // ConfigurationCommon.GetValueKeyAppSetting("fileLog:value") + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                using (StreamWriter w = File.AppendText(path))
                {
                    w.WriteLine("\r\nLog Entry : ");
                    w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    string err = " Function: " + FunctionName +
                                  ". Error Message:" + errorMessage;
                    w.WriteLine(err);
                    w.WriteLine("__________________________");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }
        }
    }
}
