USE VendingMachine
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllItems')
	DROP PROCEDURE GetAllItems
GO

CREATE PROCEDURE GetAllItems
AS
	SELECT id, [name], price, quantity
	FROM Item
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetItemById')
	DROP PROCEDURE GetItemById
GO

CREATE PROCEDURE GetItemById(
	@id INT
)
AS
	SELECT id, [name], price, quantity
	FROM Item
	WHERE id = @id
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ItemUpdate')
      DROP PROCEDURE ItemUpdate
GO

CREATE PROCEDURE ItemUpdate (
	@id int output,
	@name varchar(20),
	@price decimal,
	@quantity int
)AS
BEGIN
	UPDATE Item SET
			[name] = @name,
			price = @price,
			quantity = @quantity

	WHERE id = @id
END
GO

