using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEjemplo.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public bool IsEnable { get; set; }
    }
}