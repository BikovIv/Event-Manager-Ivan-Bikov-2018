using Event_Manager.Models;
using System.Data.Entity;

namespace Event_Manager.Data_Access
{
    public class EventManagerDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
      
        public EventManagerDbContext()
            : base("EventManagerDb")
        {

        }
    }
}