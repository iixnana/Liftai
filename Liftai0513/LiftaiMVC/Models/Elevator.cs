using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LiftaiMVC.Models
{
    public class Elevator
    {
        [Key]
        public string SerialNum { get; private set; }
        public string Model { get; private set; }
        public DateTime DeploymentDate { get; private set; }
        public int MaxWeight { get; private set; }
        public int Stairway { get; private set; }
        public DateTime LastCheckUp { get; private set; }
        public int CheckUpFrequency { get; private set; }
        // LIFTO BŪKLĖ
        public string Notes { get; private set; }

        private Elevator() { }
        public Elevator(string serial, string model, DateTime deployment, int max, int stairway, DateTime checkup, int freq, string notes)
        {
            SerialNum = serial;
            Model = model;
            DeploymentDate = deployment;
            MaxWeight = max;
            Stairway = stairway;
            LastCheckUp = checkup;
            CheckUpFrequency = freq;
            Notes = notes;
        }
    }
}