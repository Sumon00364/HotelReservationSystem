using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    public class Gallary
    {
        public Gallary()
        {
            this.Images = new HashSet<Images>();
            this.RoomType = new HashSet<RoomType>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=5)]
        [Display(Name="Gallary Title")]
        public string Title { get; set; }

        [StringLength(250, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=50)]
        public string Description { get; set; }

        public virtual ICollection<Images> Images { get; set; }
        public virtual ICollection<RoomType> RoomType { get; set; }
    }
}