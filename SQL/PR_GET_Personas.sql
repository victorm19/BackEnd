CREATE PROCEDURE PR_GET_Personas
AS
BEGIN
	SELECT Identificador,
		Nombres,
		Apellidos,
		NumeroIdentificaci�n,
		Email,
		TipoIdentificaci�n,
		FechaCreaci�n,
		IdentificacionCompleta,
		NombresCompletos
	FROM Personas
END