using Catalog.Business.Abstract;
using Catalog.Business.FluentValidation;
using Catalog.DataAccess.Abstract;
using Catalog.Entities.Concrete;
using Catalog2.Models;
using Catalog2.Models.FluentValidator;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService  categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public IActionResult List(int id=1)
        {
            ICollection<Product> list ;

            if (id==1)
            {
                 list = productService.GetProductList();
            }
            else
            {
                 list = productService.ProductListByCategoryId(id);
            }

            return View(list);
        }

        public IActionResult DetailList(int id = 1)
        {
            ICollection<Product> list;

            if (id == 1)
            {
                list = productService.GetProductList();
            }
            else
            {
                list = productService.ProductListByCategoryId(id);
            }

            return View(list);
        }

        public IActionResult Detail(int id)
        {
            var product = productService.GetByID(id);

            if (product!=null)
            {
                return View(product);
            }
            else
            {
                return View();
            }

            
        }


        [HttpGet]
        public IActionResult Add()
        {
            SelectList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateProductModel productModel)
        {
            SelectList();

            Product product = new Product();


            CreateProductModelValidator validator = new CreateProductModelValidator();
            ValidationResult results = validator.Validate(productModel);

            if (results.IsValid)
            {
                if (productModel.ImageURL != null)
                {
                    var extension = Path.GetExtension(productModel.ImageURL.FileName);  // uzantı    // Ornek: resim.jpg yukledik extention=jpg
                    var imageName = Guid.NewGuid() + extension;   // yeni isim verdik
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Frontend2/ProductImages/", imageName);   // konum yol dosya yolu
                    var stream = new FileStream(location, FileMode.Create);  // akış  : dosyayı ilgili lokasyona oluşturmaya hazırım
                    productModel.ImageURL.CopyTo(stream);
                    product.ImageURL = imageName;
                }

                product.Code = productModel.Code;
                product.CategoryId = productModel.CategoryId;
                product.Description = productModel.Description;
                product.Installment = productModel.Installment;
                product.Title = productModel.Title;
                product.Status = productModel.Status;
                product.CreateDate = DateTime.Now;
                product.Price = productModel.Price;

                productService.ProductAdd(product);
                return RedirectToAction("List");
            }
            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }

            return View();

           
        }

        public IActionResult Delete(int id)
        {
            var entity = productService.GetByID(id);
            productService.ProductDelete(entity);
            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var entity = productService.GetByID(id);
            SelectList();
            return View(entity);

        }

        [HttpPost]
        public IActionResult Update(UpdateProductModel productModel)
        {
            SelectList();

            Product product = new Product();

            UpdateProductModelValidator validator = new UpdateProductModelValidator();
            ValidationResult results = validator.Validate(productModel);

            if (results.IsValid)
            {
                if (productModel.ImageURL != null)
                {
                    var extension = Path.GetExtension(productModel.ImageURL.FileName);  // uzantı    // Ornek: resim.jpg yukledik extention=jpg
                    var imageName = Guid.NewGuid() + extension;   // yeni isim verdik
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Frontend2/ProductImages/", imageName);   // konum yol dosya yolu
                    var stream = new FileStream(location, FileMode.Create);  // akış  : dosyayı ilgili lokasyona oluşturmaya hazırım
                    productModel.ImageURL.CopyTo(stream);
                    product.ImageURL = imageName;
                }

                product.Id = productModel.Id;
                product.Code = productModel.Code;
                product.CategoryId = productModel.CategoryId;
                product.Description = productModel.Description;
                product.Installment = productModel.Installment;
                product.Title = productModel.Title;
                product.Status = productModel.Status;
                product.CreateDate = DateTime.Now;
                product.Price = productModel.Price;

                productService.ProductUpdate(product);
                return RedirectToAction("List");

            }
            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }

            return View();



        }



        private void SelectList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "True", Value = "True", Selected = true });
            items.Add(new SelectListItem { Text = "False", Value = "False" });

            ViewBag.StatusType = items;

            List<SelectListItem> valueCategory = (from x in categoryService.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            ViewBag.valueCategory = valueCategory;

        }


    }
}
