using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Models
{
    public class Product
    {
        public int id { get; set; }
        public string productTitle { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public string Image { get; set; }
    }
}