using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Core.Dal;
using Marketplace.Core.Model;

namespace Marketplace.Dal.Repositories;

public class OfferRepository : IOfferRepository
{
    private MarketplaceDb context;

    public OfferRepository()
    {
        context = new MarketplaceDb();
    }

    public async Task<int> countOffers()
    {
        return await context.countOffers();
    }

    public async Task<List<Offer>> getPageOffersAsync(int page, int size)
    {
        return await context.getPageOffersAsync(page, size);
    }
}