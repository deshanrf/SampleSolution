using RepositoryPattern.WebApi.Dapper.Contracts;
using RepositoryPattern.WebApi.Dapper.DTOs;
using RepositoryPattern.WebApi.Dapper.Models;

namespace RepositoryPattern.WebApi.Dapper.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeService(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public Task<IEnumerable<Employee>> GetEmployees() => _employeeRepo.GetEmployees();
        public Task<Employee> GetEmployee(int id) => _employeeRepo.GetEmployee(id);
        public Task CreateMultipleEmployees(List<EmployeeForCreationUpdateDto> employees) => _employeeRepo.CreateMultipleEmployees(employees);
        public Task UpdateEmployee(int id, EmployeeForCreationUpdateDto employee) => _employeeRepo.UpdateEmployee(id, employee);
        public Task DeleteEmployee(int id) => _employeeRepo.DeleteEmployee(id);
    }
}
