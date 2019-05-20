using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Reflection;

namespace LiftaiMVC.Models
{
    public class Elevator
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Būtina užpildyti šį lauką")]
        [Display(Name = "Serijos numeris")]
        [DataType(DataType.Text)]
        public string SerialNum { get; set; }

        [Required(ErrorMessage = "Būtina užpildyti šį lauką")]
        [Display(Name = "Modelis")]
        [DataType(DataType.Text)]
        public string Model { get; set; }

        [Required(ErrorMessage = "Būtina užpildyti šį lauką")]
        [Display(Name = "Įrengimo data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeploymentDate { get; set; }

        [Required(ErrorMessage = "Būtina užpildyti šį lauką")]
        [Display(Name = "Maksimalus svoris (kg)")]
        [Range(1, 5000, ErrorMessage = "Įveskite tinkamą svorį (1-5000)")]
        public int MaxWeight { get; set; }

        [Required(ErrorMessage = "Būtina užpildyti šį lauką")]
        [Display(Name = "Laiptinės numeris")]
        [Range(0, 100, ErrorMessage = "Įveskite tinkamą laiptinės numerį (0-100)")]
        public int Stairway { get; set; }

        [Required(ErrorMessage = "Būtina užpildyti šį lauką")]
        [Display(Name = "Paskutinės profilaktikos data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastCheckUp { get; set; }

        [Required(ErrorMessage = "Būtina užpildyti šį lauką")]
        [Display(Name = "Profilaktikos dažnumas (mėn)")]
        [Range(1, 48, ErrorMessage = "Įveskite tinkamą mėnesių kiekį (1-48)")]
        public int CheckUpFrequency { get; set; }


        // LIFTO BŪKLĖ

        [Display(Name = "Pastabos")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [Required(ErrorMessage = "Būtina užpildyti šį lauką")]
        [Display(Name = "Pastato ID")]
        public string BuildingID { get; set; } // IDETI I UML DIAGRAMA!!!!

        [Required(ErrorMessage = "Būtina pasirinkti būseną")]
        [Display(Name = "Būsena")]
        public States State { get; set; }

        public Elevator()
        {
            DeploymentDate = DateTime.Now.Date;
            MaxWeight = 500;
            Stairway = 0;
            LastCheckUp = DateTime.Now.Date;
            CheckUpFrequency = 12;
        }

        public bool changeState(string state)
        {
            foreach(States st in Enum.GetValues(typeof(States)))
            {
                if (state == st.ToString())
                {
                    this.State = st;
                    return true;
                }
            }
            return false;
        }

        public string StateName()
        {
            return this.State.GetAttribute<DisplayAttribute>().Name;
        }

        public static string StateName(string state)
        {
            States NewState = States.active;
            if (state == "stopped")
                NewState = States.stopped;
            else if (state == "broken")
                NewState = States.broken;
            else if (state == "dead")
                NewState = States.dead;
            else if (state == "repairing")
                NewState = States.repairing;
            return NewState.GetAttribute<DisplayAttribute>().Name;
        }
    }

    public static class Extensions
    {
        /// <summary>
        ///     A generic extension method that aids in reflecting 
        ///     and retrieving any attribute that is applied to an `Enum`.
        /// </summary>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }

    public enum States
    {
        [Display(Name = "Veikiantis")]
        active,
        [Display(Name = "Sugedęs")]
        broken,
        [Display(Name = "Tvarkomas")]
        repairing,
        [Display(Name = "Nebeveikiantis")]
        dead,
        [Display(Name = "Sustabdytas")]
        stopped
    }
}