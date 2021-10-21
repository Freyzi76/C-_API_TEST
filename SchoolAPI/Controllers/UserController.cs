using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.IO;

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
        public object UserLogin(string username, string password)
        {
            if (username == null || password == null)
                return (BadRequest());

            UserModel user = UserService.Users.FirstOrDefault(i => i.Email == username);
                
            // verifier que l'utilisateur existe SINON << return BadRequest();
            if (user == null)
                return (BadRequest());

            // si l'utilisateur existe verifier que c'est le mot de passe qui correspond a cet username SINON << return BadRequest();
            if (user.Password != password)
                return (BadRequest());


            var Content = new ObjectResult(JWTService.GenerateToken(username));


            // si le mot de passe correspond a l'utilisateur alors ont << return new ObjectResult(JWTService.GenerateToken(username));
            return Content;
        }



        [HttpGet]
       // [Authorize]
        [Route("users")]
        public IEnumerable<UserModel> GetUsers()
        {

            return UserService.Users;


        }




        [HttpGet]
        [Authorize]
        [Route("ModifyUser/{Email}")]
        public object ModifyUser(string Email)
        {
            if (Email == null )
                return (BadRequest());

            UserModel user = UserService.Users.FirstOrDefault(i => i.Email == Email);

            // verifier que l'utilisateur existe SINON << return BadRequest();
            if (user == null)
                return (BadRequest());


            return user;
        }

        
        [HttpGet]
        [Authorize]
        [Route("ExecuteManageUser/{Email}/{Name}/{Firstname}/{EmailNew}/{ResetPassword}/{IsNewUser}")]
        public object ExecuteModifyUser(string Email, string Name, string Firstname, string EmailNew, bool ResetPassword, bool IsNewUser)
        {


            UserModel VerifyEmailUser = UserService.Users.FirstOrDefault(i => i.Email == EmailNew);

            DateTime localDate = DateTime.Now;

            List<IndexModel> GetOldIndex = UserService.Index.ToList();

            if (IsNewUser == true && EmailNew == "New")
            {

                UserModel IfUserExist = UserService.Users.FirstOrDefault(i => i.Email == Email);

                if (IfUserExist == null)
                {

                    GetOldIndex[0].NumberOfId = GetOldIndex[0].NumberOfId + 1;

                    var IndexIncrement = GetOldIndex[0].NumberOfId;


                    UserModel NewUser = new UserModel
                    {

                        Id = IndexIncrement,
                        Name = Name,
                        Firstname = Firstname,
                        Email = Email,
                        Password = "0123456789",
                        Create_at = localDate.ToString(),

                    };

                    List<UserModel> GetOldList = UserService.Users.ToList();

                    GetOldList.Add(NewUser);


                    new UserServices.UserServicesReWrite(GetOldList, GetOldIndex);

                    UserService.Users = GetOldList;


                    return "OK";

                }
                else
                {
                    return "NOTOK";
                }

            }
            else
            {

                if (Email == null)
                    return (BadRequest());

                UserModel user = UserService.Users.FirstOrDefault(i => i.Email == Email);

                // verifier que l'utilisateur existe SINON << return BadRequest();
                if (user == null)

                    return (BadRequest());



                if (VerifyEmailUser == null || VerifyEmailUser.Id == user.Id)
                {

                    user.Name = Name;

                    user.Firstname = Firstname;

                    user.Email = EmailNew;

                    new UserServices.UserServicesReWrite(UserService.Users, GetOldIndex);

                    return "OK";

                }
                else
                {
                    return "NOTOK";
                }

            }



        }




        [HttpGet]
        [Authorize]
        [Route("SuppUser/{Email}")]
        public object SuppUser(string Email)
        {
            if (Email == null)
                return (BadRequest());

            UserModel user = UserService.Users.FirstOrDefault(i => i.Email == Email);

            // verifier que l'utilisateur existe SINON << return BadRequest();
            if (user == null)

                return (BadRequest());

            var UserList = UserService.Users.ToList();

            UserList.Remove(UserList.FirstOrDefault(i => i.Email == Email));


            UserService.Users = UserList;


            return "OK";




        }


    }
}
