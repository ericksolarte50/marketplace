using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Commons
{
    public class ResponsePagination<T> : Response<T>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public Uri firstPage { get; set; }
        public Uri lastPage { get; set; }
        public int numberPages { get; set; }
        public int totalRecords { get; set; }
        public Uri nextPage { get; set; }
        public Uri previousPage { get; set; }
        public ResponsePagination(T info, int pageNumber, int pageSize)
        {
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
            this.info = info;
            this.message = null;
            this.success = true;
            this.errors = null;
        }
    }
}
