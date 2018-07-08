using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RT.DataAccess;
using RT.DataAccess.Db;
using RT.Entity.Entity;
using RT.Entity.Interfaces;
using RT.Services.Interfaces;
using RT.Utils.ModelError;

namespace RT.Services
{
    public class GenericRestaurantService<T> : GenericService<T>  where T : class, IRestaurantDbEntity
    {
        private IValidationDictionary _validationDictionary;

        public GenericRestaurantService(IValidationDictionary validationDictionary)
        {
            _validationDictionary = validationDictionary;
            EntityRepo = new GenericRepository<T>(new ApplicationContext());
        }

        public bool Create(T entity)
        {
            try
            {
                var result = base.Create(entity);                
                if (result.Succeeded) return true;
                else return false;
            }
            catch (Exception ex)
            {
                HandleError(ex,entity);
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                var result = base.Update(entity);
                if (result.Succeeded) return true;
                else return false;
            }
            catch (Exception ex)
            {
                HandleError(ex,entity);
                return false;
            }
        }

        public bool Update(params T[] entity)
        {
            try
            {
                var result = base.Update(entity);
                if (result.Succeeded) return true;
                else return false;
            }
            catch (Exception ex)
            {
                HandleError(ex,null);
                return false;
            }
        }

        public bool Delete(object id)
        {
            try
            {
                var result = base.Delete(id);
                if (result.Succeeded) return true;
                else return false;
            }
            catch (Exception ex)
            {
                HandleError(ex, null);
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                var result = base.Delete(entity);
                if (result.Succeeded) return true;
                else return false;
            }
            catch (Exception ex)
            {
                HandleError(ex, entity);
                return false;
            }
        }

        public bool Delete(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var result = base.Delete(predicate);
                if (result.Succeeded) return true;
                else return false;
            }
            catch (Exception ex)
            {
                HandleError(ex,null);
                return false;
            }
        }
    }
}
