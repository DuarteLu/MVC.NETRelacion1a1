create database Relacion1a1
go
use Relacion1a1

create table Empleado(
IdEmpleado int identity(1,1) primary key,
Nombre varchar(50),
IdDireccion int )

--El Id de la table direccion debe ser al mismo tiempo clave primaria y clave foranea.
--y no debe ser identity para poder crear una relacion 1 a 1 

create table Direccion(
IdEmpleado int ,
Calle varchar(50),
constraint pk_idEmpleado primary key(IdEmpleado),
constraint fk_idEmpleado foreign key (IdEmpleado) REFERENCES Empleado(IdEmpleado))

ALTER TABLE Empleado ADD CONSTRAINT fk_idDireccion foreign key (IdDireccion) REFERENCES Direccion(IdEmpleado)