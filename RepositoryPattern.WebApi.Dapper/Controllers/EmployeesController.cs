using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.WebApi.Dapper.DTOs;
using RepositoryPattern.WebApi.Dapper.Services;

namespace RepositoryPattern.WebApi.Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}", Name = "EmplyeeById")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployee(id);
                if (employee == null)
                    return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMultipleEmployees(List<EmployeeForCreationUpdateDto> employees)
        {
            try
            {
                await _employeeService.CreateMultipleEmployees(employees);
                return Ok();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeForCreationUpdateDto employee)
        {
            try
            {
                var dbEmployee = await _employeeService.GetEmployee(id);
                if (dbEmployee == null)
                    return NotFound();

                await _employeeService.UpdateEmployee(id, employee);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var dbEmployee = await _employeeService.GetEmployee(id);
                if (dbEmployee == null)
                    return NotFound();

                await _employeeService.GetEmployee(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
