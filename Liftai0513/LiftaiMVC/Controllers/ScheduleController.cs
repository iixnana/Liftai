using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiftaiMVC.Models;

namespace LiftaiMVC.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SchedulePreview()
        {
            Models.ElevatorsDB db = new Models.ElevatorsDB();

            //Models.Schedule s = new Schedule(DateTime.Today, DateTime.UtcNow.AddHours(-2), DateTime.UtcNow.AddHours(6), 1);
            //db.Schedules.Add(s);
            //db.SaveChanges();

            Models.Schedule schedule = null;
            try
            {
                schedule = db.Schedules.First(x => x.HandymanId == 1 && x.Date.Equals(DateTime.Today));
            }
            catch
            {
                schedule = null;
            }
            return View("ScheduleForm", schedule);
        }
    }
}