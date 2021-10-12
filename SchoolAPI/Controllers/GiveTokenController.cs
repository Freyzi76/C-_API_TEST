using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    [Route("api/[controller]")]
    [ApiController]
    public class GiveTokenController : ControllerBase
    {


        [HttpGet]
        [Route("Token/{username}/{password}")]
        public IActionResult Get(string username, string password)
        {

            if (username == password)

                return new ObjectResult(JWTService.GenerateToken(username));

            else

                return BadRequest();

        }

    }
}
