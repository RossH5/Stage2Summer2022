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
        [Display(Name = "productName")]
        public string ProductName { get; set; }


        [Required]
        [Display(Name = "inStock")]
        public int InStock { get; set; }
    }
}
