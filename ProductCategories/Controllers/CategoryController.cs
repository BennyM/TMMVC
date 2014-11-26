using ProductCategories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductCategories.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var context = new ProductContext();
            return View(context.Categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name)
        {
            var newCategory = new Category();
            newCategory.Name =name;
            var context = new ProductContext();
            context.Categories.Add(newCategory);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}