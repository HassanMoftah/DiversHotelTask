using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiversHotel.Models
{
    public class Reservation
    {
        private int AdultCount { get; set; }
        private int ChildCount { get; set; }
        private List<SingleUnitReservation> RoomIntervalAndPrice { get; set; }
        private List<SingleUnitReservation> MealIntervalAndPrice { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        private int NofDays { get; set; }

        public Reservation(List<SingleUnitReservation> rooms,List<SingleUnitReservation> meals,int adultCount,int childCount,DateTime s,DateTime e)
        {
            this.CheckIn = s;
            this.CheckOut = e;
            this.RoomIntervalAndPrice = rooms;
            this.MealIntervalAndPrice = meals;
            this.AdultCount = adultCount;
            this.ChildCount = childCount;
            
        }
        public int GetReservationTotal ()
        {
            int totalRoomsCount = this.CaculateTotalRooms(this.AdultCount, this.ChildCount);
            int totalPeoplesCount = this.AdultCount + this.ChildCount;

            int RoomsCost = this.CaclculateUnitsCost(this.RoomIntervalAndPrice, this.CheckIn, this.CheckOut, totalRoomsCount);
            int MealsCost = this.CaclculateUnitsCost(this.MealIntervalAndPrice, this.CheckIn, this.CheckOut, totalPeoplesCount);
            if (RoomsCost == -1 || MealsCost == -1)
                return -1;
            else
                return (RoomsCost + MealsCost);
        }

        private int CaculateTotalRooms(int adultCount,int childCount )
        {
            int RoomBasedOnAdults = adultCount / 2 + adultCount % 2;
            int childAvailablePlaces = RoomBasedOnAdults * 2 + (RoomBasedOnAdults * 2 - adultCount);
            if(childAvailablePlaces>=childCount)
            {
                return RoomBasedOnAdults;
            }
            else
            {
                int RoomBasesOnChilds = ((childCount - childAvailablePlaces) / 2) + ((childCount - childAvailablePlaces) % 2);
                return (RoomBasedOnAdults + RoomBasesOnChilds);
            }
        }
        private int CaclculateUnitsCost(List<SingleUnitReservation> Units,DateTime checkIn,DateTime CheckOut,int count)
        {
            int total = 0;
            for(; checkIn.Date<CheckOut.Date;checkIn=checkIn.Date.AddDays(1))
            {
                bool found = false;
                for(int i=0;i<Units.Count;i++)
                {
                    if(checkIn.Date>=Units[i].StartDate.Date &&checkIn.Date<=Units[i].EndDate)
                    {
                        total = total + (Units[i].Price * count);
                        found = true;
                        break;
                    }
                }
                if(found==false)
                {
                    return -1;
                }
            }
            return total;
        }
    }
}
