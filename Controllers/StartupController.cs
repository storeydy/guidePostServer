using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using databaseLayer;

namespace coffeeAppServer1.Controllers
{
    public class StartupController : ApiController
    {

        // GET: api/Startup
        [Route("api/Startup/GetForumTables")]
        public string GetforumTables()
        {
            return "Server running";
        }
    }
}