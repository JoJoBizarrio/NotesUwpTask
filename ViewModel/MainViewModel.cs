using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NotesUwpTask.Model;
using NotesUwpTask.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;

namespace NotesUwpTask.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ApplicationContext _notesDataBase = new ApplicationContext();

        RelayCommand _addCommand;
        RelayCommand _editCommand;
        RelayCommand _deleteCommand;
        RelayCommand _sortByAlphabet;

        private ObservableCollection<Note> _notes { get; set; }
        public ObservableCollection<Note> Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged("Notes");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

        public RelayCommand SortByAlphabet
        {
            get
            {
                return _sortByAlphabet ?? (_sortByAlphabet = new RelayCommand(obj =>
                {
                    Notes = Note.SortByAlphabet(Notes);
                   // _notesDataBase.ResetDB(Notes);
                }));
            }
        }

        public void AddNote(Note newNote)
        {
            Notes.Add(newNote);
            _notesDataBase.SaveChanges();
            //_notesDataBase.Add(newNote);
            //_notesDataBase.SaveChanges();
        }

        public void UpdateNote(Note updatedNote)
        {
            Note temp = _notesDataBase.Notes.Where(note => note.Id == updatedNote.Id).First();
            temp.Title = updatedNote.Title;
            temp.Description = updatedNote.Description;
            _notesDataBase.SaveChanges();
        }

        public void ListViewItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                Note note = (Note)e.ClickedItem;
                EditViewModel viewModel = new EditViewModel(note);
                NavigationService.Instance.Navigate(typeof(NoteEditingPage), viewModel);
            }
        }

    }
}