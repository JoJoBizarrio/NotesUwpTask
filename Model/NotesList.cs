using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesUwpTask.Model
{
    internal class NotesList 
    {
        public ObservableCollection<Note> Notes;

        public NotesList()
        {
            Notes = new ObservableCollection<Note>();
        }
    }
}
