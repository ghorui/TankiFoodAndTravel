CREATE TABLE [dbo].[Contact]
(
	[CompanyCode] INT NOT NULL PRIMARY KEY IDENTITY,
	[CompanyName] VARCHAR(60),
	[city] VARCHAR(30),
	[state] VARCHAR(30),
	[country] VARCHAR(30)
)
