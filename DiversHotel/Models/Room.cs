using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DiversHotel.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display (Name ="Room Type")]
        public string Name { get; set; }


        public int?  Count { get; set; }
        public int? ChilderenCount { get; set; }
        public int? AdultCount { get; set; }
    }
}
