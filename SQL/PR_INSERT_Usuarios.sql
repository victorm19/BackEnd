CREATE PROCEDURE PR_INSERT_Usuarios (
	@Identificador int,
	@Usuario varchar(30),
	@Pass varchar(30),
	@FechaCreaci�n datetime
)
AS
BEGIN
	INSERT INTO Usuarios (
		Identificador,
		Usuario,
		Pass,
		FechaCreaci�n
	)
	OUTPUT Inserted.Identificador
	VALUES (
		@Identificador,
		@Usuario,
		@Pass,
		@FechaCreaci�n
	)
END