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

        public ICollection<Tag> Tags { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Product> Products { get; set; }
    }

    public class ProductContext
        : DbContext
    {
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Product> Products { get; set; }

        public IDbSet<Tag> Tags{get;set;}

        

    }

    public class MyInitializer
        : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            Tag discountTag = new Tag { Name = "discount" };
            Tag newTag = new Tag { Name = "new" };
            Tag saleTag = new Tag { Name = "sale" };

            Category drank = new Category { Name = "Drank" };
            Category eten = new Category { Name = "Eten" };

            Product cola = new Product { Category = drank, Name = "Cola", Tags = new List<Tag> { discountTag, newTag} };
            Product duvel = new Product { Category = drank, Name = "Duvel", Tags = new List<Tag> { saleTag } };
            Product hamburger = new Product { Category = eten, Name = "Hamburger", Tags = new List<Tag> { newTag } };

            context.Products.Add(cola);
            context.Products.Add(duvel);
            context.Products.Add(hamburger);
            context.SaveChanges();

        }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}