using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAPI
{
    public class SoldItem
    {
        public string ArticleNumber { get; set; }
        public double SalesPrice { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
