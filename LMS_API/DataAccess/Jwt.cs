using LMS_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LMS_API.DataAccess
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Duration { get; set; }

        public Jwt(string? Key, string? Duration)
        {
            this.Key = Key ?? "";
            this.Duration = Duration ?? "";
        }

        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim("mobile", user.Mobile),
                new Claim("email", user.Email),
                new Claim("isBlocked", user.IsBlocked.ToString()),
                new Claim("isActive", user.IsActive.ToString()),
                new Claim("createdAt", user.AddedOn),
                new Claim("userType", user.UserType.ToString()),
                new Claim("department", user.Department),
                new Claim("university", user.University),
                new Claim("logoPath", user.LogoPath)
            };

            var jwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: claims,
                expires: DateTime.Now.AddMinutes(Int32.Parse(this.Duration)),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
