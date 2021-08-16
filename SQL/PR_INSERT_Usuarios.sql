CREATE PROCEDURE PR_INSERT_Usuarios (
	@Identificador int,
	@Usuario varchar(30),
	@Pass varchar(30),
	@FechaCreación datetime
)
AS
BEGIN
	INSERT INTO Usuarios (
		Identificador,
		Usuario,
		Pass,
		FechaCreación
	)
	OUTPUT Inserted.Identificador
	VALUES (
		@Identificador,
		@Usuario,
		@Pass,
		@FechaCreación
	)
END