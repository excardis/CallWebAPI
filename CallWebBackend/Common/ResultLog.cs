using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallWebBackend.Common
{
    public class ResultLog
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public object ReturnObject { get; set; }

        public ResultLog()
        {

        }

        public ResultLog(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public bool IsSuccess()
        {
            return Code == 0;
        }
    }
}
