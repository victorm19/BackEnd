CREATE TABLE dbo.Usuarios
	(
		Identificador int NOT NULL,
		Usuario varchar(30),
		Pass varchar(30),
		FechaCreaci�n datetime
		 CONSTRAINT [FK_Usuarios_Personas] FOREIGN KEY (Identificador) REFERENCES Personas (Identificador)
	);