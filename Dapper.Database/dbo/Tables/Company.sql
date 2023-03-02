CREATE TABLE [dbo].[Company] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NULL,
    [Address] NVARCHAR (50) NULL,
    [Country] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([Id] ASC)
);

