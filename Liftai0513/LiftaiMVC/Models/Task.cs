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
        public DateTime FailureDate { get; private set; }
        public DateTime FixDate { get; private set; }
        public string Description { get; private set; }
        public int Priority { get; private set; }

        private Task() { }
    }
}