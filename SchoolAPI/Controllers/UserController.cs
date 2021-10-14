using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        // On déclare une variable pour stocker l'instance de notre Service
        public UserServices UserService;

        // On déclare un constructeur qui prend en paramètre notre service
        // L'injection de dépendance l'injectera dans notre constructeur
        public UserController(UserServices userServices)
        {
            // On assigne la référence reçue à notre variable locale pour l'utiliser dans le controller
            UserService = userServices;
        }



        [HttpGet]
        [Route("login/{username}/{password}")]
        public IActionResult UserLogin(string username, string password)
        {

            if (username != null && password != null)
            {

                // verifier que l'utilisateur existe SINON << return BadRequest();

                    // si l'utilisateur existe verifier que c'est le mot de passe qui correspond a cet username SINON << return BadRequest();

                         // si le mot de passe correspond a l'utilisateur alors ont << return new ObjectResult(JWTService.GenerateToken(username));

            }
            else
            {

                return BadRequest();

            }


        }

    }
}
