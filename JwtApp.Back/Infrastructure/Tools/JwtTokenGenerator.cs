using JwtApp.Back.Core.Application.Dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtApp.Back.Infrastructure.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(CheckUserResponseDto dto)
        {
            var claims = new List<Claim>();
            if (!String.IsNullOrEmpty(dto.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, dto.Role));
            }
            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));
            if (!String.IsNullOrEmpty(dto.Username))
            {
                claims.Add(new Claim(ClaimTypes.Name, dto.Username));
            }
            var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            SigningCredentials credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            JwtSecurityToken securityToken = new JwtSecurityToken(issuer:JwtTokenDefaults.ValidIssuer,audience: JwtTokenDefaults.ValidAudience,claims: claims, notBefore:DateTime.UtcNow,expires: expireDate, signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenResponseDto(handler.WriteToken(securityToken), expireDate);
        }
    }
}
