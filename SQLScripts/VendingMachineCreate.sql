USE MASTER
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='VendingMachine')
	DROP DATABASE VendingMachine
GO

CREATE DATABASE VendingMachine
GO

USE VendingMachine
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Item')
	DROP TABLE Item
GO

CREATE TABLE Item (
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	name VARCHAR(20) NOT NULL,
	price FLOAT(1) NOT NULL,
	quantity INT NULL
)

