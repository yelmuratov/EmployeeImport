using CsvHelper.TypeConversion;
using CsvHelper;
using EmployeeImport.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeImport.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return View(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["Error"] = "Please select a valid CSV file.";
                return RedirectToAction("Index");
            }

            try
            {
                using var stream = file.OpenReadStream();
                var (importedCount, _) = await _employeeService.ImportEmployeesAsync(stream);
                TempData["Success"] = $"{importedCount} employees imported successfully.";
            }
            catch (HeaderValidationException)
            {
                TempData["Error"] = "😬 Whoops! The uploaded file is missing the expected headers.<br/>" +
                                    "Double-check that the CSV has the correct column names.";
            }
            catch (TypeConverterException)
            {
                TempData["Error"] = "🔍 Uh-oh! One or more fields have invalid formats.<br/>" +
                                    "Are those dates actually... dates?";
            }
            catch (Exception)
            {
                TempData["Error"] = "🤖 Oops! That file might’ve had a little too much personality.<br/>" +
                                    "Please upload a clean, well-behaved <strong>CSV file</strong> with the expected format.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] EmployeeImport.Models.Employee updatedEmployee)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid employee data.";
                return RedirectToAction("Index");
            }

            await _employeeService.UpdateEmployeeAsync(updatedEmployee);

            TempData["Success"] = "Employee updated successfully.";
            return RedirectToAction("Index");
        }

    }
}
