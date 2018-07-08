using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT.Utils.ModelError
{
    public interface IValidationDictionary
    {
        void AddError(string key, string errorMassage);
        bool IsValid { get; }
    }
}
