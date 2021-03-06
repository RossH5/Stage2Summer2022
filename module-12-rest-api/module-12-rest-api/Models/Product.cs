using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace module_12_rest_api.Models
{
    public class Product
    {
        [Key]
        [Required]
        [Display(Name = "productNumber")]
        public string ProductNumber { get; set; }

        [Required]
        [Display(Name = "name")]
        public string Name { get; set; }

        [Required]
        [Range(10, 90)]
        [Display(Name = "price")]
        public double? Price { get; set; }

        [Required]
        [Display(Name = "department")]
        public string Department { get; set; }

        [Required]
        [Display(Name = "timestamp")]
        public DateTime Timestamp { get; set; }

        [Required]
        [Display(Name = "relatedProducts")]
        public virtual List<RelatedProduct> RelatedProducts { get; set; }

        [Required]
        [Display(Name = "relatedReviews")]
        public virtual List<Review> RelatedReviews { get; set; }


    }
}
