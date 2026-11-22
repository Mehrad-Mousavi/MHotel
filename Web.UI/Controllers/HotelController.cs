using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace Web.UI.Controllers
{
    public class HotelController : BaseController
    {
     private Domain.Context.AppDbContext _dbContext = new Domain.Context.AppDbContext();
     HotelApplication HotelHandler;
     BasicDataDropDownApplication BasicDataHandler;

        public void Dispose()
        {
            HotelHandler.Dispose();
            BasicDataHandler.Dispose();
        }

        public HotelController ()
        {
            HotelHandler = new HotelApplication(_dbContext);
            BasicDataHandler = new BasicDataDropDownApplication(_dbContext);
        }

        [Route("Hotel/Index")]
        public async Task<ActionResult> Index()
        {
            return View(await HotelHandler.GetAsync());
        }



        [Route("Hotel/")]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            return View();
        }

        #region Search Actions
        public async Task<ActionResult> Search()
        {
            #region Init Model
            HotelSearchViewModel model = new HotelSearchViewModel();
            #endregion          
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Search(HotelSearchViewModel model)
        {
            model.Results = await HotelHandler.SearchAsync(model.HotelName, model.PricePerNight);

            return View(model);
        }
        

        #endregion

    }
}