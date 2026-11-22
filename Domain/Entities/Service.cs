using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Service
    {

        public Service()
        {
            HotelServices = new HashSet<HotelService>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Description { get; set; }


        #region Child Entities

        public ICollection<HotelService> HotelServices { get; set; }

        #endregion

    }
}
