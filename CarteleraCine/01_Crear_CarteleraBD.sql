IF DB_ID('CarteleraDB') IS NULL
BEGIN
    CREATE DATABASE CarteleraDB;
END
GO

USE CarteleraDB;
GO

IF OBJECT_ID('dbo.Funciones', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Funciones
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Pelicula NVARCHAR(100) NOT NULL,
        Sala NVARCHAR(50) NOT NULL,
        Precio DECIMAL(10,2) NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Funciones)
BEGIN
    INSERT INTO dbo.Funciones (Pelicula, Sala, Precio)
    VALUES
    ('Coco', 'Sala 1', 40.00),
    ('Moana', 'Sala 2', 45.00);
END
GO

SELECT * FROM dbo.Funciones;
GO