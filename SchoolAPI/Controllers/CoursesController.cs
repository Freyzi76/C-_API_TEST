using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {

            return new List<string>() { "C#", "SQL" };

        }

    }
}
