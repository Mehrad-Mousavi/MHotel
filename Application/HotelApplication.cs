using Domain.Context;
using Microsoft.SqlServer.Server;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using System.Data.Entity;
using Domain.Entities;

namespace Application
{
    public class HotelApplication : IDisposable
    {
        private AppDbContext _dbContext;

        public void Dispose()
        {

        }

        public HotelApplication(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Hotel
        public async Task<List<Hotel>> GetAsync()
        {
            return await _dbContext.Hotels.ToListAsync();

        }

        public async Task<Hotel> FindAsync(int Id)
        {
            return await _dbContext.Hotels.FindAsync(Id);
        }

        public async Task<bool> SaveAsync(Hotel model)
        {
            _dbContext.Hotels.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<List<Hotel>> SearchAsync(string HotelName, decimal? PricePerNight)
        {
            return await _dbContext.Hotels
                .Where(item => item.HotelName.Contains(HotelName) && item.PricePerNight == PricePerNight)
                .ToListAsync();
        }

        #endregion
    }
}
