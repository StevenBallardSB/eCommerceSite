using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    /// <summary>
    /// Represents a single user
    /// </summary>
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        /// <summary>
        /// The users full name
        /// </summary>
        [StringLength(60)]
        [Required]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        /// <summary>
        /// The users Email address
        /// </summary>
        [Required]
        [StringLength(100)]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "That doesn't look like an email")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The users username
        /// </summary>
        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[\d\w}+$", ErrorMessage = "Usernames can only contain A-Z, 0-9, and underscores")]
        public string Username { get; set; }

        /// <summary>
        /// The users password
        /// </summary>
        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// The date of birth for the user. Time is ignored
        /// </summary>
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        // Make custom attribute in order to do a dynamic range finder.
        // [Required] - It's already required because DateTime is a structure (It's a value type)
        public DateTime DateOfBirth { get; set; }
    }
}
