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
            try
            {
                ViewBag.Message = "Liftų sąrašas";
                Models.ElevatorsDB db = new Models.ElevatorsDB();
                return View(db.Elevators);
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message + " 2";
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpGet]
        public ActionResult ElevatorForm()
        {
            try
            {
                Models.ElevatorsDB db = new Models.ElevatorsDB();
                Models.Elevator NewElevator = new Models.Elevator();
                ViewData["Buildings"] = ToSelectList(db.Buildings);
                return View(NewElevator);
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message + " 3";
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ElevatorForm(Models.Elevator NewElevator)
        {
            try
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
            catch (Exception e)
            {
                TempData["error"] = e.Message + " 4";
                return RedirectToAction("Error", "Home");
            }

        }


        public ActionResult Delete(string id)
        {
            try
            {
                Models.ElevatorsDB db = new Models.ElevatorsDB();
                Models.Elevator elevator = db.Elevators.First(x => x.ID.ToString() == id);
                db.Elevators.Remove(elevator);
                db.SaveChanges();
                return RedirectToAction("ElevatorsList");
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message + " 5";
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpGet]
        public ActionResult DetailedElevatorInfo(int id)
        {
            try
            {
                Models.ElevatorsDB db = new Models.ElevatorsDB();
                ViewData["Buildings"] = ToSelectList(db.Buildings);
                Models.Elevator elevator = db.Elevators.First(x => x.ID == id);
                return View(elevator);
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message + " 6";
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetailedElevatorInfo(Models.Elevator elevator)
        {
            try
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
            catch (Exception e)
            {
                TempData["error"] = e.Message + " 7";
                return RedirectToAction("Error", "Home");
            }

        }

        [NonAction]
        public SelectList ToSelectList(System.Data.Entity.DbSet buildings)
        {
            try
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
            catch (Exception e)
            {
                TempData["error"] = e.Message + " 8";
                return null;
            }

        }

        [HttpGet]
        public ActionResult RestartElevator(int elevatorID, bool? restart)
        {
            try
            {
                Models.ElevatorsDB elevatorsDB = new Models.ElevatorsDB();
                Models.Elevator elevator = elevatorsDB.Elevators.First(x => x.ID == elevatorID);
                if (!restart.HasValue)
                {
                    TempData["EditSuccess"] = "Perkraunama lifto sistema...";
                    return RedirectToAction("ElevatorAPI", new { id = elevatorID });
                }
                else if ((bool)restart)
                    TempData["EditSuccess"] = "Lifto sistema sėkmingai perkrauta " + DateTime.Now.ToLocalTime().ToString();
                else
                    TempData["EditSuccess"] = "Lifto sistemos pekrovimas nepavyko (" + DateTime.Now.ToLocalTime().ToString() + ").";

                // SEND RESTART SIGNAL TO THE ELEVATOR
                // (respond via Elevators/ElevatorAPI/{id}  RESTART button

                return RedirectToAction("DetailedElevatorInfo", new { id = elevatorID });
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message + " 9";
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public ActionResult TurnOffBrakes(int elevatorID, bool? state)
        {
            try
            {
                Models.ElevatorsDB elevatorsDB = new Models.ElevatorsDB();
                Models.Elevator elevator = elevatorsDB.Elevators.First(x => x.ID == elevatorID);
                if (!state.HasValue)
                {
                    TempData["EditSuccess"] = "Klausiama lifto būklės...";
                    // ASK ELEVATOR STATE
                    // (respond via Elevators/ElevatorAPI/{id}  SEND STATE button
                    return RedirectToAction("ElevatorAPI", new { id = elevatorID });
                }
                else if ((bool)state)
                    // SEND BRAKES TURN OFF SIGNAL TO THE ELEVATOR
                    TempData["EditSuccess"] = "Lifto avariniai stabdžiai išjungti " + DateTime.Now.ToLocalTime().ToString();
                else
                    TempData["EditSuccess"] = "Lifto avariniai stabdžiai negali būti išjungti dėl nesaugios lifto būklės (" + DateTime.Now.ToLocalTime().ToString() + ").";

                return RedirectToAction("DetailedElevatorInfo", new { id = elevatorID });

            }
            catch (Exception e)
            {
                TempData["error"] = e.Message + " 10";
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public ActionResult NewState(int elevatorID, string state)
        {
            try
            {
                Models.ElevatorsDB elevatorsDB = new Models.ElevatorsDB();
                Models.Elevator elevator = elevatorsDB.Elevators.First(x => x.ID == elevatorID);
                string previousState = elevator.State.ToString();

                if (elevator.changeState(state))
                {
                    elevatorsDB.SaveChanges();
                    TempData["EditSuccess"] = "Atnaujinta lifto būklė (" + DateTime.Now.ToLocalTime().ToString() + ").";
                }
                else
                {
                    TempData["EditSuccess"] = "Gautas nežinomos būklės signalas (" + DateTime.Now.ToLocalTime().ToString() + ").";
                }

                if (state == "broken" && previousState == "active")
                {
                    // ELEVATOR STATE CHANGED FROM ACTIVE TO BROKEN

                    var taskController = DependencyResolver.Current.GetService<TaskController>();
                    taskController.ControllerContext = new ControllerContext(this.Request.RequestContext, taskController);
                    string description = "Lifto būklė pasikeitė į " + Models.Elevator.StateName(state);
                    if (taskController.CreateTask(elevatorID, description))
                        TempData["EditSuccess"] += " Pridėta nauja užduotis.";
                }

                return RedirectToAction("DetailedElevatorInfo", new { id = elevatorID });

            }
            catch (Exception e)
            {
                TempData["error"] = e.Message + " 11";
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult ElevatorAPI(int id)
        {
            try
            {
                Models.ElevatorsDB db = new Models.ElevatorsDB();
                Models.Elevator elevator = db.Elevators.First(x => x.ID == id);
                return View(elevator);
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message + " 12";
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpGet]
        public ActionResult SystemFailure(int elevatorID)
        {
            try
            {
                Models.ElevatorsDB db = new Models.ElevatorsDB();
                Models.Notification notification = new Models.Notification(elevatorID);
                db.Notifications.Add(notification);
                db.SaveChanges();
                TempData["EditSuccess"] = "Pagalbos pranešimas sėkmingai išsiųstas.";

                return RedirectToAction("DetailedElevatorInfo", new { id = elevatorID });
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message + " 13";
                return RedirectToAction("Error", "Home");
            }

        }
    }
}