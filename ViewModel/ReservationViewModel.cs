using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModel
{
    public class ReservationViewModel
    {
        public int HotelId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public List<SelectListItem> Hotels { get; set; }

        public List<Domain.Entities.Hotel> HotelsInfo { get; set; }

        public List<Domain.Entities.Reservation> Reservations { get; set; } 

        public int Nights { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
