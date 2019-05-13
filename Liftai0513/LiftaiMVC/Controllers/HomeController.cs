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
            return View();
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
    }
}