using Catalog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetProductList();
        Product ProductAdd(Product c);
        Product GetByID(int id);

        void ProductDelete(Product c);
        Product ProductUpdate(Product c);
        List<Product> ProductListByCategoryId(int id);
        int NumberOfProductByCategory(int id);
    }
}
