using Domain.Context;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;

namespace Application
{
    public class BasicDataDropDownApplication : IDisposable 
    {
        private AppDbContext _dbContext;

        public void Dispose()
        {

        }

        public BasicDataDropDownApplication(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        #region Hotels


        public async Task<List<Model.DropDownModel>> GetHotelsAsync()
        {
            return await _dbContext.Hotels
                .Select(item => new Model.DropDownModel
                {
                    Value = item.HotelId.ToString(),
                    Value2 = item.PricePerNight.ToString(),
                    Value3 = item.CapaCity.ToString(),
                    Text = item.HotelName,
                })
                .ToListAsync();
        }

        #endregion

        #region Reservations


        public async Task<List<Model.DropDownModel>> GetReservationsAsync()
        {
            return await _dbContext.Reservations
                .Select(item => new Model.DropDownModel
                {
                    Value = item.ReservationId.ToString(),
                    Value2 = item.HotelId.ToString(),
                    CheckInText = item.CheckIn,
                    CheckOutText = item.CheckOut,
                    Text2 = item.TotalPrice.ToString()
                })
            .ToListAsync();
        }

        #endregion
    }
}
