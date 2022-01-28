using module_12_rest_api.Daos;
using module_12_rest_api.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace module_12_rest_api.Models
{
    public class SellerSeed
    {
        public static void InitData(SellerDao context)
        {
            var rnd = new Random();

            var adjectives = new[] { "Small", "Ergonomic", "Rustic",
                "Smart", "Sleek" };
            var materials = new[] { "Steel", "Wooden", "Concrete", "Plastic",
                "Granite", "Rubber" };
            var names = new[] { "Chair", "Car", "Computer", "Pants", "Shoes" };

            var sellernames =  new[] { "Walmart", "Target", "Lowe's",
                "Home Depot", "Sam's Club" };

            context.Sellers.AddRange(200.Times(x =>
            {
                var name = $"{sellernames[rnd.Next(0, 5)]}";
                var sellerId = $"{name.First()}{name.Last()}{x + 500, -3:000}".ToUpper();
                List<SellerProduct> inventory = new List<SellerProduct>();

                var itemsSold = rnd.Next(0, 3);
                for (int i = 0; i < itemsSold; i++)
                {
                    var radjective = adjectives[rnd.Next(0, 5)];
                    var rmaterial = materials[rnd.Next(0, 5)];
                    var rname = names[rnd.Next(0, 5)];
                    var productId = $"{rnd.Next(100, 999)}{rnd.Next(10, 99)}";

                    inventory.Add(new SellerProduct
                    {
                        ProductNumber =
                        $"{productId}{radjective.First()}{rmaterial.First()}{rname.First()}".ToUpper(),
                        ProductName =
                            $"{radjective} {rmaterial} {rname}",
                        InStock = rnd.Next(1, 15)
                    }) ;
                }

                return new Seller
                {
                    SellerID =
                        sellerId,
                    Name = name,
                    Inventory = inventory
                };
            }));

            context.SaveChanges();

        }
    }
}
