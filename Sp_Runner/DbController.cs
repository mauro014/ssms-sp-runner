using System.Configuration;
using System.Data.SqlClient;

namespace Sp_Runner
{
    internal class DbController
    {
        private static string? server;
        private static string? user;
        private static string? password;
        private static string? db;

        private static void getDbConnectionSettings()
        {
            try
            {
                server = ConfigurationManager.AppSettings["SqlServer_host"];
                user = ConfigurationManager.AppSettings["SqlServer_user"];
                password = ConfigurationManager.AppSettings["SqlServer_Password"];
                db = ConfigurationManager.AppSettings["SqlServer_DB"];
            }
            catch
            {
                throw new Exception("Error de configuración de parametros.");
            }
        }

        public static SqlConnection CreateConnectionSqlServer(string server, string username, string password, string database)
        {
            try
            {
                string connectionString = $"Server={server};User ID={username};Password={password};Database={database}";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                Utilities.printException(e);
                return null;
            }
        }

        public static void ExecuteProcedure(string name, int timeOutSecons, params object[] parameters)
        {
            try
            {
                Utilities.printMessage("START  -> " + name + " - TimeOut: " + timeOutSecons);

                getDbConnectionSettings();

                if (server != null && user != null && password != null && db != null)
                {
                    using (SqlConnection conn = CreateConnectionSqlServer(server, user, password, db))
                    {
                        using (SqlCommand cmd = new SqlCommand(name, conn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            if (parameters != null)
                            {
                                cmd.Parameters.AddRange(parameters);
                            }
                            if (timeOutSecons > 0)
                            {
                                cmd.CommandTimeout = timeOutSecons;
                            }
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    throw new Exception("Error de configuración de parametros.");
                }
            }
            catch (Exception e)
            {
                Utilities.printException(e);
            }
            Utilities.printMessage("FINISH -> " + name);

        }
    }
}
