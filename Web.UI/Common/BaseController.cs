using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.UI.Controllers
{
    public class BaseController : Controller
    {
        protected List<SelectListItem> InitDropDown(List<Model.DropDownModel> HotelModels)
        {
            var Result = new List<SelectListItem>();
            foreach(var item in HotelModels)
            {
                Result.Add(new SelectListItem()
                {
                    Text = item.Text,
                    Value = item.Value
                });
            }
            return Result;
        }
    }
}