using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    
    public class Price
    {
        public int Id { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        DateTime PriceStartDate { get; set; }
        [Required]
        DateTime PriceEndDate { get; set; }
        [Required]
        public Book Book { get; set; }
    }
}
