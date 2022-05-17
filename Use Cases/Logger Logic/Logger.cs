using Models.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Use_Cases.Logger_Logic
{
    public class Logger : ILogger
    {
        private static string loggerPath = FileSettings.Default.LoggerSettings;

        public void WriteLogger(string type, string message)
        {
            using (FileStream fileStream = new FileStream(loggerPath, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine($"{type}: {message} | {DateTime.Now}");
                    streamWriter.WriteLine("___________________________________________________________________________________________");
                    fileStream.Flush();
                }
            }
        }
    }
}
