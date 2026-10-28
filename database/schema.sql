-- ============================================================
-- Estrutura do banco — BibliotecaWeb
-- Rodar no SQL Server local (SSMS) ou no Azure SQL Database,
-- já conectado no banco BibliotecaDB (USE BibliotecaDB;).
-- ============================================================

CREATE TABLE Livros (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(150) NOT NULL,
    Autor NVARCHAR(100) NOT NULL,
    AnoPublicacao INT NOT NULL,
    Disponivel BIT NOT NULL DEFAULT 1,
    CaminhoImagem NVARCHAR(255) NULL,  -- só o nome do arquivo em wwwroot/imagens
    Ordem INT NULL                     -- posição no grid (drag-and-drop)
);
GO
