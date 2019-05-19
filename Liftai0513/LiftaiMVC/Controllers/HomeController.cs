using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiftaiMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult IndexOperator()
        {
            Session["Type"] = "Operator";
            return View();
        }

        public ActionResult IndexAdministrator()
        {
            Session["Type"] = "Admin";
            return View();
        }

        public ActionResult IndexHandyman()
        {
            Session["Type"] = "Handyman";

            Models.ElevatorsDB db = new Models.ElevatorsDB();
            var handyman = db.Handymans.First(x => x.id == 1);

            var task = db.Tasks.First(x => x.id == handyman.currentTask);
            return View(task);
        }


        public ActionResult Login()
        {
            Session["Type"] = "";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult ElevatorsList()
        //{
        //    ViewBag.Message = "Liftų sąrašas";

        //    return View();
        //}

        public Models.Task selectNewTask()
        {
            Models.ElevatorsDB db = new Models.ElevatorsDB();

            if (db.Tasks.Count() == 0)
                return null;

            var min = db.Tasks.Min(x => x.Priority);
            var newTask = db.Tasks.First(x => x.Priority <= min);

            return newTask;
        }

        public ActionResult changeStatus()
        {
            Models.ElevatorsDB db = new Models.ElevatorsDB();
            var handyman = db.Handymans.First(x => x.id == 1);
            var finishedTask = db.Tasks.First(x => x.id == handyman.currentTask);

            var selectedTask = selectNewTask();
            Models.Handyman handymanNew = handyman;

            if (handyman.status == 1)
            {
                if (selectedTask != null)
                {
                    handymanNew.currentTask = selectedTask.id;
                    db.Entry(handyman).CurrentValues.SetValues(handymanNew);
                    db.Entry("2").CurrentValues.SetValues(handyman.status);
                    db.SaveChanges();
                }
                else RedirectToAction("IndexHandyman");
            }
            else if (handyman.status == 2)
            {
                if (selectedTask != null)
                {
                    handymanNew.currentTask = selectedTask.id;
                    db.Entry(handyman).CurrentValues.SetValues(handymanNew);
                    db.Tasks.Remove(finishedTask);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry("1").CurrentValues.SetValues(handyman.status);
                    RedirectToAction("IndexHandyman");
                }
            }

            return RedirectToAction("IndexHandyman");
        }
    }
}