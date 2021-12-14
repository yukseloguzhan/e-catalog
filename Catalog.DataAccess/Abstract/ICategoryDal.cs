using Catalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DataAccess.Abstract
{
    public interface ICategoryDal  : IEntityRepository<Category>
    {

    }
}
