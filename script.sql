-- CRIANDO O BANCO DE DADOS
CREATE DATABASE bdloja2dsa;

-- USANDO O BANCO DE DADOS
USE bdloja2dsa;

-- CRIANDO AS TABELAS DO BANCO DE DAODS
CREATE TABLE Usuario (
id int primary key auto_increment,
email varchar(40) not null,
senha varchar(40) not null,
nome varchar(40) not null,
role VARCHAR(20) NOT NULL DEFAULT 'user'

);


CREATE TABLE Cliente(
codCli int primary key auto_increment,
nomeCli varchar(40) not null,
telCli varchar(40) not null,
emailCli varchar(40) not null
);

create table Produto(
Id int primary key not null auto_increment,
Nome varchar (40) not null, 
Descricao varchar(200) not null,
Preco decimal (10,2) not null,
Categoria varchar (100) not null
);


-- CONSULTANDO AS TABELAS DO BANCO DE DAODS

SELECT * FROM Usuario;
SELECT * FROM Cliente;
SELECT * FROM Produto;


INSERT INTO Usuario (nome, email, senha, role)
VALUES ('Funcionario Loja', 'func@email.com', '123456', 'Funcionario');
;



