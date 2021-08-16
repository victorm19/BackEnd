using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Prueba.Net.Core.Interfaces;
using Prueba.Net.Entities;
using Prueba.Net.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Prueba.Net.Core.Services
{
    public class AuthenticationService : IAuthenticationLoginService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationService(IAuthenticationRepository authenticationRepository, IConfiguration configuration)
        {
            _authenticationRepository = authenticationRepository;
            _configuration = configuration;
        }

        public Respuesta<string> Login(Login login)
        {
            Respuesta<string> respuesta = new Respuesta<string>
            {
                Codigo = (int)HttpStatusCode.Unauthorized,
                Mensaje = "Usuario o contraseña invalidos"
            };

            var usuario = _authenticationRepository.ObtenerUsuarioPorNombreUsuario(login.Usuario);
            var pass = Seguridad.Encriptar(login.Password);
            if (usuario.Datos.FirstOrDefault() is null || usuario.Datos.FirstOrDefault()?.Pass != pass)
            {
                return respuesta;
            }

            var token = GenerarToken(login.Usuario);
            respuesta.Codigo = (int)HttpStatusCode.OK;
            respuesta.Mensaje = HttpStatusCode.OK.ToString();
            respuesta.Datos = new List<string> { token };

            return respuesta;
        }


        private string GenerarToken(string usuario)
        {
            var secretKey = _configuration.GetSection("SecretKey").Value;
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, usuario)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}
