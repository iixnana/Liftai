using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;

namespace LiftaiMVC.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        public int AssessPriority(int elevatorID, string description)
        {
            // do some magic here to assess task priority
            Random rand = new Random();
            int priority = rand.Next(1, 100);

            return priority;
        }

        [HttpGet]
        public bool CreateTask(int elevatorID, string description)
        {
            Models.ElevatorsDB db = new Models.ElevatorsDB();
     
            Models.Task newTask = new Models.Task(elevatorID, description, AssessPriority(elevatorID, description));
            db.Tasks.Add(newTask);
            db.SaveChanges();
            return true;
        }
    }
}