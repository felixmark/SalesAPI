using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace SalesAPI.Controllers {

    public class StatisticsController : Controller {

        const string ROUTE = "api/statistics";

        // GET api/numsales
        [Route(ROUTE)]
        [HttpGet]
        public JObject Get() {

            // Get the revenue grouped by articles
#if DEBUG
            // Print GET Request
            Console.WriteLine("GET " + ROUTE);
#endif
            try {
                return new JObject(new JProperty("status", 0), new JProperty("articles", Database.getStatistics()));
            } catch (Exception e) {
                return new JObject(new JProperty("status", 1), new JProperty("description", e.Message));
            }
        }
    }
}
