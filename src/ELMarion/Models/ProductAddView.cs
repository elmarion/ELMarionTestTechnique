using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELMarion.Models
{
    public class ProductAddView
    {
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }

        [Display(Name = "Product Stock-keeping unit")]
        public int ProductSKU { get; set; }
    }
}
