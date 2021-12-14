using Catalog.DataAccess.Abstract;
using Catalog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Catalog.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product>, IProductDal
    {

        public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            using (var context = new CatalogContext())
            {
               
                return filter == null ? context.Products.Include(x => x.Category).ToList() : context.Products.Include(x => x.Category).Where(filter).ToList();

            }
        }

        public Product GetProduct(Expression<Func<Product, bool>> filter)
        {
            using(var context = new CatalogContext())
            {
                return context.Products.Include(x=>x.Category).SingleOrDefault(filter);
            }
            
        }

    }
}
