using Microsoft.EntityFrameworkCore;
using NotesUwpTask.Model;
using NotesUwpTask.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NotesUwpTask.ViewModel
{
    internal class MainViewModel
    {
        ApplicationContext _notesDataBase = new ApplicationContext();

        RelayCommand _addCommand;
        RelayCommand _editCommand;
        RelayCommand _deleteCommand;

        public ObservableCollection<Note> Notes { get; set; }

        public MainViewModel()
        {
            _notesDataBase.Database.EnsureCreated();
            _notesDataBase.Notes.Load();
            _notesDataBase.Notes.Add(new Note("newNote1", "desc"));
            _notesDataBase.SaveChanges();
            Notes = _notesDataBase.Notes.Local.ToObservableCollection();
        }

        public RelayCommand AddCommnad
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        NavigationService.Instance.Navigate(typeof(NoteCreatingPage));
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
                        NavigationService.Instance.Navigate(typeof(NoteEditingPage), (Note)obj);
                    }));
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(obj =>
                {
                    Note deletedNote = obj as Note;
                    if (deletedNote != null)
                    {
                        _notesDataBase.Notes.Remove(deletedNote);
                        _notesDataBase.SaveChanges();
                    }
                }));
            }
        }
    }
}