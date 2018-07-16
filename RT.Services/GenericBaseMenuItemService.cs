using RT.Utils.ModelError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RT.DataAccess;
using RT.DataAccess.Db;
using RT.Entities.Interfaces;

namespace RT.Services
{
    public class GenericBaseMenuItemService<T> : GenericService<T> where T : class, IRestaurantDbEntity
    {
        private IValidationDictionary _validationDictionary;

        public GenericBaseMenuItemService(IValidationDictionary validationDictionary)
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
                return false;
            }
            catch (Exception ex)
            {
                HandleError(ex, entity);
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                var result = base.Update(entity);
                if (result.Succeeded) return true;
                return false;
            }
            catch (Exception ex)
            {
                HandleError(ex, entity);
                return false;
            }
        }

        public bool Update(params T[] entity)
        {
            try
            {
                var result = base.Update(entity);
                if (result.Succeeded) return true;
                return false;
            }
            catch (Exception ex)
            {
                HandleError(ex, null);
                return false;
            }
        }

        public bool Delete(object id)
        {
            try
            {
                var result = base.Delete(id);
                if (result.Succeeded) return true;
                return false;
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
                return false;
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
                return false;
            }
            catch (Exception ex)
            {
                HandleError(ex, null);
                return false;
            }
        }
    }
}
