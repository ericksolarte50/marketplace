using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Core.Bl;
using Marketplace.Core.Dal;
using Marketplace.Core.Model;

namespace Marketplace.Bl
{
    public class OfferBl : IOfferBl
    {

        private IOfferRepository offerRepository;

        public OfferBl(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public async Task<int> countOffers()
        {
            return await this.offerRepository.countOffers().ConfigureAwait(false);
        }

        public async Task<List<Offer>> getPaginationOffersAsync(int page, int size)
        {
            page = (page - 1) * size;
            return await this.offerRepository.getPageOffersAsync(page, size).ConfigureAwait(false);
        }
    }
}
