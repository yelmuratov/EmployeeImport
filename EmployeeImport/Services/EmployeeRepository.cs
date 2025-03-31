using EmployeeImport.Data;
using EmployeeImport.interfaces;
using EmployeeImport.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeImport.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEmployeesAsync(IEnumerable<Employee> employees)
        {
            await _context.Employees.AddRangeAsync(employees);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetAllOrderedBySurnameAsync()
        {
            return await _context.Employees.OrderBy(e => e.Surname).ToListAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
