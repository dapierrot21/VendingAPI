USE MASTER
GO

DROP DATABASE IF EXISTS VendingMachine;

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name='VendingMachine')
	CREATE DATABASE [VendingMachine]
GO

USE VendingMachine
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Item')
	DROP TABLE Item
GO

CREATE TABLE Item (
	id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[name] VARCHAR(20) NOT NULL,
	price DECIMAL NOT NULL,
	quantity INT NULL
)

SET IDENTITY_INSERT Item ON

INSERT INTO Item (id, [name], price, quantity)
VALUES (1, 'SpinWheel', 4.50, 12),
	(2, 'Twin Snakes', 1.89, 6),
	(3, 'Fruit Rollup', 0.99, 15),
	(4, 'Cheese Pops', 1.29, 8),
	(5, 'Common Sense', 0.11, 100000),
	(6, 'Dog Treats', 8.99, 5),
	(7, 'Bottle Water', 2.00, 3),
	(8, 'Peeps', 3.45, 1),
	(9, '1 Star Dragonball', 1.00, 1),
	(10, 'Beans', 7.67, 4)

SET IDENTITY_INSERT Item OFF

