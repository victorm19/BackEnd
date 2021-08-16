CREATE PROCEDURE PR_INSERT_Personas (
	@Nombres varchar(30),
	@Apellidos varchar(30),
	@NumeroIdentificaci�n  varchar(15), 
	@Email varchar(50),
	@TipoIdentificaci�n varchar(30),
	@FechaCreaci�n datetime
)
AS
BEGIN
	INSERT INTO Personas (
		Nombres,
		Apellidos,
		NumeroIdentificaci�n,
		Email,
		TipoIdentificaci�n,
		FechaCreaci�n
	)
	OUTPUT Inserted.Identificador
	VALUES (
		@Nombres,
		@Apellidos,
		@NumeroIdentificaci�n,
		@Email,
		@TipoIdentificaci�n,
		@FechaCreaci�n
	)
END