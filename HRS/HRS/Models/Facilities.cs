using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    public class Facilities
    {
        public Facilities()
        {
            this.RoomType = new HashSet<RoomType>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage="The {0} must be at least {2} characters.")]
        [Display(Name="Facility Name")]

        public string Name { get; set; }
        [StringLength(250, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=20)]
        public string Description { get; set; }

        public virtual ICollection<RoomType> RoomType { get; set; }
    }
}