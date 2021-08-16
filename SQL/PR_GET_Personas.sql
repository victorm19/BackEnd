CREATE PROCEDURE PR_GET_Personas
AS
BEGIN
	SELECT Identificador,
		Nombres,
		Apellidos,
		NumeroIdentificación,
		Email,
		TipoIdentificación,
		FechaCreación,
		IdentificacionCompleta,
		NombresCompletos
	FROM Personas
END