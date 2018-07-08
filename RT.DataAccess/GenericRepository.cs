using RT.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace RT.DataAccess
{
    public abstract class GenericRepository : IRepository
    {
        protected DbContext Context { get; set; }

        private bool _disposed;

        public virtual void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                Context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public class GenericRepository<T> : GenericRepository, IRepository<T> where T : class, IEntity<int>
    {
        protected DbSet<T> DbSet { get; set; }

        public GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public IEnumerable<T> All()
        {
            using (var context = Context)
            {
                var dbSet = context.Set<T>();                
                return dbSet.ToList();
            }
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> expression = null)
        {
            using (var context = Context)
            {
                var dbSet = context.Set<T>();                 
                return expression != null ? dbSet.Where(expression).ToList() : dbSet.ToList(); ;
            }
        }

        public T Find(Expression<Func<T, bool>> expression)
        {
            using (var context = Context)
            {
                var dbSet = context.Set<T>();
                return dbSet.FirstOrDefault(expression);
            }
        }

        public T FindByKey(object key)
        {
            using (var context = Context)
            {
                var dbSet = context.Set<T>();
                return dbSet.Find(key);
            }
        }

        public virtual bool Contains(Expression<Func<T, bool>> predicate)
        {
            return predicate == null ? DbSet.Any() : DbSet.Any(predicate);
        }

        public virtual T Create(T item)
        {
            var result = DbSet.Add(item);
            Context.SaveChanges();
            return result;
        }

        public virtual void Update(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public virtual void Delete(T item)
        {
            DbSet.Remove(item);
            Context.SaveChanges();
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var objects = Filter(predicate);
            if (objects.Any()) DbSet.RemoveRange(objects);
        }
    }
}
