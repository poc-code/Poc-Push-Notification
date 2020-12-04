using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using poc_push_notification.domain.Model;
using poc_push_notification.service.Interface;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace poc_push_notification.service.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly IJsonServerServices _jsonService;
        private readonly string _jwtSecurityKey;

        public TokenService(IConfiguration config, IJsonServerServices jsonService)
        {
            _config = config;
            _jsonService = jsonService;
            _jwtSecurityKey = _config["AppSettings:Secret"];
        }

        public AuthResponse Generate(User user)
        {
            var credential = GetUserAsync(user).Result;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecurityKey);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, credential.Username),
                    new Claim(ClaimTypes.Name, credential.FullName),
                    new Claim(ClaimTypes.Email, credential.Email),
                    new Claim(ClaimTypes.Role, credential.Role),
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(securityTokenDescriptor);
            var response = new AuthResponse
            {
                token_type = "Bearer",
                expires_in = (securityTokenDescriptor.Expires.Value - DateTime.Now).TotalSeconds,
                access_token = tokenHandler.WriteToken(token)
            };
            tokenHandler.WriteToken(token);

            return response;
        }

        private async Task<User> GetUserAsync(User user) 
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                throw new ArgumentException("Credenciais inválidas");

            return await _jsonService.GetByCredential(user);
        }
    }
}
