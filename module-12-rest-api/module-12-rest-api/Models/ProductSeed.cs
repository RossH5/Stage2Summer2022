using module_12_rest_api.Daos;
using module_12_rest_api.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace module_12_rest_api.Models
{
    public static class ProductSeed
    {
        public static void InitData(ProductContext context)
        {
            var rnd = new Random();

            var adjectives = new[] { "Small", "Ergonomic", "Rustic",
                "Smart", "Sleek" };
            var materials = new[] { "Steel", "Wooden", "Concrete", "Plastic",
                "Granite", "Rubber" };
            var names = new[] { "Chair", "Car", "Computer", "Pants", "Shoes" };
            var departments = new[] { "Books", "Movies", "Music",
                "Games", "Electronics" };

            var reviewers = new[] { "Ross", "Joe", "Jon",
                "Sally", "Bob" };

            var reviewText = new[] { "This product is amazing", "This product is great", "This product is terrible",
                "This product is fantastic", "I don't know why I bought this" };

            var numberOfRelatedProducts = 0;
            var numberOfReviews = 0;

            context.Products.AddRange(500.Times(x =>
            {
                var adjective = adjectives[rnd.Next(0, 5)];
                var material = materials[rnd.Next(0, 5)];
                var name = names[rnd.Next(0, 5)];
                var department = departments[rnd.Next(0, 5)];
                var productId = $"{x,-3:000}";

                List<RelatedProduct> relatedProducts = new List<RelatedProduct>();

                var hasRelatedProduct = Convert.ToBoolean(rnd.Next(0, 2));
                if (hasRelatedProduct)
                {
                    var numberRelatedProducts = rnd.Next(0, 5);
                    for (int i = 0; i < numberRelatedProducts; i++)
                    {
                        numberOfRelatedProducts += 1;
                        var radjective = adjectives[rnd.Next(0, 5)];
                        var rmaterial = materials[rnd.Next(0, 5)];
                        var rname = names[rnd.Next(0, 5)];
                        var rdepartment = departments[rnd.Next(0, 5)];
                        var rproductId = $"{x + 500 + numberOfRelatedProducts,-3:000}";

                        relatedProducts.Add(new RelatedProduct
                        {
                            ProductNumber =
                                $"{rdepartment.First()}{rname.First()}{rproductId}",
                            Name = $"{radjective} {rmaterial} {rname}",
                            Price = (double)rnd.Next(1000, 9000) / 100,
                            Department = rdepartment
                        });
                    }

                }

                List<Review> reviews = new List<Review>();

                var hasReviews = Convert.ToBoolean(rnd.Next(0, 2));
                
                if (hasReviews)
                {
                    var numberReviews = rnd.Next(0, 5);
                    for (int i = 0; i < numberReviews; i++)
                    {
                        numberOfReviews += 1;
                        var author = reviewers[rnd.Next(0, 5)];
                        var number = rnd.Next(0, 5);
                        var textReview = reviewText[rnd.Next(0, 5)];


                        reviews.Add(new Review
                        {
                            ReviewAuthor =
                                $"{author}",
                            ReviewNumber = $"{numberOfReviews}",
                            ReviewRating = number,
                            ReviewText = $"{textReview}"
                        });
                    }

                }

                DateTime timestamp = Convert.ToDateTime(new TimeSpan(0, 0, 0, rnd.Next(86400)));
                return new Product
                {
                    ProductNumber =
                        $"{department.First()}{name.First()}{productId}",
                    Name = $"{adjective} {material} {name}",
                    Price = (double)rnd.Next(1000, 9000) / 100,
                    Department = department,
                    RelatedProducts = relatedProducts,
                    RelatedReviews = reviews,
                    Timestamp = timestamp
                };
            }));

            context.SaveChanges();
        }
    }
}
