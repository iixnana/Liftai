using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LiftaiMVC.Models
{
    public class Schedule
    {
        public int id { get; set; }
        public DateTime Date { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        private Schedule() { }
    }
}