using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiftaiMVC.Controllers
{
    public class BuildingsController : Controller
    {
        // GET: Buildings
        public ActionResult BuildingsList()
        {
            return View();
        }
    }
}