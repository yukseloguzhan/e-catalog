using Catalog.Business.Abstract;
using Catalog.DataAccess.Abstract;
using Catalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalog.Business.Concrete
{
    public class ProductManager : IProductService
    {
        readonly IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public Product GetByID(int id)
        {
            return productDal.GetProduct(x=>x.Id == id);
        }

        public List<Product> GetProductList()
        {
            return productDal.GetList();
        }

        public int NumberOfProductByCategory(int id)
        {
            var list = productDal.List(x=>x.CategoryId == id);

            if (list == null)
            {
                return 0;
            }

            return list.Count();
        }

        public Product ProductAdd(Product c)
        {
            return productDal.Add(c);
        }

        public void ProductDelete(Product c)
        {
            productDal.Delete(c);
        }

        public List<Product> ProductListByCategoryId(int id)
        {
            return productDal.GetList(x=>x.CategoryId == id);

        }

        public Product ProductUpdate(Product c)
        {
            return productDal.Update(c);
        }
    }
}
