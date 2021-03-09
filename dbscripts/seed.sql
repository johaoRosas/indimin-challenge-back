CREATE TABLE citizen
(
 id serial PRIMARY KEY,
 first_name VARCHAR (50) NOT NULL,
 last_name VARCHAR (50) NOT NULL,
 email VARCHAR (50) UNIQUE,
 status BOOLEAN NOT NULL
);

CREATE TABLE task (
  id serial, 
  citizen_id INT NOT NULL,
  description VARCHAR(255),
  day INT, 
  month INT,
  year INT , 
   status BOOLEAN NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (citizen_id) REFERENCES citizen(id) ON DELETE CASCADE
);

Insert into citizen(first_name,last_name,email,status) values( 'Johao','Rosas','johao@gmail.com',true);
Insert into citizen(first_name,last_name,email,status) values( 'Miriam','Hernandez','mriam@gmail.com',true);


Insert into task(citizen_id,description,day,month,year,status) values( 1,'test',10,1,2020,true);

 