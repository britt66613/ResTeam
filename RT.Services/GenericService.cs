using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RT.DataAccess;
using RT.Entities.Common;
using RT.Entities.Interfaces;
using RT.Services.Interfaces;
using RT.Utils.Events;

namespace RT.Services
{
    public class GenericService : IDisposable
    {
        private bool _disposed;

        public static EventHandler<ErrorEventArgs> OnError { get; set; }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if(_disposed) return;
            _disposed = true;
        }
    }

    public abstract class GenericService<T> : GenericService, IBaseService<T> where T : class, IEntity<int>
    {
        protected IRepository<T> EntityRepo;

        public virtual IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var result = EntityRepo.Filter(predicate);
                return result;
            }
            catch (Exception ex)
            {
                HandleError(ex,null);
                throw;
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                var result = EntityRepo.All();
                return result;
            }
            catch (Exception ex)
            {
                HandleError(ex, null);
                throw;
            }
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var result = EntityRepo.Find(predicate);
                return result;
            }
            catch (Exception ex)
            {
                HandleError(ex, null);
                throw;
            }
        }

        public virtual T GetByKey(object id)
        {
            try
            {
                var result = EntityRepo.FindByKey(id);
                return result;
            }
            catch (Exception ex)
            {
                HandleError(ex, null);
                throw;
            }
        }

        public virtual bool Contains(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var result = EntityRepo.Contains(predicate);
                return result;
            }
            catch (Exception ex)
            {
                HandleError(ex, null);
                throw;
            }
        }

        public virtual ServiceResult<T> Create(T entity)
        {
            try
            {
                if(entity == null) throw new ArgumentException(nameof(entity));
                var result = new ServiceResult<T>();
                var queryResult = EntityRepo.Create(entity);
                result.Result = queryResult;
                return result;
            }
            catch (Exception ex)
            {
                HandleError(ex, entity);
                return  new ServiceResult<T>(ex);
            }
        }

        public virtual ServiceResult Update(T entity)
        {
            try
            {
                EntityRepo.Update(entity);
                return new ServiceResult();
            }
            catch (Exception ex)
            {
                HandleError(ex,entity);
                return  new ServiceResult(ex);
            }    
        }

        public virtual ServiceResult Update(params T[] entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    EntityRepo.Update(entity);
                }
                return new ServiceResult();
            }
            catch (Exception ex)
            {
                HandleError(ex, null);
                return new ServiceResult(ex);
            }
        }

        public virtual ServiceResult Delete(T entity)
        {
            try
            {
                EntityRepo.Delete(entity);
                return new ServiceResult();
            }
            catch (Exception ex)
            {
                HandleError(ex, entity);
                return  new ServiceResult(ex);
            }
        }

        public virtual ServiceResult Delete(object id)
        {
            try
            {
                var queryResult = EntityRepo.FindByKey(id);

                if (queryResult == null)
                {
                    return new ServiceResult("Entity Not Found");
                }

                EntityRepo.Delete(queryResult);
                return new ServiceResult();
            }
            catch (Exception ex)
            {
                HandleError(ex, null);
                return new ServiceResult(ex);
            }
        }

        public virtual ServiceResult Delete(Expression<Func<T, bool>> predicate)
        {
            try
            {
                EntityRepo.Delete(predicate);
                return new ServiceResult();
            }
            catch (Exception ex)
            {
                HandleError(ex, null);
                return new ServiceResult(ex);
            }
        }

        public  void HandleError(Exception exception, T entity)
        {
            try
            {
                string error;
                try
                {
                    var entityString = entity != null ? JsonConvert.SerializeObject(entity) : string.Empty;
                    error = $"Error with: {typeof(T).Name} {entityString}";
                }
                catch (Exception e)
                {
                    error = "Error";
                }
                OnError?.Invoke(this, new ErrorEventArgs(exception, error));
            }
            catch 
            {
                OnError?.Invoke(this, new ErrorEventArgs(exception, "No entity details"));
            }
        }
    }
}
