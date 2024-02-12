using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Core.Bl;
using Marketplace.Core.Dal;
using Marketplace.Core.Model;
using Microsoft.AspNetCore.WebUtilities;


namespace Marketplace.Bl
{
    public class UrlBl : IUrlBl
    {
        private string globalUrl;

        public UrlBl(string url)
        {
            globalUrl = url;
        }
        public Uri getPageUrl(Pagination pagination, string route)
        {

            var urlConcat = new Uri(string.Concat(globalUrl, route));
            var finalUrl = QueryHelpers.AddQueryString(urlConcat.ToString(), "pageNumber", pagination.pageNumber.ToString());
            finalUrl = QueryHelpers.AddQueryString(finalUrl, "pageSize", pagination.pageSize.ToString());
            return new Uri(finalUrl);
        }
    }
}
