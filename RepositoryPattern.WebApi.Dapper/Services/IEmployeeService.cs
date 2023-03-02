﻿using RepositoryPattern.WebApi.Dapper.DTOs;
using RepositoryPattern.WebApi.Dapper.Models;

namespace RepositoryPattern.WebApi.Dapper.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetEmployees();
        public Task<Employee> GetEmployee(int id);
        public Task CreateMultipleEmployees(List<EmployeeForCreationUpdateDto> employees);
        public Task UpdateEmployee(int id, EmployeeForCreationUpdateDto employee);
        public Task DeleteEmployee(int id);
    }
}
