namespace RepositoryPattern.WebApi.Dapper.DTOs
{
    public class EmployeeForCreationUpdateDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int CompanyId { get; set; }
    }
}
