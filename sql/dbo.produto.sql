CREATE TABLE dbo.produto
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nome] NVARCHAR(50) NOT NULL, 
    [Descricao] NVARCHAR(100) NULL, 
    [Valor] DECIMAL(9, 2) NULL
)
