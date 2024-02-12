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
            var totalPages = ((double)totalOffers / (double)pagination.pageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            
            respose.NextPage =
                pagination.pageNumber >= 1 && pagination.pageNumber < roundedTotalPages
                ? urlBl.getPageUrl(new Pagination(pagination.pageNumber + 1, pagination.pageSize), route)
                : null;
            respose.PreviousPage =
                pagination.pageNumber - 1 >= 1 && pagination.pageNumber <= roundedTotalPages
                ? urlBl.getPageUrl(new Pagination(pagination.pageNumber - 1, pagination.pageSize), route)
                : null;

            respose.FirstPage = urlBl.getPageUrl(new Pagination(1, pagination.pageSize), route);
            respose.LastPage = urlBl.getPageUrl(new Pagination(roundedTotalPages, pagination.pageSize), route);
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalOffers;

            return respose;
        }

    }
}
