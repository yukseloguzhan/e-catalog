using Catalog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Catalog.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> List(Expression<Func<T, bool>> filter = null);  // isterse filtre vermeyebilir
        T Add(T k);
        T Update(T k);
        void Delete(T k);
        T Get(Expression<Func<T, bool>> filter);



    }
}
