using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DiversHotel.Models
{
    public class MealPrice
    {
        public int Id { get; set; }
        [Required]
        public int MealId { get; set; }
        [Required]
        public int MealSeasonID { get; set; }
        [Required]
        [Display(Name="Price")]
        public int Price { get; set; }

        public Meal Meal { get; set; }
        public MealSeason MealSeason { get; set; }
    }
}
