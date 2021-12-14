using Catalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategoryList();
        Category CategoryAdd(Category entity);
        Category GetByID(int id);

        void CategoryDelete(Category entity);
        Category CategoryUpdate(Category entity);



    }
}
