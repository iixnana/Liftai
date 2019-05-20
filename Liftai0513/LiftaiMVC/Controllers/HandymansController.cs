using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiftaiMVC.Controllers
{
    public class HandymansController : Controller
    {
        // GET: Handymans
        public ActionResult Index()
        {
            return View();
        }

        [NonAction]
        public int selectNewTask()
        {
            try
            {
                Models.ElevatorsDB db = new Models.ElevatorsDB();

                if (db.Tasks.Count() == 0)
                    return 0;

                var min = db.Tasks.Min(x => x.Priority);
                var newTask = db.Tasks.First(x => x.Priority <= min);

                return newTask.id;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message + " NO ID 14";
                return -1;
            }
        }

        public ActionResult checkCurrentTask()
        {
            try
            {
                Models.ElevatorsDB db = new Models.ElevatorsDB();
                var handyman = db.Handymans.First(x => x.id == 1);

                var task = db.Tasks.First(x => x.id == handyman.currentTask);
                return View("IndexHandyman", task);
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message + " 15";
                return RedirectToAction("Error", "Home");
            }

        }

    }
}