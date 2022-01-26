using Microsoft.EntityFrameworkCore;
using module_12_rest_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace module_12_rest_api.Daos
{
    public class SellerDao : DbContext
    {
        public SellerDao(DbContextOptions<SellerDao> options) : base(options)
        {
        }

        public DbSet<Seller> Sellers { get; set; }
    }
}
