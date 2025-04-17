using JwtAuthDotNet.DTOs;
using JwtAuthDotNet.Entities;
using JwtAuthDotNet.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login", Name = "login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Login(LoginDto loginDto)
        {
            var token = _tokenService.GenerateToken(loginDto);

            if (token == "") return Unauthorized();

            return Ok(token);
        }
    }
}
