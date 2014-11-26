using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductCategories.Models
{
    public class ProductIndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}