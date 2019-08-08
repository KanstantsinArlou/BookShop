using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Price
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        DateTime PriceStartDate { get; set; }
        DateTime PriceEndDate { get; set; }

        public Book Book { get; set; }
    }
}
