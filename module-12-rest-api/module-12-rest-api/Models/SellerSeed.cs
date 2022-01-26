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

            var sellernames =  new[] { "Walmart", "Target", "Lowes",
                "Home Depot", "Sam's Club" };

            context.Sellers.AddRange(50.Times(x =>
            {
                var name = $"{sellernames[rnd.Next(0, 5)]} {x,-3:000}";
                var sellerId = $"{x,-3:000}";
                List<SellerProduct> inventory = new List<SellerProduct>();

                var itemsSold = rnd.Next(0, 10);
                for (int i = 0; i < itemsSold; i++)
                {
                    var radjective = adjectives[rnd.Next(0, 5)];
                    var rmaterial = materials[rnd.Next(0, 5)];
                    var rname = names[rnd.Next(0, 5)];
                    var productId = $"{x,-3:000}";

                    inventory.Add(new SellerProduct
                    {
                        ProductNumber =
                        $"{name} {productId}",
                        Name =
                            $"{radjective} {rmaterial} {rname}",
                        Stock = 1
                    }) ;
                }

                return new Seller
                {
                    SellerID =
                        $"{name.First()}{name.First()}{sellerId}",
                    Name = $"{name}",
                    Inventory = inventory
                };
            }));

            context.SaveChanges();

        }
    }
}
