
ALTER PROCEDURE SelectEmployee
(
@employeeID INT 
)
AS
BEGIN
  SELECT * FROM [dbo].[EmpTable] 
END

CREATE PROCEDURE UpdateEmployee
 (
 @employeeID int=0,
	@employeeFirstName varchar(255)=null,
	@employeeLastName varchar(255)=null,
	@dateOfBirth date=null,
	@age int=0,
	@phoneNumber varchar(255)=null,
	@email varchar(255)=null,
	@state varchar(255)=null,
	@city varchar(255)=null,
	@password varchar(255)=null
	)
 AS
  BEGIN 
     UPDATE [dbo].[EmpTable] SET
        employeeFirstName=@employeeFirstName,employeeLastName=@employeeLastName,dateOfBirth=@dateOfBirth,
		age=@age,phoneNumber=@phoneNumber,email=@email,state=@state,city=@city,password=@password
		WHERE employeeID=@employeeID

	  END


CREATE PROCEDURE DeleteEmployee
(
  @employeeID int
)
AS
BEGIN
  DELETE FROM [dbo].[EmpTable] WHERE employeeID=@employeeID
END


Alter PROCEDURE employeeINSERT
@employeeID int=0,@employeeFirstName varchar(255)=null,@employeeLastName varchar(255)=null,
	@dateOfBirth date=null,@age int=0,@phoneNumber varchar(255)=null,@email varchar(255)=null,
	@state varchar(255)=null,@city varchar(255)=null,
	@password varchar(255)=null
 AS
 INSERT INTO [dbo].[EmpTable] (
 employeeID, employeeFirstName ,
	employeeLastName ,dateOfBirth ,age,phoneNumber ,email ,state ,city ,password 
 )
 VALUES(
 @employeeID ,@employeeFirstName ,@employeeLastName ,@dateOfBirth ,@age,@phoneNumber ,@email ,@state ,@city ,@password 
 )

 CREATE PROCEDURE SelectSignin
(
@username varchar(20) ,
@password VARCHAR(20)
)
AS
BEGIN
  SELECT * FROM [dbo].[Signin] WHERE username= @username AND password=@password
END

CREATE PROCEDURE createSignin
(
@username varchar(20),
@password VARCHAR(20)
)

 AS
 INSERT INTO [dbo].[Signin] (
 username ,
password 
)
 
 VALUES(@username  ,
@password
)

 

 EXEC createSignin
 ADMIN,admin@123