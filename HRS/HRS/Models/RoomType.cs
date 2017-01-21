using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    public class RoomType
    {
        public RoomType()
        {
            this.Facilities = new HashSet<Facilities>();
            
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Display(Name="Gallary")]
        public int GallaryID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=3)]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(DataType.ImageUrl)]
        [Display(Name="Image OR URL")]
        public string ImageUrl { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [StringLength(250, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=20)]
        public string Description { get; set; }

        public virtual ICollection<Facilities> Facilities { get; set; }
        public virtual Gallary Gallary { get; set; }
    }
}