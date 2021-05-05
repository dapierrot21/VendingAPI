USE MASTER;
GO

CREATE LOGIN VendingMachineApp WITH PASSWORD='testing123'
GO

USE VendingMachine;
GO

CREATE USER VendingMachineApp FOR LOGIN VendingMachineApp
GO

GRANT EXECUTE ON GetAllItems TO VendingMachineApp
GRANT EXECUTE ON GetItemById TO VendingMachineApp

GRANT SELECT ON Item TO VendingMachineApp
GRANT INSERT ON Item TO VendingMachineApp
GRANT UPDATE ON Item TO VendingMachineApp
GRANT DELETE ON Item TO VendingMachineApp
GO