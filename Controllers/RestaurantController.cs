using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using databaseLayer;            //Reference added to databaseLayer - how the controllers pass data from front-end to database
using Newtonsoft.Json.Linq;

namespace coffeeAppServer1.Controllers
{
    //[Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RestaurantController : ApiController
    {
        // GET api/values
        [Route("api/Restaurant/GetAll")]
        public List<getRestaurants_Result> GetAllRestaurants()
        {
            connectionToDB connection = new connectionToDB();
            dynamic data = connection.Restaurants_get();
            return data;
        }

        // Example query: https://localhost:44349/api/forum/GetFilteredRestaurants?location=Grafton+Street
        [Route("api/Restaurant/GetFilteredRestaurants")]
        public List<getForums_Result> GetRestaurantsWFilters(string location)
        {
            connectionToDB connection = new connectionToDB();
            dynamic data = connection.Restaurants_getWFilters(location);
            return data;
        }


        [Route("api/Restaurant/InsertRestaurant")]
        [HttpPost]
        public string InsertRestaurant(dynamic dataArray)
        {
            string category = dataArray[0].category;
            string restaurantname = dataArray[0].restaurantname;
            string location = dataArray[0].location;
            double longitude = dataArray[0].longitude;
            double latitude = dataArray[0].latitude;
            string mealDeal = dataArray[0].mealDeal;

            connectionToDB connection = new connectionToDB();
            string result = connection.Restaurants_Post(category, restaurantname, location, longitude, latitude, mealDeal).ToString();
            return result;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
