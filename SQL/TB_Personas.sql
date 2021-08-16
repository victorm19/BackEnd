CREATE TABLE dbo.Personas
   (
      Identificador int IDENTITY (1,1) NOT NULL
      ,Nombres varchar(30)
      ,Apellidos varchar(30)
	  ,NumeroIdentificación  varchar(15) 
	  ,Email varchar(50)
	  ,TipoIdentificación varchar(30)
	  ,FechaCreación datetime
      ,IdentificacionCompleta as NumeroIdentificación+' '+TipoIdentificación
	  ,NombresCompletos as Nombres+' '+Apellidos
	  CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED (Identificador ASC),
    );
