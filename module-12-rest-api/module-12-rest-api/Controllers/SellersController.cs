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
    public class SellersController : ControllerBase
    {
        private readonly SellerDao _context;

        public SellersController(SellerDao context)
        {
            _context = context;


            if (_context.Sellers.Any()) return;

            SellerSeed.InitData(context);


        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Seller>> GetSellers([FromQuery] string SellerID)
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Seller> PostSeller([FromBody] Seller seller)
        {
            try
            {
                _context.Sellers.Add(seller);
                _context.SaveChanges();

                return new CreatedResult($"/sellers/{seller.SellerID.ToLower()}", seller);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }

        [HttpPut]
        [Route("{sellerId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Seller> PutSeller([FromRoute] string sellerId, [FromBody] Seller newSeller)
        {
            try
            {
                var sellerList = _context.Sellers as IQueryable<Seller>;
                var seller = sellerList.First(p => p.SellerID.Equals(sellerId));

                _context.Sellers.Remove(seller);
                _context.Sellers.Add(newSeller);
                _context.SaveChanges();

                return new CreatedResult($"/sellers/{newSeller.SellerID}", newSeller);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }


        [HttpDelete]
        [Route("{sellerId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Seller> DeleteSeller([FromRoute] string sellerId)
        {
            try
            {
                var sellerList = _context.Sellers as IQueryable<Seller>;
                var seller = sellerList.First(p => p.SellerID.Equals(sellerId));

                _context.Sellers.Remove(seller);
                _context.SaveChanges();

                return new CreatedResult($"/sellers/{seller.SellerID}", seller);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }
    }
}
