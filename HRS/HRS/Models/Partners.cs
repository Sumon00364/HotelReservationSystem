using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    public class Partners
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=4)]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(129)]
        [DataType(DataType.EmailAddress)]
        [Display(Name="E-Mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(DataType.Url)]
        [Display(Name="Web-Site")]
        public string Website { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Logo")]
        public string PartnerImage { get; set; }

        [StringLength(250, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=20)]
        public string Description { get; set; }

    }
}