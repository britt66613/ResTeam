using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT.Utils.Errors
{
    public class ErrorUtils
    {
        public static string GetErrorMessage(Exception e, string defaultException)
        {
            if (e.InnerException == null) return GetErrorMessage(e.InnerException, defaultException);
            return !String.IsNullOrEmpty(e.Message) ? e.Message : defaultException;
        }
    }
}
