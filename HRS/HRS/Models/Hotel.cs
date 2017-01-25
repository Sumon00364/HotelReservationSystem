using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    public class Hotel
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=4)]
        [Display(Name="Hotel Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(200, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=5)]
        [Display(Name="Hotel Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(129)]
        [DataType(DataType.EmailAddress)]
        [Display(Name="E-Mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Phone Number")]
        public string Phone { get; set; }

        [Required]
        [StringLength(50, ErrorMessage="The {0} must be at least {2} digits.", MinimumLength=14)]
        [Display(Name="Mobile Number")]
        public string Mobile { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="Fax")]
        public string Fax { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(DataType.Url)]
        [Display(Name="Web-Site")]
        public string Website { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(DataType.ImageUrl)]
        [Display(Name = " Hotel Logo")]
        public string HotelImage { get; set; }

        [StringLength(250, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=20)]
        [Display(Name="Hotel Description")]
        public string Description { get; set; }

    }
}