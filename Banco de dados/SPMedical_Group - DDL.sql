Create database SPMedicalGroup_Senai_Manha

go

use SPMedicalGroup_Senai_Manha

go

create table Empresa(
IdEmpresa int identity primary key,
NomeEmpresa varchar(250) unique not null,
CNPJ varchar(250) unique not null,
EnderecoEmpresa varchar(250) not null
)
go

create table TipoUsuario(
IdTipoUsuario int identity primary key,
Titulo varchar(50) unique not null,
)
go

create table  Usuario(
IdUsuario int identity primary key,
IdEmpresa int foreign key references Empresa(IdEmpresa),
IdTipoUsuario int foreign key references TipoUsuario(IdTipoUsuario),
Email varchar(250) unique not null,
Senha varchar(250) not null,
)
go


create table Especialidade(
IdEspecialidade int primary key identity,
NomeEspecialidade varchar(250) not null unique,
)
go

create table Medico(
IdMedico int identity primary key,
IdUsuario int foreign key references Usuario(IdUsuario),
IdEspecialidade int foreign key references Especialidade(IdEspecialidade),
NomeMedico varchar(250) not null,
CRM varchar(250) not null,
)
go


create table Paciente(
IdPaciente int identity primary key,
IdUsuario int foreign key references Usuario(IdUsuario),
NomePaciente varchar(250) not null,
RG varchar(100) not null,
CPF varchar(100) not null,
Telefone int not null,
Endereco varchar(250) not null
)
go


create table Consulta(
IdConsulta int identity primary key,
IdPaciente int foreign key references Paciente(IdPaciente),
IdMedico int foreign key references Medico(IdMedico),
TituloConsulta varchar(250) not null,
SituacaoConsulta varchar(50) not null,
DataConsulta datetime2 not null,
Relatorio text,
);

