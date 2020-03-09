using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Globalization;

namespace SalesAPI
{
    public class Program
    {
        public static DateTime formatStringToDateTime(string dateString = null) {

            // Parse date-only value with invariant culture.
            string format = "d";
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            
            if (dateString != null && !dateString.Equals("") && dateString != "") {
                try {
                    return DateTime.ParseExact(dateString, format, cultureInfo);
                } catch (FormatException formatException) {
                    throw formatException;
                }
            } else {
                return DateTime.Today;
            }
        }

        public static void Main(string[] args)
        {
            Debug.AutoFlush = true;
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
