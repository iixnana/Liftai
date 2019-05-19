using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LiftaiMVC.Models
{
    public class Notification
    {
        public int id { get; set; }
        public DateTime Date { get; private set; }
        public bool Read { get; private set; }
        public int ElevatorId { get; private set; }

        public Notification(int id)
        {
            Date = DateTime.UtcNow;
            Read = false;
            ElevatorId = id;
        }
    }
}