using Newtonsoft.Json;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Services
{



    public class UserServices
    {

        public IEnumerable<UserModel> Users;

        public object tableau;


        public UserServices()
        {

            string text = File.ReadAllText("Users.json");

            Users = JsonConvert.DeserializeObject<IEnumerable<UserModel>>(text);

            tableau = JsonConvert.DeserializeObject(text);

            //Console.WriteLine(tableau);

        }


    }
}
