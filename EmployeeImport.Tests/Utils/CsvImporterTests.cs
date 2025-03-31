using EmployeeImport.Utils;
using System.Text;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace EmployeeImport.Tests.Utils
{
    public class CsvImporterTests
    {
        private const string CsvHeader =
            "Personnel_Records.Payroll_Number,Personnel_Records.Forenames,Personnel_Records.Surname,Personnel_Records.Date_of_Birth,Personnel_Records.Telephone,Personnel_Records.Mobile,Personnel_Records.Address,Personnel_Records.Address_2,Personnel_Records.Postcode,Personnel_Records.EMail_Home,Personnel_Records.Start_Date";

        [Fact]
        public void ParseCsv_ValidCsv_ReturnsEmployeeList()
        {
            var csv = $@"{CsvHeader}
EMP01,John,Doe,1980-05-01,123456,789101,123 Main St,Apt 1,12345,john@example.com,2020-01-15";

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(csv));
            var result = CsvImporter.ParseCsv(stream);

            Assert.Single(result);
            Assert.Equal("EMP01", result[0].PersonnelNumber);
            Assert.Equal("John", result[0].Name);
        }

        [Fact]
        public void ParseCsv_EmptyCsv_ReturnsEmptyList()
        {
            var csv = CsvHeader;
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(csv));

            var result = CsvImporter.ParseCsv(stream);

            Assert.Empty(result);
        }

        [Fact]
        public void ParseCsv_InvalidDateFormat_ThrowsTypeConverterException()
        {
            var csv = $@"{CsvHeader}
EMP02,Jane,Doe,invalid-date,123456,789101,123 Main St,Apt 1,12345,jane@example.com,2020-01-15";

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(csv));

            Assert.Throws<TypeConverterException>(() => CsvImporter.ParseCsv(stream));
        }

        [Fact]
        public void ParseCsv_InvalidHeaders_ThrowsReaderException()
        {
            var badHeaderCsv = @"Bad,Headers,Only
val1,val2,val3";

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(badHeaderCsv));

            Assert.Throws<ReaderException>(() => CsvImporter.ParseCsv(stream));
        }
    }
}
