using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using module_12_rest_api;
using module_12_rest_api.Daos;
using module_12_rest_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace module_12_rest_api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class SellerController : ControllerBase
    {
        private readonly SellerDao _context;

        public SellerController(SellerDao context)
        {
            _context = context;


            if (context.Sellers.Any()) return;

            SellerSeed.InitData(context);


        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Product>> GetSellers([FromQuery] string SellerID)
        {
            var result = _context.Sellers as IQueryable<Seller>;

            if (!string.IsNullOrEmpty(SellerID))
            {
                result = result.Where(p => p.SellerID.StartsWith(SellerID, StringComparison.InvariantCultureIgnoreCase));
            }

            return Ok(result
                .OrderBy(p => p.SellerID)
                .Take(15));
        }

    }
}
