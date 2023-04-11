﻿using NotesUwpTask.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NotesUwpTask.ViewModel
{
    internal class AddViewModel : INotifyPropertyChanged
    {
        public Note NewNote = new Note();

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

        RelayCommand _addCoomand;
        RelayCommand _cancelCommand;

        public RelayCommand AddCommand
        {
            get 
            {
                return _addCoomand ?? (_addCoomand = new RelayCommand(obj =>
                {
                    Note note = new Note(Title, Description);

                    if (string.IsNullOrEmpty(note.Title))
                    {
                        note.Title = "Empty title's note";
                    }

                    MainViewModel mainViewModel = new MainViewModel();
                    mainViewModel.AddNote(note);
                    NavigationService.Instance.Navigate(typeof(MainPage), mainViewModel);
                })); 
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand(obj =>
                {
                    MainViewModel mainViewModel = new MainViewModel();
                    NavigationService.Instance.Navigate(typeof(MainPage), mainViewModel);
                }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName="")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}