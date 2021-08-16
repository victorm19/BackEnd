using Microsoft.Extensions.Configuration;
using Prueba.Net.Entities;
using Prueba.Net.Infrastructure.Data;
using Prueba.Net.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;

namespace Prueba.Net.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly IConfiguration _config;


        public PersonaRepository(IConfiguration config)
        {
            _config = config;
        }

        public Respuesta<bool> Insertar(Personas persona, Usuarios usuario)
        {
            Respuesta<bool> respuesta = new Respuesta<bool>();

            try
            {
                var id = InsertarPersona(persona);
                usuario.Identificador = id;
                InsertarUsuario(usuario);

                respuesta.Codigo = (int)HttpStatusCode.OK;
                respuesta.Mensaje = HttpStatusCode.OK.ToString();
                respuesta.Datos = new List<bool>{ true };

            } catch (Exception ex)
            {
                respuesta.Codigo = (int)HttpStatusCode.BadRequest;
                respuesta.Mensaje = "Ha ocurrido un error"+ ex;
                respuesta.Datos = new List<bool> { false };
            }
            
            return respuesta;
        }

        private int InsertarPersona(Personas persona)
        {
            int respuesta = 0;

            using (DapperManager dapper = new DapperManager(_config.GetConnectionString("Dev")))
            {
                var resultado = dapper.InsertarPersona(persona);
                respuesta = resultado;
            }

            return respuesta;
        }

        private int InsertarUsuario(Usuarios usuario)
        {
            int respuesta = 0;

            using (DapperManager dapper = new DapperManager(_config.GetConnectionString("Dev")))
            {
                var resultado = dapper.InsertarUsuario(usuario);
                respuesta = resultado;
            }

            return respuesta;
        }

        public Respuesta<Personas> ObtenerPersonas()
        {
            Respuesta<Personas> respuesta = new Respuesta<Personas>();

            using (DapperManager dapper = new DapperManager(_config.GetConnectionString("Dev")))
            {
                var resultado = dapper.ObtenerPersonas();
                respuesta.Datos = resultado;
            }

            respuesta.Codigo = (int)HttpStatusCode.OK;
            respuesta.Mensaje = HttpStatusCode.OK.ToString();

            return respuesta;
        }

        public Respuesta<Usuarios> ObtenerUsuarioPorNombreUsuario(string usuario)
        {
            Respuesta<Usuarios> respuesta = new Respuesta<Usuarios>();

            using (DapperManager dapper = new DapperManager(_config.GetConnectionString("Dev")))
            {
                var resultado = dapper.ObtenerUsuarioPorNombreUsuario(usuario);
                respuesta.Datos.Add(resultado);
            }

            respuesta.Codigo = (int)HttpStatusCode.OK;
            respuesta.Mensaje = HttpStatusCode.OK.ToString();

            return respuesta;
        }
    }
}
