using Domain.Context;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Application
{
    public class ReservationApplication : IDisposable
    {
        private AppDbContext _dbContext;

        public void Dispose()
        {

        }

        public ReservationApplication(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Reservation

        public async Task<List<Reservation>> GetAsync()
        {
            return await _dbContext.Reservations
                .Include(item => item.Hotel)
                .ToListAsync();
        }

        public async Task<List<Reservation>> GetByHotelAsync(int HotelId)
        {
            return await _dbContext.Reservations
                .Where(r => r.HotelId == HotelId)
                .ToListAsync();
        }

        public async Task<Reservation> FindAsync(int Id)
        {
            return await _dbContext.Reservations.FindAsync(Id);
        }

        public async Task<bool> SaveAsync(Reservation model)
        {
                _dbContext.Reservations.Add(model);
                await _dbContext.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> Delete(int Id)
        {
            Reservation model = await FindAsync(Id);

            if (model == null)
                return false;

            _dbContext.Reservations.Remove(model);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        #endregion

    }
}
