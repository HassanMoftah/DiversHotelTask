using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DiversHotel.Models
{
    public class MealSeason
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Season")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime EndDate { get; set; }
    }
}
