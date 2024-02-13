using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Core.Bl;
using Marketplace.Core.Commons;
using Marketplace.Core.Model;

namespace Marketplace.Core.Util
{
    public static class PaginationUtil
    {
        public static ResponsePagination<List<T>> createPagedReponse<T>(List<T> pagedData, Pagination pagination, int totalOffers, 
            IUrlBl urlBl, 
            string route)
        {
            var respose = new ResponsePagination<List<T>>(pagedData, pagination.pageNumber, pagination.pageSize);
            var numberPages = ((double)totalOffers / (double)pagination.pageSize);
            int numberPagesFinal = Convert.ToInt32(Math.Ceiling(numberPages));
            
            respose.nextPage =
                pagination.pageNumber >= 1 && pagination.pageNumber < numberPagesFinal
                ? urlBl.getPageUrl(new Pagination(pagination.pageNumber + 1, pagination.pageSize), route)
                : null;
            respose.previousPage =
                pagination.pageNumber - 1 >= 1 && pagination.pageNumber <= numberPagesFinal
                ? urlBl.getPageUrl(new Pagination(pagination.pageNumber - 1, pagination.pageSize), route)
                : null;

            respose.firstPage = urlBl.getPageUrl(new Pagination(1, pagination.pageSize), route);
            respose.lastPage = urlBl.getPageUrl(new Pagination(numberPagesFinal, pagination.pageSize), route);
            respose.numberPages = numberPagesFinal;
            respose.totalRecords = totalOffers;

            return respose;
        }

    }
}
