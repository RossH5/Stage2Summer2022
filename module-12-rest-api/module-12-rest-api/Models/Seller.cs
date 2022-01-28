using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace module_12_rest_api.Models
{
    public class Seller
    {
        [Key]
        [Required]
        [Display(Name = "sellerId")]
        public string SellerID { get; set; }

        [Required]
        [Display(Name = "sellerName")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "inventory")]
        public virtual List<SellerProduct> Inventory { get; set; }



        
    }
}
