using Catalog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog2.Controllers
{
    public class PostController : Controller
    {

        private readonly IProductService productService;

        public PostController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var products = productService.GetProductList();
            return View(products);
        }

        public IActionResult Sil()
        {
            var products = productService.GetProductList();
            return View(products);
        }

        public IActionResult Sil2()
        {
            return View();
        }

        public IActionResult Sil3()
        {
            var products = productService.GetProductList();
            return View(products);
        }



    }
}
