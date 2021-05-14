USE VendingMachine;
GO

CREATE LOGIN VendingMachineApp WITH PASSWORD='testing123'
GO

CREATE USER VendingMachineApp FOR LOGIN VendingMachineApp
GO

GRANT EXECUTE ON dbo.GetAllItems TO VendingMachineApp
GRANT EXECUTE ON dbo.GetItemById TO VendingMachineApp
GRANT EXECUTE ON dbo.ItemUpdate TO VendingMachineApp
GO

GRANT SELECT ON Item TO VendingMachineApp
GRANT INSERT ON Item TO VendingMachineApp
GRANT UPDATE ON Item TO VendingMachineApp
GRANT DELETE ON Item TO VendingMachineApp
GO