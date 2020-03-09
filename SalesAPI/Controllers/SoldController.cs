using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace SalesAPI.Controllers {
    public class SoldController : Controller {

        const string ROUTE = "api/sold";
        
        // POST api/sold
        [Route(ROUTE)]
        [HttpPost]
        public JObject Post([FromBody] SoldItem soldItem) {

            // Add a new SoldItem to the "Database" 

#if DEBUG
            // Print POST Request
            Console.WriteLine("POST " + ROUTE);
#endif
            
            // When soldItem is not given or incorrect
            if (soldItem == null || soldItem.ArticleNumber == null || soldItem.ArticleNumber.Equals("")) {
                return new JObject(
                    new JProperty("status",1),
                    new JProperty("description","You have to provide a valid JSON Object of the article in the POST request body.For an example have a look at the documentation.")
                );
            }

            Database.addSoldItem(soldItem);

            return new JObject(
                    new JProperty("status", 0),
                    new JProperty("description", "Article " + soldItem.ArticleNumber + " was sold for " + soldItem.SalesPrice + "€.")
            );
        }
    }
}
