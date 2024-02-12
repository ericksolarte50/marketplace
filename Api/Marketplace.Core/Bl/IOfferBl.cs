using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Core.Model;

namespace Marketplace.Core.Bl
{
    public interface IOfferBl
    {
        Task<List<Offer>> getPaginationOffersAsync(int page, int size);

        Task<int> countOffers();
    }
}
