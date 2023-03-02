using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.WebApi.Dapper.DTOs;
using RepositoryPattern.WebApi.Dapper.Services;

namespace RepositoryPattern.WebApi.Dapper.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _companyService.GetCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany(int id)
        {
            try
            {
                var company = await _companyService.GetCompany(id);
                if (company == null)
                    return NotFound();

                return Ok(company);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMultipleCompanies(List<CompanyForCreationDto> companies)
        {
            try
            {
                await _companyService.CreateMultipleCompanies(companies);
                return Ok();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, CompanyForUpdateDto company)
        {
            try
            {
                var dbCompany = await _companyService.GetCompany(id);
                if (dbCompany == null)
                    return NotFound();

                await _companyService.UpdateCompany(id, company);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                var dbCompany = await _companyService.GetCompany(id);
                if (dbCompany == null)
                    return NotFound();

                await _companyService.DeleteCompany(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("ByEmployeeId/{id}")]
        public async Task<IActionResult> GetCompanyForEmployee(int id)
        {
            try
            {
                var company = await _companyService.GetCompanyByEmployeeId(id);
                if (company == null)
                    return NotFound();

                return Ok(company);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}/MultipleResult")]
        public async Task<IActionResult> GetCompanyEmployeesMultipleResult(int id)
        {
            try
            {
                var company = await _companyService.GetCompanyEmployeesMultipleResults(id);
                if (company == null)
                    return NotFound();

                return Ok(company);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("MultipleMapping")]
        public async Task<IActionResult> GetCompaniesEmployeesMultipleMapping()
        {
            try
            {
                var company = await _companyService.GetCompaniesEmployeesMultipleMapping();

                return Ok(company);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
