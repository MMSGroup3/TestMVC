using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestMVC.Models
{
    public class Event
    {
        public string Name{ get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Host { get; set; }
        public string Tags { get; set; }
        public string Related { get; set; }
    }

    public class EventDbContext : DbContext
    {
        public DbSet<Event> Event { get; set; }
    }
}