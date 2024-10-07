-- Base de datos
CREATE DATABASE db_coink;
-- Tabla de Países
CREATE TABLE paises (
    id_pais SERIAL PRIMARY KEY,  -- Identificador único de cada país
    nombre_pais VARCHAR(100) NOT NULL
);

-- Tabla de Departamentos
CREATE TABLE departamentos (
    id_departamento SERIAL PRIMARY KEY,  -- Identificador único de cada departamento
    nombre_departamento VARCHAR(100) NOT NULL,
    id_pais INT REFERENCES paises(id_pais) ON DELETE CASCADE  -- Relación con la tabla de países
);

-- Tabla de Municipios
CREATE TABLE municipios (
    id_municipio SERIAL PRIMARY KEY,  -- Identificador único de cada municipio
    nombre_municipio VARCHAR(100) NOT NULL,
    id_departamento INT REFERENCES departamentos(id_departamento) ON DELETE CASCADE  -- Relación con la tabla de departamentos
);

-- Tabla de Usuarios
CREATE TABLE usuarios (
    id_usuario SERIAL PRIMARY KEY,  -- Identificador único de cada usuario
    nombre_usuario VARCHAR(100) NOT NULL,
    telefono VARCHAR(15),  -- El teléfono del usuario
    direccion VARCHAR(255),  -- La dirección del usuario
    id_pais INT REFERENCES paises(id_pais) ON DELETE SET NULL,  -- País de residencia del usuario
    id_departamento INT REFERENCES departamentos(id_departamento) ON DELETE SET NULL,  -- Departamento de residencia del usuario
    id_municipio INT REFERENCES municipios(id_municipio) ON DELETE SET NULL  -- Municipio de residencia del usuario
);

-- Opcional: Insertar algunos datos iniciales
INSERT INTO paises (nombre_pais) VALUES ('Colombia'), ('Argentina');

INSERT INTO departamentos (nombre_departamento, id_pais) 
VALUES ('Antioquia', 1), ('Cundinamarca', 1), ('Buenos Aires', 2);

INSERT INTO municipios (nombre_municipio, id_departamento)
VALUES ('Medellín', 1), ('Bogotá', 2), ('La Plata', 3);

-- Stored procedures
CREATE OR REPLACE PROCEDURE sp_insertarusuario(
    IN p_nombre_usuario VARCHAR(100),
    IN p_telefono VARCHAR(15),
    IN p_direccion VARCHAR(255),
    IN p_id_pais INT,
    IN p_id_departamento INT,
    IN p_id_municipio INT
)
LANGUAGE plpgsql
AS $$
BEGIN
    -- Insertar un usuario en la tabla 'usuarios'
    INSERT INTO usuarios (nombre_usuario, telefono, direccion, id_pais, id_departamento, id_municipio)
    VALUES (p_nombre_usuario, p_telefono, p_direccion, p_id_pais, p_id_departamento, p_id_municipio);
END;
$$;

--consultar stored procedures
SELECT proname, proargnames 
FROM pg_proc 
WHERE proname = 'sp_insertarusuario';

-- insert stored procedures
CALL sp_insertarusuario('Juan Perez', '123456789', 'Calle 123', 1,2,3);
