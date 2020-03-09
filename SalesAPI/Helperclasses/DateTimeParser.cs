using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI {

    public class DateTimeParser {

        public static DateTime formatStringToDateTime(string dateString = null) {

            // Format a given String in the format MM/DD/YYYY to a DateTime object

            // Parse date-only value with invariant culture.
            string format = "d";
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;

            if (dateString != null && !dateString.Equals("") && dateString != "") {
                // This may throw an exception!
                return DateTime.ParseExact(dateString, format, cultureInfo);
            } else {
                return DateTime.Today;
            }
        }
    }
}
