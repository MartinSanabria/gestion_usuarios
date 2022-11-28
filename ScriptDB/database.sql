create database persona;
go
use persona;
go
create table usuario(
	id_usuario int not null primary key,
	nombre_usuario varchar(150),
	apellido_usuario varchar(150),
	fecha_nacimineto datetime,
	edad int
);