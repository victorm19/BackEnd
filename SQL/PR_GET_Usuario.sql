CREATE PROCEDURE PR_GET_Usuario(
	@Usuario varchar(30)
)
AS
BEGIN
	SELECT Identificador,
		Usuario,
		Pass,
		FechaCreaci�n
	FROM Usuarios
	WHERE Usuario = @Usuario
END