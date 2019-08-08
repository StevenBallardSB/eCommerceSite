using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Member
    {
        [StringLength(60)]
        [Required]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "That doesn't look like an email")]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[\d\w}+$", ErrorMessage = "Usernames can only contain A-Z, 0-9, and underscores")]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }


        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        // Make custom attribute in order to do a dynamic range finder.
        // [Required] - It's already required because DateTime is a structure (It's a value type)
        public DateTime DateOfBirth { get; set; }
    }
}
