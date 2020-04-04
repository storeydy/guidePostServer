using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using databaseLayer;
using Newtonsoft.Json.Linq;

namespace coffeeAppServer1.Controllers
{
    //[Authorize]
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

        // Query this by https://localhost:44349/api/forum/GetFilteredRestaurants?location=Grafton+Street
        [Route("api/Restaurant/GetFilteredRestaurants")]
        public List<getForums_Result> GetRestaurantsWFilters(string location)
        {
            connectionToDB connection = new connectionToDB();
            dynamic data = connection.Restaurants_getWFilters(location);
            return data;
        }


        //[Route("api/Restaurant/InsertRestaurant")]
        //[HttpPost]
        //public string InsertRestaurant(dynamic dataArray)
        //{
        //    string category = dataArray[0].category;
        //    string restaurantname = dataArray[0].restaurantname;
        //    string location = dataArray[0].location;
        //    string option1 = dataArray[0].option1;
        //    double option1Price = dataArray[0].option1Price;
        //    double option1PriceWithDiscount = dataArray[0].option1PriceWithDiscount;
        //    string option2 = dataArray[0].option2;
        //    double? option2Price = dataArray[0].option2Price;
        //    double? option2PriceWithDiscount = dataArray[0].option2PriceWithDiscount;

        //      connectionToDB connection = new connectionToDB();
        //       string result =  connection.Restaurants_Post(category, restaurantname, location, option1, option1Price, option1PriceWithDiscount, option2, option2Price, option2PriceWithDiscount).ToString();
            
        //    return result;
        //}

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
