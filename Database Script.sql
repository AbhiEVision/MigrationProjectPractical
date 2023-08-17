CREATE database hospital_db;

GO;

use hospital_db;

GO;

CREATE TABLE admins (
    id INT PRIMARY key IDENTITY,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    phone VARCHAR(15) NOT NULL,
    created datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
);

GO;

CREATE TABLE doctors (
    id INT PRIMARY key IDENTITY,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    phone VARCHAR(15) NOT NULL,
    gender INT NOT NULL,
    specialist VARCHAR(255) NOT NULL,
    created datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
);
GO;

INSERT INTO doctors (name, email, password, phone, gender, specialist) values ( 'Abhi','abhi@gmail.com','123','1231231231',0,'Feat1');
INSERT INTO doctors (name, email, password, phone, gender, specialist) values ( 'test','test@gmail.com','123','1231231231',0,'Feat2');
GO;


CREATE TABLE nurses (
    id INT PRIMARY key IDENTITY,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    phone VARCHAR(15) NOT NULL,
    created datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
);

GO;

INSERT INTO nurses(name, email, password, phone) VALUES ( 'Abhi','abhi@gmail.com','123','1231231231');
INSERT INTO nurses(name, email, password, phone) VALUES ( 'test','test@gmail.com','123','1231231231');
GO;


CREATE TABLE patients (
    id INT PRIMARY key IDENTITY,
    name VARCHAR(255) NOT NULL,
    phone VARCHAR(15) NOT NULL,
    gender INT NOT NULL,
    health_condition VARCHAR(255) NOT NULL,
    doctor_id INT NOT NULL FOREIGN key REFERENCES doctors (id),
    nurse_id INT NOT NULL FOREIGN key REFERENCES nurses (id),
    created datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
);

GO;