CREATE PROCEDURE [dbo].[ShowCompanyForProvidedEmployeeId] @Id int
AS
SELECT c.Id, c.Name, c.Address, c.Country
FROM [dbo].[Company] c JOIN [dbo].[Employee] e ON c.Id = e.CompanyId
Where e.Id = @Id

