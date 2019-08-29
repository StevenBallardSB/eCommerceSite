using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class SearchCriteria
    {
        public string Title { get; set; }

        public string Rating { get; set; }

        [Display(Name = "Minimum Price")]
        [Range(0, double.MaxValue, ErrorMessage = "The minimum price must be a positive number")]
        public double? minPrice { get; set; }

        [Display(Name = "Maximum Price")]
        [Range(0, double.MinValue, ErrorMessage = "The maximum price must be a postivie number")]
        public double? MaxPrice { get; set; }

        /// <summary>
        /// all VideoGames found using the search criteria
        /// </summary>
        public List<VideoGame> Games { get; set; }
    }
}
