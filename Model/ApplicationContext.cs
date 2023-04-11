using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;

namespace NotesUwpTask.Model
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Note> Notes { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=notesUwpTask.db");
        }

        public void ResetDB(ObservableCollection<Note> noteList)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            for (int i = 0; i < noteList.Count; i++)
            {
                noteList[i].Id = i;
            }

            AddRange(noteList);
            SaveChanges();
        }
    }
}