using Microsoft.EntityFrameworkCore;

namespace NotesUwpTask.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Note> Notes { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=notesUwpTask.db");
        }
    }
}