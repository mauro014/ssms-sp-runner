using Sp_Runner.Controllers;
using Sp_Runner.Models;
using Sp_Runner.Util;
using System.Data.SqlClient;

public class Program
{

    public static void Main()
    {
        try
        {
            List<SPModel> SPs = CSVController.readFile(Utilities.getSPFilePath());

            if (SPs != null && SPs.Count > 0)
            {
                Utilities.printMessage($"**************************** JOBS RUNNER VERSION 1 START ****************************");
                foreach (SPModel SP in SPs)
                {
                    if (SP.Nombre != null)
                    {
                        if (string.IsNullOrEmpty(SP.nPar0))
                        {
                            DbController.ExecuteProcedure(SP.Nombre, SP.TimeOut);
                        }
                        else if (string.IsNullOrEmpty(SP.nPar1))
                        {
                            DbController.ExecuteProcedure(SP.Nombre, SP.TimeOut, new SqlParameter(SP.nPar0, SP.vPar0));
                        }
                        else
                        {
                            DbController.ExecuteProcedure(SP.Nombre, SP.TimeOut, new SqlParameter(SP.nPar0, SP.vPar0), new SqlParameter(SP.nPar1, SP.vPar1));
                        }
                    }
                }
                Utilities.printMessage($" **************************** JOBS RUNNER VERSION 1 END ******************************");
            }
            else
            {
                throw new Exception("There are no SP in the configuration file.");
            }
        }
        catch (Exception ex)
        {
            Utilities.printException(ex);
        }
    }
}

