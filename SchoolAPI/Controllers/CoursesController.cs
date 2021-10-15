using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models;
using SchoolAPI.Services;
using System;
using System.Collections;
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
             UserServices test = new();

            string name = "DECAMPOS";

            object result = test.Users.FirstOrDefault(i => i.Name == name);

            // On renvoie la liste des utilisateurs présents dans le service

            //Console.WriteLine(test.Users);


                return test.Users;


        }


        public string test4 = "OK";


        [HttpGet]
        [Route("users2")]
        public object GetUser()
        {

<<<<<<< Updated upstream
            var test = UserService.Users.Select(user => user.Name) as IEnumerable;

            var test2 = UserService.Users.Select(i => i.Name == "DElArimos").ToList() as IEnumerable;


            IList list = UserService.Users.ToList();

            return test2;

=======
            return UserServices services;
>>>>>>> Stashed changes
        }



    }
}
