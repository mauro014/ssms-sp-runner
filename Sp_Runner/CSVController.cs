using CsvHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sp_Runner
{

    internal class CSVController
    {
        public static List<SPModel> readFile(string filePath)
        {
            List<SPModel> SPs;

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<SPModel>();

                SPs = records.ToList();
            }

            return SPs;
        }
    }


}
