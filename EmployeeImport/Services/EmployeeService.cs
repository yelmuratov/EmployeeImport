using EmployeeImport.Models;
using EmployeeImport.Utils;
using EmployeeImport.interfaces;

namespace EmployeeImport.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<(int importedCount, List<Employee> importedEmployees)> ImportEmployeesAsync(Stream fileStream)
        {
            var employees = CsvImporter.ParseCsv(fileStream);
            await _employeeRepository.AddEmployeesAsync(employees);
            return (employees.Count, employees);
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllOrderedBySurnameAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
        }
    }
}
