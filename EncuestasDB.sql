drop database if exists Encuestas;
create database if not exists Encuestas;
use Encuestas;

create table roles (

	id int unique,
    rol varchar(10),
    constraint roles_PK primary key(id)
);

create table usuarios (

	id int auto_increment,
    username varchar(20),
    rol int,
    passwd varchar(20),
    constraint id_PK primary key(id),
    constraint rol_FK foreign key(rol) references roles(id) on update cascade on delete cascade
);

create table encuestas (

	id int auto_increment,
    autor int,
    titulo varchar(50),
    descripcion varchar(200),
    estado varchar(20),
	cierra_en datetime,
    creado_en datetime,
	constraint encuestas_PK primary key(id),
    constraint encuestas_FK foreign key(autor) references usuarios(id)
);

create table preguntas (

	id int auto_increment,
    encuesta_id int,
    enunciado varchar(50),
    tipo_pregunta varchar(50),
    obligatorio bool,
    
	constraint preguntas_PK primary key(id),
    constraint preguntas_FK foreign key(encuesta_id) references encuestas(id) on update cascade on delete cascade
);

create table preguntas_opciones (

	id int auto_increment,
    pregunta_id int,
    position int,
    Label varchar(100),
    Value varchar(100),
    
    constraint Choices_PK primary key(id),
    constraint Choices_FK foreign key(pregunta_id) references preguntas(id) on update cascade on delete cascade
);

create table respuestas(

	id int auto_increment,
    usuario_respuesta int,
    encuesta_id int,
    pregunta_id int,
    respuesta varchar(100),
    respuesta_numeros float,
    fecha_respuesta datetime,
    seleccion_opcion_id int,
    
    constraint respuestas_PK primary key(id),
    constraint respuestas_FK1 foreign key(encuesta_id) references encuestas(id) on update cascade on delete cascade,
    constraint respuestas_FK2 foreign key(pregunta_id) references preguntas(id) on update cascade on delete cascade,
    constraint respuestas_FK3 foreign key(seleccion_opcion_id) references preguntas_opciones(id) on update cascade on delete cascade,
    constraint respuestas_FK4 foreign key(usuario_respuesta) references usuarios(id) on update cascade on delete cascade

);

create table respuestas_opciones (

	respuesta_id int,
    opcion int,
    
    constraint respuestas_opciones_PK primary key(respuesta_id, opcion),
    constraint respuestas_opciones_FK1 foreign key(respuesta_id) references respuestas(id),
    constraint respuestas_opciones_FK2 foreign key(opcion) references preguntas_opciones(id)
);

-- 1️ Insertar roles
INSERT INTO roles (id, rol) VALUES
(1, 'Admin'),
(2, 'User');

-- 2️ Insertar usuarios
INSERT INTO usuarios (username, rol, passwd) VALUES
('admin1', 1, 'passAdmin'),
('user1', 2, 'passUser'),
('user2', 2, 'passUser2');

-- 3️ Insertar encuestas
INSERT INTO encuestas (autor, titulo, descripcion, estado, cierra_en, creado_en) VALUES
(1, 'Encuesta de Satisfacción', 'Encuesta para medir la satisfacción del cliente', 'Activa', '2025-12-31 23:59:59', NOW()),
(2, 'Encuesta de Producto', 'Opiniones sobre el nuevo producto', 'Activa', '2025-11-30 23:59:59', NOW());

-- 4️ Insertar preguntas
INSERT INTO preguntas (encuesta_id, enunciado, tipo_pregunta, obligatorio) VALUES
(1, '¿Qué tan satisfecho estás con el servicio?', 'Escala', 1),
(1, '¿Recomendarías nuestro servicio?', 'Sí/No', 1),
(2, 'Califica el producto del 1 al 5', 'Escala', 1);

-- 5️ Insertar opciones para preguntas cerradas
INSERT INTO preguntas_opciones (pregunta_id, position, Label, Value) VALUES
(2, 1, 'Sí', '1'),
(2, 2, 'No', '0'),
(3, 1, '1', '1'),
(3, 2, '2', '2'),
(3, 3, '3', '3'),
(3, 4, '4', '4'),
(3, 5, '5', '5');

