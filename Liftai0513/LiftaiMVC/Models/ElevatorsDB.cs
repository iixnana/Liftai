using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LiftaiMVC.Models
{
    public class ElevatorsDB : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Elevator> Elevators { get; set; }
        public DbSet<Handyman> Handymans { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}