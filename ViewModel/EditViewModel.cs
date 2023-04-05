using NotesUwpTask.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NotesUwpTask.ViewModel
{
    internal class EditViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public Note ENote { get; set; } 

        RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get => _saveCommand ?? (_saveCommand = new RelayCommand(obj =>
            {
                Note note = new Note(Id, Title, Description);
                MainViewModel mainViewModel = new MainViewModel();
                mainViewModel.UpdateNote(note);
                NavigationService.Instance.Navigate(typeof(MainPage), mainViewModel);
            }));
        }

        RelayCommand _cancelCommand;
        public RelayCommand CancelCommand
        {
            get => _cancelCommand ?? (_cancelCommand = new RelayCommand(obj =>
            {
                MainViewModel mainViewModel = new MainViewModel();
                NavigationService.Instance.Navigate(typeof(MainPage), mainViewModel);
            }));
        }

        public EditViewModel(Note note)
        {
            ENote = note;
            Id = note.Id;
            Title = note.Title;
            Description = note.Description;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}