CREATE TABLE [dbo].[Empleado]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nombre] NVARCHAR(40) NOT NULL, 
    [Telefono] NVARCHAR(10) NOT NULL, 
    [Fax] NVARCHAR(10) NOT NULL, 
    [Email] NVARCHAR(40) NOT NULL, 
    [Departamento] INT NOT NULL, 
    [Sucursal] INT NOT NULL, 
    [User] NVARCHAR(10) NOT NULL, 
    [Password] NVARCHAR(8) NOT NULL
)
