using System.Configuration;

namespace Sp_Runner
{

    internal class Utilities
    {
        private const string logLine = "--------------------------------------------------------";

        public static void printMessage(string msg)
        {
            string timeMsg = GetCurrentTime() + " " + msg;
            Console.WriteLine(timeMsg);
            LogController.WriteLog(timeMsg);
        }

        public static void printLine()
        {
            printMessage(logLine);
        }

        public static void printException(Exception e)
        {
            printMessage(e.Message);
            if(e.StackTrace != null) { 
                printMessage(e.StackTrace);
            }
        }

        private static string GetCurrentTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public static string getSPFilePath()
        {
            return ConfigurationManager.AppSettings["csv_SPs_file"] ?? "sp_list.csv";
        }
    }
}
