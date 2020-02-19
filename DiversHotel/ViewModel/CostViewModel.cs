using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiversHotel.ViewModel
{
    public class CostViewModel
    {
        public int TotalCost { get; set; }
        public String Message { get; set; }
        public CostViewModel(int t,string M)
        {
            this.TotalCost = t;
            this.Message = M;
        }
    }
}
