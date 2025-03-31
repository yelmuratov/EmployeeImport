using EmployeeImport.Models;

namespace EmployeeImport.interfaces
{
    public interface IEmployeeService
    {
        Task<(int importedCount, List<Employee> importedEmployees)> ImportEmployeesAsync(Stream fileStream);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task UpdateEmployeeAsync(Employee employee);
    }
}
