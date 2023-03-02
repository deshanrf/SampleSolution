using Dapper;
using RepositoryPattern.WebApi.Dapper.Context;
using RepositoryPattern.WebApi.Dapper.DTOs;
using RepositoryPattern.WebApi.Dapper.Models;
using RepositoryPattern.WebApi.Dapper.Services;
using System.Data;

namespace RepositoryPattern.WebApi.Dapper.Contracts
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;
        private readonly ICompanyService _companyService;

        public EmployeeRepository(DapperContext context, ICompanyService companyService)
        {
            _context = context;
            _companyService = companyService;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var query = "SELECT * FROM [dbo].[Employee]";

            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(query);
                return employees.ToList();
            }
        }
        public async Task<Employee> GetEmployee(int id)
        {
            var query = "SELECT * FROM [dbo].[Employee] WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QuerySingleOrDefaultAsync<Employee>(query, new { id });

                return employee;
            }
        }
        public async Task CreateMultipleEmployees(List<EmployeeForCreationUpdateDto> employees)
        {
            var query = "INSERT INTO [dbo].[Employee] (Name, Age, Position, CompanyId) VALUES (@Name, @Age, @Position, @CompanyId)";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var employee in employees)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("Name", employee.Name, DbType.String);
                        parameters.Add("Age", employee.Age, DbType.Int32);
                        parameters.Add("Position", employee.Position, DbType.String);
                        parameters.Add("CompanyId", employee.CompanyId, DbType.Int32);

                        var company = await _companyService.GetCompany(employee.CompanyId);
                        if (company != null)
                            await connection.ExecuteAsync(query, parameters, transaction: transaction);
                    }

                    transaction.Commit();
                }
            }
        }
        public async Task UpdateEmployee(int id, EmployeeForCreationUpdateDto employee)
        {
            var query = "UPDATE [dbo].[Employee] SET Name = @Name, Age = @Age, Position = @Position, CompanyId = @CompanyIdn WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Name", employee.Name, DbType.String);
            parameters.Add("Age", employee.Age, DbType.Int32);
            parameters.Add("Position", employee.Position, DbType.String);
            parameters.Add("CompanyId", employee.CompanyId, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteEmployee(int id)
        {
            var query = "DELETE FROM [dbo].[Employee] WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }

        }
    }
}
