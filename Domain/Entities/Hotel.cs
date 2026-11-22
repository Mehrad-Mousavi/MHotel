using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Hotel
    {
        public Hotel()
        {
            Reservations = new HashSet<Reservation>();
            HotelServices = new HashSet<HotelService>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HotelId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(10)]

        public string HotelName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        public decimal PricePerNight { get; set; }

        [Required]
        public double Rating { get; set; }

        public int StarRating { get; set; }

        [Required]
        public int CapaCity { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public bool IsActive { get; set; }


        #region Child Entities

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<HotelService> HotelServices { get; set; }
        #endregion

    }
}
