using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    public class User
    {
        public User()
        {
            this.Role = new HashSet<Role>();
            this.BookingInfo = new HashSet<BookingInfo>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(10, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=3)]
        [Display(Name="User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(129)]
        [DataType(DataType.EmailAddress)]
        [Display(Name="E-Mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=8)]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="The password and comfirm password do not match.")]
        [Display(Name="Confirm Password")]
        public string ConfirmPassword { get; set; }
        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<BookingInfo> BookingInfo { get; set; }
    }
}