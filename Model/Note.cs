using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NotesUwpTask.Model
{
    public class Note : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _title;
        private string _description;

        public string Title
        {
            get { return _title; }

            set
            {
                _title = value;
                OnPropertyChange();
            }
        }

        public string Description
        {
            get { return _description; }

            set
            {
                _description = value;
                OnPropertyChange();
            }
        }

        public Note(string title = "", string description = "")
        {
            Title = title;
            Description = description;
        }

        public Note(int id, string title = "", string description = "")
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        static public ObservableCollection<Note> SortByAlphabet(ObservableCollection<Note> Notes)
        {
            return new ObservableCollection<Note>(Notes.OrderBy(note => note.Title));
        }
    }
}