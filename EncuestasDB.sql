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
    usario_respueta int,
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


