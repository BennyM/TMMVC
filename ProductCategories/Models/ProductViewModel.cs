using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductCategories.Models
{
    public class ProductViewModel
    {
        [StringLength(50)]
        public string Name { get; set; }

        [Display(ResourceType = typeof(LocalizedValues), Name = "CategoryName")]
        public int SelectedCategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }

    }
}