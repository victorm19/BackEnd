CREATE TABLE dbo.Usuarios
	(
		Identificador int NOT NULL,
		Usuario varchar(30),
		Pass varchar(30),
		FechaCreación datetime
		 CONSTRAINT [FK_Usuarios_Personas] FOREIGN KEY (Identificador) REFERENCES Personas (Identificador)
	);