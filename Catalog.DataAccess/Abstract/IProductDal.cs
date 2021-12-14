using Catalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using NPOI.SS.Formula.Functions;

namespace Catalog.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<Product> GetList(Expression<Func<Product , bool>> filter = null);  // kategoriyle birlikte getirir        
        Product GetProduct(Expression<Func<Product, bool>> filter);
    }
}
