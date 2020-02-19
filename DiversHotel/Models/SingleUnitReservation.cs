using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiversHotel.Models
{
    public class SingleUnitReservation
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
        public SingleUnitReservation( DateTime s, DateTime e, int p)
        {
            this.StartDate = s;
            this.EndDate = e;
            this.Price = p;
        }

    }
}
