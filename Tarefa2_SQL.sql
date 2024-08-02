CREATE DATABASE EMPRESA
GO
USE EMPRESA
GO

CREATE TABLE Departamento
(
    ID integer PRIMARY KEY,
    Nome VARCHAR(255)
);

CREATE TABLE Pessoa
(
    ID INTEGER PRIMARY KEY,
    Nome VARCHAR(255),
    Salario INTEGER,
    DeptId INTEGER,
    CONSTRAINT fk_DeptId FOREIGN KEY (DeptId) REFERENCES Departamento (ID)
);



INSERT INTO Departamento (ID, Nome)
VALUES 
(1,'TI'),
(2,'VENDAS');

INSERT INTO Pessoa (ID, Nome,Salario,DeptId)
VALUES 
(1,'Joe',70000 ,1),
(2,'Henry',80000,2),
(3,'Sam',60000,2),
(4,'Max',90000,1);

sELECT * FROM Departamento

sELECT * FROM Pessoa

--RESPOSTAS TAREFA 2
--Consulta todos
SELECT Departamento.Nome as [Departamento], Pessoa.Nome as [Funcionario],Pessoa.Salario
FROM Pessoa
LEFT JOIN Departamento
ON Pessoa.DeptId = Departamento.ID;

SELECT Departamento.Nome as [Departamento], Pessoa.Nome as [Pessoa],Pessoa.Salario
FROM Pessoa
LEFT JOIN Departamento
ON Pessoa.DeptId = Departamento.ID;

--Salario mais alto de cada departamento
--Salario Mais alto - Departamento TI
SELECT Departamento.Nome as [Departamento], Pessoa.Nome as [Pessoa],Pessoa.Salario
FROM Pessoa
LEFT JOIN Departamento
ON Pessoa.DeptId = Departamento.ID
WHERE pessoa.salario = (SELECT MAX(Pessoa.Salario) FROM Pessoa WHERE Pessoa.DeptId = 1) ;

--Salario Mais alto Departamento VENDAS

SELECT Departamento.Nome as [Departamento], Pessoa.Nome as [Pessoa],Pessoa.Salario
FROM Pessoa
LEFT JOIN Departamento
ON Pessoa.DeptId = Departamento.ID
WHERE pessoa.salario = (SELECT MAX(Pessoa.Salario) FROM Pessoa WHERE Pessoa.DeptId = 2) ;


--Salario Mais alto Departamento VENDAS E TI

SELECT TOP 2 D.Nome as [Departamento], P.Nome as [Pessoa],MAX(P.Salario) AS Salario
FROM Pessoa as P
LEFT JOIN Departamento as D
ON P.DeptId = D.ID
GROUP BY D.Nome, P.Nome ,P.Salario order by P.Salario desc;
