using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallWebAPI.Model
{
    public class ApiBaseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
