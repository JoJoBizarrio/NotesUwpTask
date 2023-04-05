using Microsoft.EntityFrameworkCore;
using NotesUwpTask.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesUwpTask.ViewModel
{
    internal class ApplicationViewModel
    {
        ApplicationContext _notesDataBase = new ApplicationContext();

        RelayCommand _addCommand;
        RelayCommand _editCommand;
        RelayCommand _deleteCommand;

        public ObservableCollection<Note> Notes { get; set; }

        public ApplicationViewModel()
        {
            _notesDataBase.Database.EnsureCreated();
            _notesDataBase.Notes.Load();
            _notesDataBase.Notes.Add(new Note("1", "desc"));
            _notesDataBase.Notes.Add(new Note("1", "desc"));
            _notesDataBase.Notes.Add(new Note("1", "desc"));
            Notes = _notesDataBase.Notes.Local.ToObservableCollection();
        }

        public RelayCommand AddCommnad
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {

                    }));
            }
        }

        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ??
                    (_editCommand = new RelayCommand(obj =>
                    {

                    }));
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                    (_deleteCommand = new RelayCommand(obj =>
                    {

                    }));
            }
        }
    }
}
