using Microsoft.Extensions.Configuration;
using Prueba.Net.Entities;
using Prueba.Net.Infrastructure.Data;
using Prueba.Net.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Net;

namespace Prueba.Net.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IConfiguration _config;

        public AuthenticationRepository(IConfiguration config)
        {
            _config = config;
        }

        public Respuesta<Usuarios> ObtenerUsuarioPorNombreUsuario(string usuario)
        {
            Respuesta<Usuarios> respuesta = new Respuesta<Usuarios>();

            using (DapperManager dapper = new DapperManager(_config.GetConnectionString("Dev")))
            {
                var resultado = dapper.ObtenerUsuarioPorNombreUsuario(usuario);
                respuesta.Datos = new List<Usuarios> { resultado };
            }

            respuesta.Codigo = (int)HttpStatusCode.OK;
            respuesta.Mensaje = HttpStatusCode.OK.ToString();

            return respuesta;
        }
    }
}
