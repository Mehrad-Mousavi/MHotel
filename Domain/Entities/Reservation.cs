using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int HotelId { get; set; }
        public DateTime CheckIn { get; set; }
        public  DateTime CheckOut { get; set; }
        public decimal TotalPrice { get; set; }


        #region Parent Entities

        [ForeignKey(nameof(HotelId))]
        public Hotel Hotel { get; set; }

        #endregion
    }
}
