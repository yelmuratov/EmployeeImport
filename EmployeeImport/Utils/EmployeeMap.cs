using CsvHelper.Configuration;
using EmployeeImport.Models;

namespace EmployeeImport.Utils
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Map(m => m.PersonnelNumber).Name("Personnel_Records.Payroll_Number");
            Map(m => m.Name).Name("Personnel_Records.Forenames");
            Map(m => m.Surname).Name("Personnel_Records.Surname");
            Map(m => m.DateOfBirth).Name("Personnel_Records.Date_of_Birth").TypeConverter<CustomDateTimeConverter>();
            Map(m => m.DateHired).Name("Personnel_Records.Start_Date").TypeConverter<CustomDateTimeConverter>();
            Map(m => m.PhoneNumber).Name("Personnel_Records.Telephone");
            Map(m => m.Mobile).Name("Personnel_Records.Mobile");
            Map(m => m.Address).Name("Personnel_Records.Address");
            Map(m => m.Address2).Name("Personnel_Records.Address_2");
            Map(m => m.ZipCode).Name("Personnel_Records.Postcode");
            Map(m => m.Email).Name("Personnel_Records.EMail_Home");
        }
    }
}
