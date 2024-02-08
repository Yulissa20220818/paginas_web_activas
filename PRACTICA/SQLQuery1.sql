create database practica
go
use practica
go

create table Clientes(
clienteID int primary key identity(1,1),
nombre varchar(50),
email varchar(100),
)


create table pedidos(
pedidoID int primary key identity(1,1),
ClienteID int,
FechaPedido date, 
Total decimal(10,2),
foreign key (Clienteid) references clientes(clienteID),
)

  
INSERT INTO Clientes ( nombre, email) VALUES ( 'Juan Pérez', 'juan@gmail.com');
INSERT INTO Clientes ( nombre, email) VALUES ( 'María García', 'maria@gmail.com');

INSERT INTO Pedidos ( ClienteID, FechaPedido, Total) VALUES ( 1, '2024-02-01', 150.00);
INSERT INTO Pedidos ( ClienteID, FechaPedido, Total) VALUES ( 2, '2024-02-02', 200.50); 


select cli.nombre, cli.email, p.FechaPedido, p.Total  from pedidos as p  inner join clientes as cli on p.ClienteID=cli.clienteID  

go 

/*Ejercicio 1*/

create database GestionTareas
go
use GestionTareas

create table Usuarios(
UsuarioID int primary key identity(1,1),
Nombre varchar(50),
Email varchar(100),
Departamento varchar(100),
)

create table Proyectos(
ProyectoID int primary key identity(1,1),
Nombre varchar(50),
Descripcion varchar(100),
FechaInicio date,
fechaFin date, 

)

create table Tareas(
TareaID int primary key identity(1,1),
ProyectoID int,
Descripcion varchar(50),
FechaCreacion date,
FechaLimite date,
UsuarioID int,
Estado varchar, 
foreign key (UsuarioID) references Usuarios(UsuarioID),
foreign key (ProyectoID) references Proyectos(ProyectoID),
)

INSERT INTO Usuarios ( nombre, email, departamento) VALUES ( 'Juan Pérez', 'juan@gmail.com');
INSERT INTO Usuarios ( nombre, email, departamento) VALUES ( 'María García', 'maria@gmail.com');

INSERT INTO Proyectos ( ProyectoID, Nombre, Descripcion, FechaInicio, fechaFin) VALUES ( 1, '2024-02-01', 150.00);
INSERT INTO Proyectos ( ProyectoID, Nombre, Descripcion, FechaInicio, fechaFin) VALUES ( 2, '2024-02-02', 200.50); 

INSERT INTO Tareas ( TareaID, ProyectoID, Descripcion, FechaCreacion, FechaLimite, UsuarioID) VALUES ( 1, '2024-02-01', 150.00);
INSERT INTO Tareas ( TareaID, ProyectoID, Descripcion, FechaCreacion, FechaLimite, UsuarioID) VALUES ( 2, '2024-02-02', 200.50); 


