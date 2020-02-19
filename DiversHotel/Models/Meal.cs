using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DiversHotel.Models
{
    public class Meal
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Meal plane")]
        public string Name { get; set; }
    }
}
