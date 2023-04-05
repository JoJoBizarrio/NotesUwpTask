using NotesUwpTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesUwpTask.ViewModel
{
    internal class AddViewModel
    {
        public Note NewNote = new Note();

        RelayCommand _addCoomand;
        RelayCommand _cancelCommand;

        public RelayCommand AddCommand
        {
            get 
            {
                return _addCoomand ?? (_addCoomand = new RelayCommand(obj =>
                {
                    NavigationService.Instance.Navigate(typeof(MainPage), NewNote);
                })); 
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand(obj =>
                {
                    NavigationService.Instance.Navigate(typeof(MainPage));
                }));
            }
        }
    }
}