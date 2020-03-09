using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace SalesAPI.Controllers
{
    [Route("api")]
    public class DefintionController : Controller
    {
        [HttpGet]
        public ContentResult Get()
        {
            String path = @"Resources/index.html";
            return base.Content(System.IO.File.ReadAllText(path), "text/html");
        }
    }

    [Route("api/swagger")]
    public class SwaggerController : Controller {
        [HttpGet]
        public string Get() {
            String path = @"Resources/swagger.json";
            return System.IO.File.ReadAllText(path);
        }
    }
}
