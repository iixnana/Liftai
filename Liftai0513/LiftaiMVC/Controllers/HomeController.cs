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
            try
            {
                Models.ElevatorsDB db = new Models.ElevatorsDB();
                var handyman = db.Handymans.First(x => x.id == 1);
                if (handyman.status == 1) findNewTask(); //automatiskai iesko naujos uzduoties su login
                if (handyman.currentTask != 0 && db.Tasks.Count() > 0)
                {
                    var task = db.Tasks.First(x => x.id == handyman.currentTask);
                    return View(task);
                }
                else
                {
                    return View();
                }
        }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("Error");
    }

}


        public ActionResult Login()
        {
            Session["Type"] = "";
            return View();
        }

        public Models.Task selectNewTask()
        {
            Models.ElevatorsDB db = new Models.ElevatorsDB();

            if (db.Tasks.Count() == 0)
                return null;

            var min = db.Tasks.Min(x => x.Priority);
            var newTask = db.Tasks.First(x => x.Priority <= min);

            return newTask;
        }

        public ActionResult findNewTask()
        {
            Models.ElevatorsDB db = new Models.ElevatorsDB();
            var handyman = db.Handymans.First(x => x.id == 1);
            var selectedTask = selectNewTask(); //New Task

            if (handyman.status == 1)
            {
                if (selectedTask != null)
                {
                    Models.Handyman handymanNew = new Models.Handyman(1, 2, selectedTask.id);
                    db.Entry(handyman).CurrentValues.SetValues(handymanNew);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("IndexHandyman");
        }

        public ActionResult changeStatus()
        {
            Models.ElevatorsDB db = new Models.ElevatorsDB();
            var handyman = db.Handymans.First(x => x.id == 1);
            var finishedTask = db.Tasks.First(x => x.id == handyman.currentTask);
            db.Tasks.Remove(finishedTask);
            db.SaveChanges();
            Models.Task selectedTask = selectNewTask(); //New Task

            if (handyman.status == 1)
            {
                if (selectedTask != null)
                {
                    Models.Handyman handymanNew = new Models.Handyman(1, 2, selectedTask.id);
                    db.Entry(handyman).CurrentValues.SetValues(handymanNew);
                    db.SaveChanges();
                }
                else return RedirectToAction("IndexHandyman");
            }
            else if (handyman.status == 2)
            {
                var elevator = db.Elevators.First(x => x.ID == finishedTask.ElevatorID);
                elevator.State = Models.States.active;
                db.Entry(elevator).CurrentValues.SetValues(elevator);
                db.SaveChanges();
                if (selectedTask != null)
                {
                    Models.Handyman handymanNew = new Models.Handyman(1, 2, selectedTask.id);
                    db.Entry(handyman).CurrentValues.SetValues(handymanNew);
                    db.SaveChanges();
                }
                else
                {
                    Models.Handyman handymanNew = new Models.Handyman(1, 1, 0);
                    db.Entry(handyman).CurrentValues.SetValues(handymanNew);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("IndexHandyman");
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}