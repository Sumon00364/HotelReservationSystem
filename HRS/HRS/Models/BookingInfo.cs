using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRS.Models
{
    public class BookingInfo
    {
        public BookingInfo()
        {

        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name="User Name")]
        public int UserID { get; set; }

        [Required]
        [StringLength(150, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=6)]
        [Display(Name="Full Name")]
        public string FullName { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name="Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(129)]
        [DataType(DataType.EmailAddress)]
        [Display(Name="E-Mail Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage="The {0} must be at least {2} digits", MinimumLength=14)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Phone Number")]
        public string Phone { get; set; }

        [Required]
        //[StringLength(50)]
        [DataType(DataType.Date)]
        [Display(Name="Check In Time")]
        public DateTime CheckInTime { get; set; }

        [Required]
        //[StringLength(50)]
        [DataType(DataType.Date)]
        [Display(Name="Check Out Time")]
        public DateTime CheckOutTime { get; set; }

        [StringLength(500, ErrorMessage="The {0} must be at least {2} characters.", MinimumLength=30)]
        public string Comments { get; set; }


        public virtual User User { get; set; }
    }
}