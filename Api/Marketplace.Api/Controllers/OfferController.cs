using Marketplace.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Marketplace.Core.Bl;
using Marketplace.Core.Util;

namespace Marketplace.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private ILogger<OfferController> logger;

        private IOfferBl offerBl;

        private IUrlBl urlBl;

        public OfferController(ILogger<OfferController> logger
            , IOfferBl offerBl
            , IUrlBl urlBl
            )
        {
            this.logger = logger;
            this.offerBl = offerBl;
            this.urlBl = urlBl;
        }

        [HttpGet("~/offersPagination")]
        public async Task<IActionResult> getPagination([FromQuery] Pagination pagination)
        {
            List<Offer> result;

            try
            {
                result = await this.offerBl.getPaginationOffersAsync(pagination.pageNumber, pagination.pageSize).ConfigureAwait(false);
                var route = Request.Path.Value;
                int totalOffers = await this.offerBl.countOffers().ConfigureAwait(false);
                var responsePagination = PaginationUtil.createPagedReponse<Offer>(result, pagination, totalOffers, 
                    urlBl,
                    route);
                return this.Ok(responsePagination);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }
        }
    }
}
