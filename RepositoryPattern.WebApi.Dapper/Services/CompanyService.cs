using RepositoryPattern.WebApi.Dapper.Contracts;
using RepositoryPattern.WebApi.Dapper.DTOs;
using RepositoryPattern.WebApi.Dapper.Models;

namespace RepositoryPattern.WebApi.Dapper.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepo;

        public CompanyService(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        public Task<IEnumerable<Company>> GetCompanies() => _companyRepo.GetCompanies();
        public Task<Company> GetCompany(int id) => _companyRepo.GetCompany(id);
        public Task CreateMultipleCompanies(List<CompanyForCreationDto> companies) => _companyRepo.CreateMultipleCompanies(companies);
        public Task UpdateCompany(int id, CompanyForUpdateDto company) => _companyRepo.UpdateCompany(id, company);
        public Task DeleteCompany(int id) => _companyRepo.DeleteCompany(id);
        public Task<Company> GetCompanyByEmployeeId(int id) => _companyRepo.GetCompanyByEmployeeId(id);
        public Task<Company> GetCompanyEmployeesMultipleResults(int id) => _companyRepo.GetCompanyEmployeesMultipleResults(id);
        public Task<List<Company>> GetCompaniesEmployeesMultipleMapping() => _companyRepo.GetCompaniesEmployeesMultipleMapping();
    }
}
