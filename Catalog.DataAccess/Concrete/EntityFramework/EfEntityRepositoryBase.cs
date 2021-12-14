using Catalog.DataAccess.Abstract;
using Catalog.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Catalog.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        CatalogContext context = new CatalogContext();

        public void Delete(T k)
        {
            var deletedEntity = context.Entry(k);
            deletedEntity.State = EntityState.Deleted;
            //context.Set<T>().Remove(k);
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().SingleOrDefault(filter);
        }

        public T Add(T k)
        {
            var addedEntity = context.Entry(k);
            addedEntity.State = EntityState.Added;
            //context.Set<T>().Add(k);
            context.SaveChanges();
            return k;
        }

        public List<T> List(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList();
        }

        public T Update(T c)
        {
            var updatedEntity = context.Entry(c);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
            return c;
        }





    }
}

