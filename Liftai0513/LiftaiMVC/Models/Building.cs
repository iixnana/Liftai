using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LiftaiMVC.Models
{
    public class Building
    {
        public int id { get; set; }
        public string Address { get; private set; }
        public int FloorsNum { get; private set; }
        public int StairwaysNum { get; private set; }
        public string Notes { get; private set; }
        public Models.Elevator[] Elevators { get; private set; }

        public Building(Models.Elevator[] elevators)
        {
            Elevators = elevators;
        }

        private Building() { }
        public Building(string address, int floors, int stairways, string notes)
        {
            Address = address;
            FloorsNum = floors;
            StairwaysNum = stairways;
            Notes = notes;
        }

        public void SetAddress(string address)
        {
            Address = address;
        }

        public void SetFloorsNum(int floors)
        {
            FloorsNum = floors;
        }

        public void SetStairwaysNum(int stairways)
        {
            StairwaysNum = stairways;
        }

        public void SetNotes(string notes)
        {
            Notes = notes;
        }

    }
}