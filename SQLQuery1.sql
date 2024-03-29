﻿CREATE DATABASE lab07db;
GO
USE [lab07db]
GO

CREATE TABLE [dbo].[User] (
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(4000) NOT NULL,
	[Surname] NVARCHAR(4000) NOT NULL,
	[RoleId] BIGINT NOT NULL,
	PRIMARY KEY ([Id])
);

GO

CREATE TABLE [dbo].[Role] (
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[Title] NVARCHAR(200) NOT NULL,
	PRIMARY KEY ([Id])
);

GO


ALTER TABLE [dbo].[User]
	ADD CONSTRAINT FK_User_Role FOREIGN KEY (RoleId)
	REFERENCES [dbo].[Role] (Id)
	ON DELETE CASCADE
	ON UPDATE CASCADE;

GO