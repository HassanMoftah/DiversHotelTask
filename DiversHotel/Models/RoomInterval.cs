using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DiversHotel.Models
{
    public class RoomInterval
    {

        public int Id { get; set; }

        [Required]
        [Display (Name ="From")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "To")]
        public DateTime EndDate { get; set; }
    }
}
