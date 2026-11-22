using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class HotelService
    {

        public int HotelId { get; set; }
        public int ServiceId { get; set; }


        #region Parent Entities

        [ForeignKey(nameof(HotelId))]
        public Hotel Hotel { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }

        #endregion

    }
}
