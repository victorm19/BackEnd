using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.Net.Entities;
using Prueba.Net.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Net.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationLoginService _authenticationService;
        public AuthenticationController(IAuthenticationLoginService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]Login login)
        {
            var response = _authenticationService.Login(login);

            return StatusCode(response.Codigo, response);
        }
    }
}
