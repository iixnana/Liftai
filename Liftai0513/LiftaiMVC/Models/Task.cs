using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LiftaiMVC.Models
{
    public class Task
    {
        public int id { get; set; }
        public int ElevatorID { get; set; } // IDETI I UML DIAGRAMA!!!!
        public DateTime FailureDate { get; private set; }
        public DateTime? FixDate { get; private set; }
        public string Description { get; private set; }
        public int Priority { get; private set; }
        public int ElevatorID { get; set; }

        public Task(int elevatorID, string description, int priority)
        {
            this.ElevatorID = elevatorID;
            this.FailureDate = DateTime.Now.ToLocalTime();
            this.FixDate = null;
            this.Description = description;
            this.Priority = priority;
        }
    }
}