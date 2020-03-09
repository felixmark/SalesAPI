using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace SalesAPI.Controllers {

    public class NumSalesController : Controller {

        const string ROUTE = "api/numsales";

        // GET api/numsales
        [Route(ROUTE)]
        [HttpGet]
        public JObject Get(string date = "") {

#if DEBUG
            // Print GET Request
            Console.WriteLine("GET " + ROUTE);
#endif

            try {
                DateTime dateTime = Program.formatStringToDateTime(date);
                return new JObject(
                    new JProperty("status", 0),
                    new JProperty("value", Database.getNumberOfSoldArticles(dateTime))
                );
            } catch (FormatException) {
                return new JObject(
                    new JProperty("status", 1),
                    new JProperty("description", "Date \"" + date + "\" has a wrong date format. (should be MM/DD/YYYY)")
                );
            }

        }
    }
}
