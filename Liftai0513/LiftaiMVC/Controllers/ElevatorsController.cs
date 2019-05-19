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
            Models.ElevatorsDB db = new Models.ElevatorsDB();
            return View(db.Elevators);
        }

        [HttpGet]
        public ActionResult ElevatorForm()
        {
            Models.ElevatorsDB db = new Models.ElevatorsDB();
            Models.Elevator NewElevator = new Models.Elevator();
            ViewData["Buildings"] = ToSelectList(db.Buildings);
            return View(NewElevator);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ElevatorForm(Models.Elevator NewElevator)
        {
            if (ModelState.IsValid)
            {
                Models.ElevatorsDB db = new Models.ElevatorsDB();
                db.Elevators.Add(NewElevator);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Įrašas buvo sėkmingas";
                return RedirectToAction("ElevatorForm");
            }
            else
            {
                TempData["SuccessMessage"] = null;
                Models.ElevatorsDB db = new Models.ElevatorsDB();
                ViewData["Buildings"] = ToSelectList(db.Buildings);
            }
            return View();
        }

        
        public ActionResult Delete(string id)
        {
            Models.ElevatorsDB db = new Models.ElevatorsDB();
            Models.Elevator elevator = db.Elevators.First(x => x.ID.ToString() == id);
            db.Elevators.Remove(elevator);
            db.SaveChanges();
            return RedirectToAction("ElevatorsList");
        }

        [HttpGet]
        public ActionResult DetailedElevatorInfo(int id)
        {
            Models.ElevatorsDB db = new Models.ElevatorsDB();
            ViewData["Buildings"] = ToSelectList(db.Buildings);
            Models.Elevator elevator = db.Elevators.First(x => x.ID == id);
            return View(elevator);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetailedElevatorInfo(Models.Elevator elevator)
        {
            if (ModelState.IsValid)
            {
                Models.ElevatorsDB db = new Models.ElevatorsDB();
                Models.Elevator dbelevator = db.Elevators.First(x => x.ID == elevator.ID);
                db.Entry(dbelevator).CurrentValues.SetValues(elevator);
                db.SaveChanges();
                TempData["EditSuccess"] = "Įrašas buvo sėkmingai redaguotas";
                return RedirectToAction("DetailedElevatorInfo", new { id = elevator.ID });
            }
            else
            {
                TempData["EditSuccess"] = null;
                Models.ElevatorsDB db = new Models.ElevatorsDB();
                ViewData["Buildings"] = ToSelectList(db.Buildings);
            }
            return View();
        }

        [NonAction]
        public SelectList ToSelectList(System.Data.Entity.DbSet buildings)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (Models.Building building in buildings)
            {
                list.Add(new SelectListItem()
                {
                    Text = building.Address,
                    Value = building.id.ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }
    }
}