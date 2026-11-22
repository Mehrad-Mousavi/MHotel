using Domain.Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModel
{
    public class HotelViewModel
    {
        public string SearchTerm { get; set; }

        public Hotel Model { get; set; }
        
        public List<SelectListItem> Hotels { get; set; }
    }
}
