--Cria��o do banco de dados
CREATE DATABASE ImportadorContratosDB

USE ImportadorContratosDB

--Cria��o da tabela Contratos para futuro armazenamento do arquivo CSV

CREATE TABLE Contratos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100),
    CPF VARCHAR(14),
    NumeroContrato VARCHAR(20),
    Produto NVARCHAR(100),
    Vencimento DATE,
    Valor DECIMAL(18,2)
);



--Criar uma tabela Usuarios para controle de login na aplica��o
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100),
    Login NVARCHAR(50) UNIQUE,
    SenhaHash VARBINARY(255)
);

--E ent�o criar uma chave estrangeira para verificar qual usuario fez altera��es
ALTER TABLE Contratos
ADD UsuarioId INT NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id);

--Cria��o de um login e senha para acesso do administrador
INSERT INTO Usuarios (Nome, Login, SenhaHash)
VALUES (
    'Administrador',
    'admin',
    HASHBYTES('SHA2_256', 'admin123')
);

--Verificar se a conta foi criado
SELECT *
FROM Usuarios

--Assim que o banco de dados estiver armazenando as informa��es do csv.
--E assim que salvar os contratos no Visual Studio, verificar se foram salvos no Banco.
SELECT *
FROM Contratos

