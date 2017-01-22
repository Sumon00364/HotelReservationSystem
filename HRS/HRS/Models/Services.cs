using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    public class Services
    {
        public Services()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Display(Name="Logo")]
        public int ImageID { get; set; }
        [ForeignKey("ImageID")]
        public virtual Images Images { get; set; }

        [Required]
        [StringLength(50, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=3)]
        [Display(Name="Title")]
        public string Title { get; set; }

        [StringLength(250, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=20)]
        public string Description { get; set; }   
    }
}