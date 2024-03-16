CREATE TABLE Patient (
    Id INT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    CPF VARCHAR(15) NOT NULL UNIQUE,
    DateOfBirth DATE NOT NULL,
    Phone VARCHAR(12) NOT NULL,
    Address VARCHAR(255)NOT NULL,
	Number VARCHAR(10)NOT NULL,
    Email VARCHAR(255)NOT NULL,
    Gender CHAR(10)NOT NULL,
    Notes TEXT,
    CONSTRAINT CHK_Gender CHECK (Gender IN ('Male', 'Female', 'Other'))
);

CREATE TABLE Doctor (
    Id INT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    CRM VARCHAR(20) NOT NULL UNIQUE,
    Phone VARCHAR(12) NOT NULL,
    Address VARCHAR(255)NOT NULL,
	Number VARCHAR(10)NOT NULL,
    Specialty VARCHAR(100)NOT NULL,
    OfficeHours VARCHAR(100)NOT NULL,
    Email VARCHAR(255)NOT NULL,
    Notes TEXT
);

CREATE TABLE Appointment (
    Id INT PRIMARY KEY,
    patient_Id INT NOT NULL,
    doctor_Id INT NOT NULL,
    AppointmentDate DATETIME NOT NULL,
    AppointmentType VARCHAR(20) NOT NULL,
    AppointmentStatus VARCHAR(20) NOT NULL,
	Plano VARCHAR(3) NOT NULL,
    Value DECIMAL(10, 2),
    Diagnosis TEXT,
    Prescription TEXT,
    FOREIGN KEY (patient_Id) REFERENCES Patient (Id),
    FOREIGN KEY (doctor_Id) REFERENCES Doctor(Id),
    CONSTRAINT CHK_AppointmentType CHECK (AppointmentType IN ('Routine', 'Emergency', 'Follow-up')),
    CONSTRAINT CHK_AppointmentStatus CHECK (AppointmentStatus IN ('Scheduled', 'Canceled', 'Completed'))
);

select * from Patient
select * from Doctor
select * from Appointment

Drop table Patient
Drop table Doctor
Drop table Appointment