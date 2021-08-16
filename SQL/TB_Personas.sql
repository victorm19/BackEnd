CREATE TABLE dbo.Personas
   (
      Identificador int IDENTITY (1,1) NOT NULL
      ,Nombres varchar(30)
      ,Apellidos varchar(30)
	  ,NumeroIdentificaci�n  varchar(15) 
	  ,Email varchar(50)
	  ,TipoIdentificaci�n varchar(30)
	  ,FechaCreaci�n datetime
      ,IdentificacionCompleta as NumeroIdentificaci�n+' '+TipoIdentificaci�n
	  ,NombresCompletos as Nombres+' '+Apellidos
	  CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED (Identificador ASC),
    );
