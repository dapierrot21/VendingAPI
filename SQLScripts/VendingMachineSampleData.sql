USE VendingMachine;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME='SampleData')
DROP PROCEDURE SampleData;
GO
-- Sample Data

CREATE PROCEDURE SampleData AS
BEGIN
	DELETE FROM Item;
END

BEGIN

SET IDENTITY_INSERT Item ON

INSERT INTO Item (id, [name], price, quantity)
VALUES (1, 'SpinWheel', 4.50, 12)

SET IDENTITY_INSERT Item OFF

END