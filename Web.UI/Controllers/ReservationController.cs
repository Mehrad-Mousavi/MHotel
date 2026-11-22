using Application;
using Domain.Entities;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace Web.UI.Controllers
{
    public class ReservationController : BaseController
    {
        private Domain.Context.AppDbContext _dbContext = new Domain.Context.AppDbContext();
        BasicDataDropDownApplication BasicDataHandler;
        HotelApplication HotelHandler;
        ReservationApplication ReservationHandler;
        public void Dispose()
        {
            BasicDataHandler.Dispose();
            HotelHandler.Dispose();
            ReservationHandler.Dispose();
        }

        public ReservationController()
        {
            BasicDataHandler = new BasicDataDropDownApplication(_dbContext);
            HotelHandler = new HotelApplication(_dbContext);
            ReservationHandler = new ReservationApplication(_dbContext);
        }

        [Route("Reservation/Index")]
        public async Task<ActionResult> Index()
        {
            return View(await ReservationHandler.GetAsync());
        }



        [Route("Reservation/")]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            return View();
        }

        #region Create Action


        public async Task<ActionResult> New()
        {

            #region Init Model

            ReservationViewModel model = new ReservationViewModel();
            model.Hotels = base.InitDropDown(await BasicDataHandler.GetHotelsAsync());
            model.HotelsInfo = await HotelHandler.GetAsync();
            model.CheckIn = DateTime.Today;
            model.CheckOut = DateTime.Today.AddDays(1);
            #endregion

            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> New(ReservationViewModel model)
        {

            #region Init Model
            model.Hotels = base.InitDropDown(await BasicDataHandler.GetHotelsAsync());
            model.HotelsInfo = await HotelHandler.GetAsync();
            model.Nights = (model.CheckOut - model.CheckIn).Days;
            #endregion

            #region Validation

            if (model.CheckIn.Date < DateTime.Today)
                ModelState.AddModelError("", "Check-in date cannot be in the past.");
            
            if (model.Nights <= 0)
                ModelState.AddModelError("", "Check-out date must be after Check-in date.");
          
                
            if (!ModelState.IsValid)
                return View(model);

            #endregion

            #region Business logic

            DateTime newCheckIn = model.CheckIn;
            DateTime newCheckOut = model.CheckIn.AddDays(model.Nights);

            var Reservations = await ReservationHandler.GetByHotelAsync(model.HotelId);

            foreach(var modelr in Reservations)
            {
                if (newCheckIn < modelr.CheckOut && newCheckOut > modelr.CheckIn)
                    ModelState.AddModelError("", "Time OverLap issue.");

                break;
            }
            #endregion

            if(!ModelState.IsValid)
            {
                return View(model);
            }

                Domain.Entities.Hotel Hotel = await HotelHandler.FindAsync(model.HotelId);

            if (Hotel == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            model.TotalPrice = model.Nights * Hotel.PricePerNight;


            #region Init Reservation

            Domain.Entities.Reservation Reservation = new Domain.Entities.Reservation();
            Reservation.HotelId = model.HotelId;
            Reservation.CheckIn = model.CheckIn;
            Reservation.CheckOut = model.CheckOut;
            Reservation.TotalPrice = model.TotalPrice;

            #endregion

            if (await ReservationHandler.SaveAsync(Reservation))
                return RedirectToAction("New");

            return View(model);
        }

        #endregion


        #region Cancel Action

        [HttpPost]
        public async Task<ActionResult> Delete(int? Id)
        {
            if (!Id.HasValue)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (await ReservationHandler.Delete(Id.Value))
                return Json(true);

            return Json(false);
        }

        #endregion

    }
}