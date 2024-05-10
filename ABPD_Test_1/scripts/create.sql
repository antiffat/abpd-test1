-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2024-05-10 10:20:40.422

-- tables
-- Table: CPU
CREATE TABLE CPU (
                     Id int  NOT NULL IDENTITY,
                     Name varchar(100)  NOT NULL,
                     Frequency float(2)  NOT NULL,
                     Cores int  NOT NULL,
                     CONSTRAINT CPU_ak_1 UNIQUE (Name),
                     CONSTRAINT CPU_pk PRIMARY KEY  (Id)
);

-- Table: Computer
CREATE TABLE Computer (
                          Id int  NOT NULL IDENTITY,
                          VideocardId int  NOT NULL,
                          CPUId int  NOT NULL,
                          Name varchar(200)  NOT NULL,
                          CONSTRAINT Computer_ak_1 UNIQUE (Name),
                          CONSTRAINT Computer_pk PRIMARY KEY  (Id)
);

-- Table: Videocard
CREATE TABLE Videocard (
                           Id int  NOT NULL IDENTITY,
                           Name varchar(100)  NOT NULL,
                           Frequency float(2)  NOT NULL,
                           Memory float(2)  NOT NULL,
                           CONSTRAINT Videocard_ak_1 UNIQUE (Name),
                           CONSTRAINT Videocard_pk PRIMARY KEY  (Id)
);

-- foreign keys
-- Reference: Computer_CPU (table: Computer)
ALTER TABLE Computer ADD CONSTRAINT Computer_CPU
    FOREIGN KEY (CPUId)
        REFERENCES CPU (Id);

-- Reference: Computer_Videocard (table: Computer)
ALTER TABLE Computer ADD CONSTRAINT Computer_Videocard
    FOREIGN KEY (VideocardId)
        REFERENCES Videocard (Id);

insert into CPU (Name, Frequency, Cores) values ('AMD Ryzen 5 7600', 4.8, 6);
insert into Videocard (Name, Frequency, Memory) values ('MSI GeForce RTX 3070', 2.2, 8);
insert into Computer (VideocardId, CPUId, Name) values (1, 1, 'Good PC');
-- 
-- -- End of file.
-- 
