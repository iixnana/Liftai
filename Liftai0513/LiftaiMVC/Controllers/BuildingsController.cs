using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiftaiMVC.Controllers
{
    public class BuildingsController : Controller
    {
        public void GetElevatorData()
        {
            var elevator = new Models.Elevator().SelectElevator();
        }

        // GET: Buildings
        public ActionResult BuildingsList()
        {
            return View();
        }

        public ActionResult DetailedBuildingInfo(int id)
        {
            Models.ElevatorsDB db = new Models.ElevatorsDB();
            Models.Building building = db.Buildings.First(x => x.id == id);
            return View(building);
        }
    }
}