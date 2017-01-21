using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    public class Images
    {
        public Images()
        {
            this.Gallary = new HashSet<Gallary>();
            this.Partners = new HashSet<Partners>();
            this.Services = new HashSet<Services>();
            this.Hotel = new HashSet<Hotel>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage="The {0} must be at least {2} characters.")]
        [Display(Name="Image Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(DataType.ImageUrl)]
        [Display(Name="Image OR URL")]
        public string Url { get; set; }

        [StringLength(250, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=30)]
        public string Description { get; set; }

        public virtual ICollection<Services> Services { get; set; }
        public virtual ICollection<Gallary> Gallary { get; set; }
        public virtual ICollection<Hotel> Hotel { get; set; }
        public virtual ICollection<Partners> Partners { get; set; }
        
    }
}