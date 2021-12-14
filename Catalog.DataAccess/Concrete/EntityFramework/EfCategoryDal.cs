using Catalog.DataAccess.Abstract;
using Catalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal  : EfEntityRepositoryBase<Category> , ICategoryDal
    {

    }
}
