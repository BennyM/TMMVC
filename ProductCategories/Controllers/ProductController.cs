using ProductCategories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductCategories.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string cat)
        {
            var context = new ProductContext();
            IQueryable<Product> allProducts = context.Products;
            if(!string.IsNullOrWhiteSpace(cat))
            {
                allProducts = from p in context.Products
                              where p.Category.Name == cat
                              select p;
                
                allProducts = context.Products.Where(x => x.Category.Name == cat);
            }
            return View(allProducts);
        }

        public ActionResult Create()
        {
            var context = new ProductContext();
            var viewModel = new ProductViewModel();
            viewModel.Categories = new List<SelectListItem>();
            viewModel.Categories.Add(new SelectListItem() { Text = "Selecteer een categorie" });
            foreach(var category in context.Categories)
            {
                viewModel.Categories.Add(new SelectListItem{
                 Text = category.Name,
                  Value = category.Id.ToString(),
                   Selected = false
                });
            }


            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel product)
        {
            var context = new ProductContext();
            var newProduct = new Product();
            newProduct.Name = product.Name;
            newProduct.CategoryId = product.SelectedCategoryId;
            var dbContext = new ProductContext();
            dbContext.Products.Add(newProduct);
            
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}