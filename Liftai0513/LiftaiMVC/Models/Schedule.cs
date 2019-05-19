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

        [Display(Name = "Darbo diena")]
        public DateTime Date { get; private set; }

        [Display(Name = "Darbo pradžios laikas")]
        public DateTime Start { get; private set; }

        [Display(Name = "Darbo pabaigos laikas")]
        public DateTime End { get; private set; }
        public int HandymanId { get; private set; }

        public Schedule() { }
        
        public Schedule(DateTime date, DateTime start, DateTime end, int id)
        {
            Date = date;
            Start = start;
            End = end;
            HandymanId = id;
        }
    }
}