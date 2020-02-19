using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiversHotel.Models;
using DiversHotel.ViewModel;
using DiversHotel.Data;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

namespace DiversHotel.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        
        public HomeController( ApplicationDbContext context)
        {
            _context =context;
        }
        [Authorize]
        public IActionResult Index()
        {

            var userView = new UserViewModel
            {
                Rooms = _context.Rooms.ToList(),
                Meals = _context.Meals.ToList(),
                AllCountries = Countries.GetCountrlist()
               

            };
           

            return View(userView);
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Save( UserViewModel userViewModel)
        {

            //||  //diable validation on date 
                //userViewModel.CheckIn > userViewModel.CheckOut ||
            //||  userViewModel.CheckIn <= DateTime.Now.Date ||
            //  userViewModel.CheckIn == userViewModel.CheckOut



            if (! ModelState.IsValid ||  userViewModel.CheckIn > userViewModel.CheckOut ||
              userViewModel.CheckIn == userViewModel.CheckOut)
                 {
                var userView = new UserViewModel
                {
                    Rooms = _context.Rooms.ToList(),
                    Meals = _context.Meals.ToList(),
                    AllCountries = Countries.GetCountrlist()


                };
                return View("Index", userView);
            }
            else
            {
                List<SingleUnitReservation> RoomUnitReservations= new List<SingleUnitReservation>();
                List<SingleUnitReservation> MealUnitReservations = new List<SingleUnitReservation>();
                var roomReservationDetails = (from roomInterval in _context.RoomIntervals
                                              join roomPrice in _context.RoomPrices
                                              on roomInterval.Id equals roomPrice.RoomIntervalId
                                              where roomPrice.RoomId == userViewModel.RoomId
                                              select new { roomInterval.StartDate, roomInterval.EndDate, roomPrice.Price }).ToList();

                var mealResrvationDetails= (from mealSeason in _context.MealSeasons
                                            join mealPrice in _context.MealPrices
                                            on mealSeason.Id equals mealPrice.MealSeasonID
                                            where mealPrice.MealId == userViewModel.MealId
                                            select new { mealSeason.StartDate,mealSeason.EndDate, mealPrice.Price }).ToList();

                foreach( var row in roomReservationDetails)
                {
                    RoomUnitReservations.Add(new SingleUnitReservation( row.StartDate, row.EndDate, row.Price));
                        
                }
                foreach (var row in mealResrvationDetails)
                {
                    MealUnitReservations.Add(new SingleUnitReservation(row.StartDate, row.EndDate, row.Price));

                }
                Reservation reservation = new Reservation(RoomUnitReservations
                    , MealUnitReservations, userViewModel.AdultCount, userViewModel.ChildrenCount, userViewModel.CheckIn,
                    userViewModel.CheckOut);
                int Cost = reservation.GetReservationTotal();
                if (Cost == -1)
                {
                    return RedirectToAction("Error");
                }
                else
                {
                    CostViewModel costViewModel = new CostViewModel(Cost, "Enjoy your Vacation!");
                    return View("Success", costViewModel);
                }
            }

            
        }
    }
}
