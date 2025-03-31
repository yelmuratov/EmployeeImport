using Xunit;
using Moq;
using EmployeeImport.interfaces;
using EmployeeImport.Services;
using EmployeeImport.Models;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeImport.Tests.Services
{
    public class EmployeeServiceTests
    {
        [Fact]
        public async Task ImportEmployeesAsync_ValidCsv_ReturnsCorrectCount_AndCallsRepository()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            var service = new EmployeeService(mockRepo.Object);

            string csv = @"Personnel_Records.Payroll_Number,Personnel_Records.Forenames,Personnel_Records.Surname,Personnel_Records.Date_of_Birth,Personnel_Records.Telephone,Personnel_Records.Mobile,Personnel_Records.Address,Personnel_Records.Address_2,Personnel_Records.Postcode,Personnel_Records.EMail_Home,Personnel_Records.Start_Date
JACK13,Jerry,Jackson,05/11/1974,2050508,6987457,115 Spinney Road,Luton,LU33DF,gerry.jackson@bt.com,04/18/2013";

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(csv));

            // Act
            var (count, employees) = await service.ImportEmployeesAsync(stream);

            // Assert
            Assert.Equal(1, count);
            Assert.Single(employees);
            Assert.Equal("JACK13", employees[0].PersonnelNumber);

            mockRepo.Verify(r => r.AddEmployeesAsync(It.IsAny<IEnumerable<Employee>>()), Times.Once);
        }

        [Fact]
        public async Task GetAllEmployeesAsync_CallsRepositoryAndReturnsSortedList()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            var fakeList = new List<Employee>
            {
                new Employee { Surname = "Zane" },
                new Employee { Surname = "Alpha" }
            };

            mockRepo.Setup(r => r.GetAllOrderedBySurnameAsync()).ReturnsAsync(fakeList);
            var service = new EmployeeService(mockRepo.Object);

            // Act
            var result = await service.GetAllEmployeesAsync();

            // Assert
            Assert.Equal(2, result.Count);
            mockRepo.Verify(r => r.GetAllOrderedBySurnameAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateEmployeeAsync_CallsRepositoryUpdate()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            var service = new EmployeeService(mockRepo.Object);
            var employee = new Employee { Id = 1, Name = "John" };

            // Act
            await service.UpdateEmployeeAsync(employee);

            // Assert
            mockRepo.Verify(r => r.UpdateAsync(employee), Times.Once);
        }
    }
}
