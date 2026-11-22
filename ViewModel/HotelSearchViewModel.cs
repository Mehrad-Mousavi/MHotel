using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModel
{
    public class HotelSearchViewModel
    {

        public Hotel Model { get; set; }
        public string HotelName { get; set; }
        public decimal PricePerNight { get; set; }
        public List<Hotel> Results { get; set; }
    }
}
