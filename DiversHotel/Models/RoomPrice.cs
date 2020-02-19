using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DiversHotel.Models
{
    public class RoomPrice
    {
        public int Id { get; set; }
        [Required]
        public int RoomId  { get; set; }
        [Required]
        public int RoomIntervalId { get; set; }
        [Required]
        [Display(Name ="Price")]
        public int Price { get; set; }
        public Room Room { get; set; }
        public RoomInterval RoomInterval { get; set; }
        
    }
}
