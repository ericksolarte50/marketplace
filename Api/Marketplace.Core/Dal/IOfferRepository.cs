using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Core.Model;

namespace Marketplace.Core.Dal;

public interface IOfferRepository
{    
    Task<List<Offer>> getPageOffersAsync(int page, int size);

    Task<int> countOffers();

}