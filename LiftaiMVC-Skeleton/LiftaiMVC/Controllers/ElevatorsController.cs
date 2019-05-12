using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiftaiMVC.Controllers
{
    public class ElevatorsController : Controller
    {
        // GET: Elevators
        public ActionResult ElevatorsList()
        {
            ViewBag.Message = "Liftų sąrašas";

            return View();
        }
    }
}