using Catalog.DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog2.Controllers
{
    public class Statistics : Controller
    {

        CatalogContext context = new CatalogContext();

        public IActionResult Index()
        {
            var productCount = context.Products.Count();
            ViewBag.productCount = productCount;

            var categoryCount = context.Catagories.Count();
            ViewBag.categoryCount = categoryCount;

            var expensiveProduct = context.Products.Max(x=>x.Price);
            ViewBag.expensiveProduct = expensiveProduct;

            var list = context.Products.GroupBy(x => x.Category.Name).Select(y=> new { filter=y.Key ,Count = y.Count() });
            var d = list.OrderByDescending(c => c.Count).FirstOrDefault();
            var mostProductsCategory = d.filter;
            var count = d.Count ;
            ViewBag.mostProductsCategory = mostProductsCategory;
            ViewBag.count = count;

            return View();
        }
    }
}
