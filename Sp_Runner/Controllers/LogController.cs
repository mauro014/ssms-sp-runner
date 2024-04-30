using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sp_Runner.Controllers
{
    /**
     * https://es.stackoverflow.com/questions/299592/c%C3%B3mo-guardar-logs-en-un-archivo-de-texto-plano
     * */

    internal class LogController
    {
        public static string LogPath = "";
        public static string LogFileName = "";

        public static void tratarFicheroLog()
        {
            try
            {
                string sLogComprueba1MesAnt = getLogPath() + getLogFileName() + DateTime.Today.AddMonths(-1).ToString("yyyyMM") + ".txt";
                string sLogComprueba2MesAnt = getLogPath() + getLogFileName() + DateTime.Today.AddMonths(-2).ToString("yyyyMM") + ".txt";

                //if (File.Exists(sLogComprueba2MesAnt)) // Por ahora.
                //    File.Delete(sLogComprueba2MesAnt);

                if (!File.Exists(sLogComprueba1MesAnt))
                    File.Move(getLogPath() + getLogFileName() + ".txt", sLogComprueba1MesAnt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void WriteLog(string message)
        {
            if (!Directory.Exists(getLogPath()))
            {
                Directory.CreateDirectory(getLogPath());
            }

            if (DateTime.Now.Day == 1)
            {
                tratarFicheroLog();
            }

            string path = getLogPath() + getLogFileName() + ".txt";
            StreamWriter stream = null;
            try
            {
                stream = File.AppendText(path);
                stream.WriteLine(string.Format("{0}.", message));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        public static string getLogPath()
        {
            return (ConfigurationManager.AppSettings["LogPath"] ?? "C:\\CS_Logs") + "\\";
        }

        public static string getLogFileName()
        {
            if (string.IsNullOrEmpty(LogFileName))
            {
                return "Log";
            }
            else return LogFileName;
        }
    }
}
