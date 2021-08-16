CREATE PROCEDURE PR_INSERT_Personas (
	@Nombres varchar(30),
	@Apellidos varchar(30),
	@NumeroIdentificación  varchar(15), 
	@Email varchar(50),
	@TipoIdentificación varchar(30),
	@FechaCreación datetime
)
AS
BEGIN
	INSERT INTO Personas (
		Nombres,
		Apellidos,
		NumeroIdentificación,
		Email,
		TipoIdentificación,
		FechaCreación
	)
	OUTPUT Inserted.Identificador
	VALUES (
		@Nombres,
		@Apellidos,
		@NumeroIdentificación,
		@Email,
		@TipoIdentificación,
		@FechaCreación
	)
END