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
            Notes = _notesDataBase.Notes.Local.ToObservableCollection();
        }

        public RelayCommand NewCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        NavigationService.Instance.Navigate(typeof(NoteCreatingPage), new AddViewModel());
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
                        Note note = (Note)obj;
                        EditViewModel viewModel = new EditViewModel(note);
                        NavigationService.Instance.Navigate(typeof(NoteEditingPage), viewModel);
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
                        _notesDataBase.Remove(deletedNote);
                        _notesDataBase.SaveChanges();
                    }
                }));
            }
        }

        public void AddNote(Note newNote)
        {
            _notesDataBase.Add(newNote);
            _notesDataBase.SaveChanges();
        }

        public void UpdateNote(Note updatedNote)
        {
            Note temp = _notesDataBase.Notes.Where(note => note.Id == updatedNote.Id).First();
            temp.Title = updatedNote.Title;
            temp.Description = updatedNote.Description;
            _notesDataBase.SaveChanges();
        }
    }
}