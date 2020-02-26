using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

//Custom Namespaces
using SEIS.Identity.Api.Models;
using SEIS.Identity.Api.Services.Interfaces;
using SEIS.Identity.Api.Helpers;

namespace SEIS.Identity.Api.Services
{
    /// <summary>
    /// Authenticate the user and return a JWT Token in return
    /// </summary>
    public class AuthenticationService : IAuthenticate
    {
        //List Containing users 
        private List<User> _users = new List<User>
        {
            new User {  FirstName="Girish", LastName="Srinivasa", FullName="Girish Srinivasa", LoginName="sgirish", LoginPassword="Password@01", Role ="Office Administrator"},
            new User {  FirstName="Srini", LastName="Giri", FullName="Srini Giri", LoginName="sgiri", LoginPassword="Password@02", Role ="Office Clerk"},
        };
        private readonly AppSettings _appSettings;

        public AuthenticationService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public AuthenticationSecurityToken Authenticate(string userName, string password)
        {
            var user = _users.SingleOrDefault(x => x.LoginName == userName && x.LoginPassword == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("firstname", user.FirstName),
                    new Claim("lastname", user.LastName),
                    new Claim("name", user.FullName),
                    new Claim("role", user.Role),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtSecurityToken = tokenHandler.WriteToken(token);

            return new AuthenticationSecurityToken { authentication_token = jwtSecurityToken };

        }
    }
}
