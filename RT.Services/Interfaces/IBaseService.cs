using RT.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RT.Entities.Common;

namespace RT.Services.Interfaces
{
    public interface IBaseGetService<T> : IDisposable where T : class, IEntity<int>
    {
        IEnumerable<T> GetAll();

        T Find(Expression<Func<T, bool>> predicate);

        T GetByKey(object id);

        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);

        bool Contains(Expression<Func<T, bool>> predicate);
    }    

    public interface IBaseService<T> : IBaseGetService<T> where T : class, IEntity<int>
    {
        ServiceResult<T> Create(T entity);

        ServiceResult Update(T entity);

        ServiceResult Update(params T[] entities);

        ServiceResult Delete(object id);

        ServiceResult Delete(T entity);

        ServiceResult Delete(Expression<Func<T, bool>> predicate);
    }
}
