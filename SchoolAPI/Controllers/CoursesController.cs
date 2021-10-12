using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models;
using SchoolAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CoursesController : ControllerBase
    {
        // On déclare une variable pour stocker l'instance de notre Service
        public UserServices UserService;

        // On déclare un constructeur qui prend en paramètre notre service
        // L'injection de dépendance l'injectera dans notre constructeur
        public CoursesController(UserServices userServices)
        {
            // On assigne la référence reçue à notre variable locale pour l'utiliser dans le controller
            UserService = userServices;
        }

        [HttpGet]
        [Route("test")]
        [Authorize]
        public IEnumerable<string> Get()
        {

            return new List<string>() { "C#", "SQL" };

        }

        [HttpGet]
        [Route("users")]
        // Cette méthode nous renvoie la liste des Users, c'est une Collection (IEnumerable)
        public IEnumerable<UserModel> GetUsers()
        {
            // Cette ligne n'est pas utile, on a déjà récupéré le service plus haut
            // UserServices test = new();

<<<<<<< Updated upstream
            // On renvoie la liste des utilisateurs présents dans le service
            return (UserService.Users);
=======
            return UserServices services;
>>>>>>> Stashed changes
        }

    }
}
