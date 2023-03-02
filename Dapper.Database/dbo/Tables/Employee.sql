CREATE TABLE [dbo].[Employee] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NULL,
    [Age]       INT           NULL,
    [Position]  NVARCHAR (50) NULL,
    [CompanyId] INT           NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC)
);

