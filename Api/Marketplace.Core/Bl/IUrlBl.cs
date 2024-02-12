using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Core.Model;

namespace Marketplace.Core.Bl;

public interface IUrlBl
{
     public Uri getPageUrl(Pagination pagination, string route);

}