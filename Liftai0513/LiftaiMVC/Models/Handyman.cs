using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LiftaiMVC.Models
{
    public class Handyman
    {
        public int id { get; set; }
        public int status { get; set; }
        public int currentTask { get; set; }

        public Handyman()
        {
            id = 1;
        }

        public Handyman(int ID, int Status, int CurrentTask)
        {
            id = ID;
            status = Status;
            currentTask = CurrentTask;
        }
    }
}