using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductCategories.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        

        public IEnumerable<Product> Products { get; set; }
    }

    public class ProductContext
        : DbContext
    {
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Product> Products { get; set; }

    }
}