using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPI.Controllers
{
    public class JWTService
    {

        private const string SECRET_KEY = "abcdefghijklmnopqrst";

        private static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));


        public static SymmetricSecurityKey GetSigningKey()
        {
            return SIGNING_KEY;
        }


        public static string GenerateToken(string username)
        {

            var token = new JwtSecurityToken(

                    claims: new Claim[]
                    {

                        new Claim(ClaimTypes.Name, username)

                    },
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                    signingCredentials: new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256)

                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
