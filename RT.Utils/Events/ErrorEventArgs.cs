using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT.Utils.Events
{
    public class ErrorEventArgs : EventArgs
    {
        public Exception Exception { get; set; }

        public string Message { get; set; }

        public ErrorEventArgs(Exception exception, string message)
        {
            Exception = exception;
            Message = message;
        }
    }
}
