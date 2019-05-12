using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LiftaiMVC.Models
{
    public class Notification
    {
        public DateTime Date { get; private set; }
        public bool Read { get; private set; }
    }
}