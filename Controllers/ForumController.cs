using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using databaseLayer;
using System.Web.Http.Cors;

namespace appServer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ForumController : ApiController
    {
        [Route("api/forum/GetAll")]
        public List<getForums_Result> GetAllForums()
        {
            connectionToDB connection = new connectionToDB();
            dynamic data = connection.Forums_get(null, null);
            return data;
        }

        // Query this by https://localhost:44349/api/forum/GetSpecificForum?articleID=4
        [Route("api/forum/GetSpecificForum")]                                               //For tapping on a post to see all comments
        public List<getForums_Result> GetSpecificForum(int? articleID)
        {
            connectionToDB connection = new connectionToDB();
            dynamic data = connection.Forums_get(articleID, null);
            return data;
        }

        [Route("api/forum/GetReviewsForRestaurant")]   //Pass back restaurantID to get all reviews for that restaurant
        public List<getForums_Result> GetRestaurantReviews(int? restaurantID)
        {
            connectionToDB connection = new connectionToDB();
            dynamic data = connection.Forums_get(null, restaurantID);
            return data;
        }

        [Route("api/Forum/PostReview")]
        [HttpPost]
        public string InsertReview(dynamic dataArray)
        {
            int articleID = dataArray[0].articleID;
            string category = "Review";
            string title = dataArray[0].title;
            string description = dataArray[0].description;
            string postedBy = dataArray[0].postedBy;
            int? restaurantID = dataArray[0].restaurantID;
            double? stars = dataArray[0].stars;
            connectionToDB connection = new connectionToDB();
            string result = connection.Forum_Post(articleID, category, title, description, postedBy, restaurantID, stars).ToString();

            return result;
        }
        //[Route("api/Forum/PostForum")]                    OLD VERSION - we had planned on adding a forum for social posts etc.
        //[HttpPost]
        //public string InsertForum(dynamic dataArray)
        //{
        //    int articleID = dataArray[0].articleID;
        //    string category = dataArray[0].category;            //Social, Feedback, Advertisements, Reviews, Misc
        //    string title = dataArray[0].title;
        //    string description = dataArray[0].location;
        //    string major = dataArray[0].major;
        //    string module = dataArray[0].module;
        //    string postedBy = dataArray[0].postedBy;

        //    int? restaurantID = dataArray[0].restaurantID;    //Only if this is a review
        //    float? stars = dataArray[0].stars;                      //for a restaurant or cafe  (NULL OTHERWISE)

             
        //    connectionToDB connection = new connectionToDB();
        //    string result = connection.Forum_Post(articleID, category, title, description, major, module, postedBy, restaurantID, stars).ToString();
        //    //
        //    return result;
        //}
    }
}