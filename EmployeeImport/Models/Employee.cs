using System.ComponentModel.DataAnnotations;

namespace EmployeeImport.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string PersonnelNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public DateTime? DateHired { get; set; }
    }

}
