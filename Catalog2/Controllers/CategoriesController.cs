using Catalog.Business.Abstract;
using Catalog.Business.FluentValidation;
using Catalog.Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog2.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
            
        }

        public IActionResult List()
        {
            var list = categoryService.GetCategoryList();
            return View(list);
        }


        [HttpGet]
        public IActionResult Add()
        {
            SelectStatus();
            return View();
        }

        private void SelectStatus()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "True", Value = "True", Selected = true });
            items.Add(new SelectListItem { Text = "False", Value = "False" });

            ViewBag.StatusType = items;
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            SelectStatus();

            CategoryValidator validator = new CategoryValidator();
            ValidationResult results = validator.Validate(category);

            if (results.IsValid)
            {
                categoryService.CategoryAdd(category);
                return RedirectToAction("List");
            }
            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName,x.ErrorMessage);
                }
            }

            return View();
        }


        public IActionResult Delete(int id)
        {
            var entity = categoryService.GetByID(id);
            categoryService.CategoryDelete(entity);
            return RedirectToAction("List");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var entity = categoryService.GetByID(id);
            SelectStatus();
            return View(entity);

        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            SelectStatus();
            CategoryValidator validator = new CategoryValidator();
            ValidationResult results = validator.Validate(category);

            if (results.IsValid)
            {
                categoryService.CategoryUpdate(category);
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

        public IActionResult Detail(int id)
        {
            
            return RedirectToAction("List","Products", new { id = id });
        }



    }
}
