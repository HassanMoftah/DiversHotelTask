using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiversHotel.Models;
using System.ComponentModel.DataAnnotations;
namespace DiversHotel.ViewModel
{
    public class UserViewModel
    {
        [Display(Name = "Room Types")]
        public int RoomId { get; set; }

        [Display(Name = "Meals Plans")]
        public int MealId { get; set; }
        [Required]
        public string County { get; set; }



        [Required(ErrorMessage = "name is required")]
        [StringLength(200)]
        [Display(Name = "Enter Your Name")]
        public string Name { get; set; }



        [EmailAddress(ErrorMessage = "Enter a Valid Email Address")]
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Enter Your Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "please enter a valid count")]
        [Display(Name = "Enter adult Count")]
        [Range(1, 100)]
        public int AdultCount { get; set; }



        [Range(0, 100)]
        [Required(ErrorMessage = "please enter a valid count")]

        [Display(Name = "Enter children Count")]
        public int ChildrenCount { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Meal> Meals { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Pick Check In Date")]
        [Required(ErrorMessage = "enter a valid date")]
        public DateTime CheckIn { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Pick Check Out Date")]
        [Required(ErrorMessage = "enter a valid date")]
        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CheckOut { get; set; }

        public List<string> AllCountries { get; set; }
        public static string min = DateTime.Now.AddDays(1).ToLongDateString();

    }
}