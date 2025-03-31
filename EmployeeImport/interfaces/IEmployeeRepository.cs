using EmployeeImport.Models;

namespace EmployeeImport.interfaces
{
    public interface IEmployeeRepository
    {
        Task AddEmployeesAsync(IEnumerable<Employee> employees);
        Task<List<Employee>> GetAllAsync();
        Task UpdateAsync(Employee employee);
        Task<List<Employee>> GetAllOrderedBySurnameAsync();
    }
}
