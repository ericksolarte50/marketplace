using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Commons
{
    public class Response<T>
    {

        public Response() {

        }

        public Response(T data)
        {
            success = true;
            message = string.Empty;
            errors = null;
            info = data;
        }
        public T info { get; set; }
        public bool success { get; set; }
        public string[] errors { get; set; }
        public string message { get; set; }

    }
}
