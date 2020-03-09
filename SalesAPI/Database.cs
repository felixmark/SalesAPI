using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace SalesAPI
{
    public class Database
    {
        public static LinkedList<SoldItem> soldItemList = new LinkedList<SoldItem>();

        public static bool addSoldItem(SoldItem soldItem) {
            // Check if soldItem is null and return if so
            if (soldItem == null) return false;

            // Add the current DateTime to the sold item
            soldItem.SaleDate = DateTime.Now;

            // Add sold Item to the "Database"
            soldItemList.AddLast(soldItem);
            return true;
        }

        public static int getNumberOfSoldArticles(DateTime when) {
            int numSales = 0;

            // count all sales
            foreach (SoldItem soldItem in soldItemList) {
                if (soldItem.SaleDate.Date == when.Date) {
                    numSales++;
                }
            }

            return numSales;
        }

        public static double getTotalRevenue(DateTime when) {
            double totalRevenue = 0;

            // build sum of all revenues
            foreach (SoldItem soldItem in soldItemList) {
                if (soldItem.SaleDate.Date == when.Date) {
                    totalRevenue += soldItem.SalesPrice;
                }
            }

            return totalRevenue;
        }

        public static JArray getStatistics() {
            JArray jsonArray = new JArray();
            Dictionary<string, double> revenueByArticle = new Dictionary<string, double>();

            // Get revenue per article
            foreach (SoldItem soldItem in soldItemList) {

                // Add article to dictionary or add revenue to total revenue
                if (!revenueByArticle.ContainsKey(soldItem.ArticleNumber)) {
                    revenueByArticle.Add(soldItem.ArticleNumber, soldItem.SalesPrice);
                } else {
                    double currentRevenue = 0;

                    if (revenueByArticle.TryGetValue(soldItem.ArticleNumber, out currentRevenue)) {
                        revenueByArticle[soldItem.ArticleNumber] = currentRevenue + soldItem.SalesPrice;
                    } else {
                        throw new Exception("There was an error adding revenue to total revenue of article "+soldItem.ArticleNumber+".");
                    }
                }
            }

            foreach (KeyValuePair<string,double> articleObject in revenueByArticle) {
                jsonArray.Add(new JObject(new JProperty("articleNumber", articleObject.Key), new JProperty("revenue", articleObject.Value)));
            }

            return jsonArray;
        }
    }
}
