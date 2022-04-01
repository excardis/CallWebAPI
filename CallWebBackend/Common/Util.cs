using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallWebBackend.Common
{
    public class Util
    {
        public static string ExtractExceptionMessage(Exception ex)
        {
            string message = "";
            Exception currentException = ex;

            while (currentException.InnerException != null)
            {
                message += currentException.InnerException.Message + "\n";
                currentException = currentException.InnerException;
            }

            message += ex.Message;

            return message;
        }
    }
}
