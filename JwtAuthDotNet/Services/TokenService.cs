using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthDotNet.DTOs;
using JwtAuthDotNet.Entities;
using JwtAuthDotNet.Repositories.Interfaces;
using JwtAuthDotNet.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthDotNet.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUser _userRepository;

        public TokenService(IConfiguration configuration, IUser userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public string GenerateToken(LoginDto loginDto)
        {
            var userDb = _userRepository.GetByUserName(loginDto.UserName);
            if (loginDto.UserName != userDb.UserName && loginDto.Password != userDb.Password)
            {
                throw new InvalidOperationException("As informações do usuário não coincidem!");
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new[]
                {
                    new Claim(type: ClaimTypes.Name, userDb.UserName),
                    new Claim(type: ClaimTypes.Role, userDb.Role)
                },
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCredentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
    }
}
