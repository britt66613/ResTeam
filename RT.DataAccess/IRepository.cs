using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RT.Entities.Interfaces;

namespace RT.DataAccess
{
    public interface IRepository : IDisposable
    {
        void Save();
    }

    public interface IRepository<T> : IRepository where T : IEntity<int>
    {
        T Find(Expression<Func<T, bool>> expression);
        IEnumerable<T> Filter(Expression<Func<T, bool>> expression);
        IEnumerable<T> All();
        T FindByKey(object key);
        bool Contains(Expression<Func<T, bool>> predicate);
        T Create(T item); 
        void Update(T item); 
        void Delete(T item);
        void Delete(Expression<Func<T, bool>> predicate);
        void Save();  
    }
}
