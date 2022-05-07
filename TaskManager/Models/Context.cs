using Microsoft.EntityFrameworkCore;

namespace TaskManager.Models
{
    public class Context : DbContext
    {
        public DbSet<Task> tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=taskdatabase.db");
        }
        
    }
}
