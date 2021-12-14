using Catalog.Business.Abstract;
using Catalog.DataAccess.Abstract;
using Catalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        readonly ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public Category CategoryAdd(Category entity)
        {
            return categoryDal.Add(entity);
        }

        public void CategoryDelete(Category entity)
        {
            categoryDal.Delete(entity);
        }

        public Category CategoryUpdate(Category entity)
        {
            return categoryDal.Update(entity);
        }

        public Category GetByID(int id)
        {
            return categoryDal.Get(x=>x.CategoryId == id);
        }

        public List<Category> GetCategoryList()
        {
            return categoryDal.List();
        }
    }
}
