using Microsoft.EntityFrameworkCore;

namespace LucyCalender.Models
{
    public class EventContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=events.db");

    }
}
