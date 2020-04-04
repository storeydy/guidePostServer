using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using databaseLayer;

namespace coffeeAppServer1.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        //[Route("api/restaurants/GetByFilters")]
        //public IEnumerable<string> GetByFilters(string major, string module)
        //{

        //    return new string[] { "Restaurant at that location" };
        //}

        [Route("api/Users/Register")]
        [HttpPost]
        public string RegisterUser(dynamic dataArray)
        {
            string username = dataArray[0].username;
            string email = dataArray[0].email;
            string password = dataArray[0].password;  //Need to encrypt

            int studentNumber = dataArray[0].studentnumber;
            string major = dataArray[0].major;
            connectionToDB connection = new connectionToDB();
            string result = connection.User_Post(username, email, password
             , studentNumber, major).ToString();
            return result;
            //string restaurantName = dataArray[0].restaurantname;
            //float stars = dataArray[0].stars;
            

          //  return result;

        }
        [Route("api/Users/LogIn")]
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [AllowAnonymous]
        public int LogInUser(string userName, string password)
        {
            connectionToDB connection = new connectionToDB();
            int result = connection.User_LogIn(userName, password);
            return result;
        }

    }
}