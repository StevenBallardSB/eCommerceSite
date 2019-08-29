using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class SearchCriteria
    {
        public string Title { get; set; }

        public string Rating { get; set; }

        public double? minPrice { get; set; }

        public double? MaxPrice { get; set; }
    }
}
