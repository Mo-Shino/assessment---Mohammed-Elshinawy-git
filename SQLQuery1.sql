	create database db_Medical_Appointment_System
	GO

	CREATE TABLE tbl_User (
		UserID			int Primary Key IDENTITY(1,1) ,
		[Name]			nvarchar(50),
		[Password]		nvarchar(50),
		Email			nvarchar(50) unique,
		UserRole		nvarchar(50) CHECK(UserRole in ( 'Doctor', 'Receptionist'))
	)

	insert into tbl_User values		('shino', 'pass','shin@', 'Doctor'),
									('hamo', 'pass1','hamo@', 'Receptionist')

	CREATE TABLE tbl_Patient (
		PatientID		int Primary Key IDENTITY(1,1) ,
		PatientName		nvarchar(50),
		Phone 			nvarchar(50),
		DateOfBirth 	nvarchar(50),
		Notes 			nvarchar(50)
	)
	
	insert into tbl_Patient values	('Patient1', '0101010101', '09-18-2009' , 'verey sick'),
									('Patient2', '0202020220', '03-18-2003' , 'verey sick')
	



	CREATE TABLE tbl_attributes (
		AppointmentID	int Primary Key IDENTITY(1,1) ,
		UserID	 		int references tbl_User(UserID),
		PatientID 		int references tbl_Patient(PatientID),
		[DateTime]		nvarchar(50),
		Reason 			nvarchar(50),
		[Status] 		nvarchar(50) CHECK([Status] IN ( 'Scheduled', 'Completed', 'Cancelled'))
	)
		
	insert into tbl_attributes values	('1', '1', '02-11-2025' , 'for fast eating','Scheduled'),
										('1', '2', '02-11-2025' , 'for going','Cancelled'),
										('1', '2', '02-12-2025' , 'for fast sleaping','Completed')


	drop table tbl_attributes
	drop table tbl_Patient
	drop table tbl_User