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

        public IEnumerable<IndexModel> Index;


        public UserServices()
        {
            if (File.Exists("Users.json")) ;
                string UserFile = File.ReadAllText("Users.json");
                string IndexFile = File.ReadAllText("Index.json");

            Users = JsonConvert.DeserializeObject<IEnumerable<UserModel>>(UserFile);

                Index = JsonConvert.DeserializeObject<IEnumerable<IndexModel>>(IndexFile);

            //Console.WriteLine(tableau);

        }



        internal class UserServicesReWrite
        {
            private IEnumerable<UserModel> users;

            public UserServicesReWrite(IEnumerable<UserModel> users, IEnumerable<IndexModel> index)
            {

                string UserPath = "Users.json";

                string IndexPath = "Index.json";


                var UserJsonConvert = JsonConvert.SerializeObject(users);

                var IndexJsonConvert = JsonConvert.SerializeObject(index);



                using StreamWriter UserStreamWriter = File.CreateText(UserPath);

                UserStreamWriter.WriteLine(UserJsonConvert);


                using StreamWriter IndexStreamWriter = File.CreateText(IndexPath);

                IndexStreamWriter.WriteLine(IndexJsonConvert);




            }
        }
    }






}
