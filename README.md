# PruebaTecnicaGET

Script de la Base de datos:

use master

go

create database pruebaGETTECH

go

use pruebaGETTECH

create table Persona (

	id int primary key identity(1, 1),
 
	nombre nvarchar(50) not null,
 
	apellidoPaterno nvarchar(50) not null,
 
	apellidoMaterno nvarchar(50) null,
 
	identificacion nvarchar(25) not null
 
)

create table Factura (

	id int primary key identity(1, 1),
 
	fecha datetime default GETDATE(),
 
	monto decimal(10, 2) not null,

	idPersona int foreign key references Persona(id) 
)

insert into Persona (nombre, apellidoPaterno, identificacion) values ('Jasson', 'Medina', '111-111111-1111A')
