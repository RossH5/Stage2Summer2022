using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace module_12_rest_api.Models
{
    public class SellerProduct
    {
        [Key]
        [Required]
        [Display(Name = "productNumber")]
        public string ProductNumber { get; set; }

        [Required]
        [Display(Name = "Product")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Stock")]
        public int Stock { get; set; }
    }
}
