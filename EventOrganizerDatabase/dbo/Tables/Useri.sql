CREATE TABLE [dbo].[Useri]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [EmailAddress] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(50) NULL, 
    [CellphoneNumber] NVARCHAR(50) NULL
)
