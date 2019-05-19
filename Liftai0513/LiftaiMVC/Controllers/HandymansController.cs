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

        public int selectNewTask()
        {
            Models.ElevatorsDB db = new Models.ElevatorsDB();

            if (db.Tasks.Count() == 0)
                return 0;

            var min = db.Tasks.Min(x => x.Priority);
            var newTask = db.Tasks.First(x => x.Priority <= min);

            return newTask.id;
        }

        public ActionResult checkCurrentTask()
        {
            Models.ElevatorsDB db = new Models.ElevatorsDB();
            var handyman = db.Handymans.First(x => x.id == 1);

            var task = db.Tasks.First(x => x.id == handyman.currentTask);
            return View("IndexHandyman", task);
        }

        public ActionResult changeStatus()
        {
            Models.ElevatorsDB db = new Models.ElevatorsDB();
            var handyman = db.Handymans.First(x => x.id == 1);
            var finishedTask = db.Tasks.First(x => x.id == handyman.currentTask);
            var selectedTask = selectNewTask();
            if (handyman.status == 1)
            {          
                if (selectedTask != 0)
                {
                    db.Entry(selectedTask.ToString()).CurrentValues.SetValues(handyman.currentTask);
                    db.Entry("2").CurrentValues.SetValues(handyman.status);
                    db.SaveChanges();
                }                   
            }
            else if(handyman.status == 2)
            {
                if (selectedTask != 0)
                {
                    db.Tasks.Remove(finishedTask);
                    db.Entry(selectedTask.ToString()).CurrentValues.SetValues(handyman.currentTask);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("IndexHandyman");
        }
    }
}