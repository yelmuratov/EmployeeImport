using CsvHelper;
using CsvHelper.Configuration;
using EmployeeImport.Models;
using System.Globalization;

namespace EmployeeImport.Utils
{
    public static class CsvImporter
    {
        public static List<Employee> ParseCsv(Stream csvStream)
        {
            using var reader = new StreamReader(csvStream);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                HeaderValidated = null
            });

            csv.Context.RegisterClassMap<EmployeeMap>();

            var records = csv.GetRecords<Employee>().ToList();
            return records;
        }
    }
}
