using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCardLib
{
    public static class Logger
    {
        public static void WriteLog(string msg)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];

            using(StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine(msg);
            }
        }
    }
}
