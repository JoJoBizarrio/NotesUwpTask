﻿using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using NotesUwpTask.ViewModel;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesUwpTask.View
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class NoteEditingPage : Page
    {
        public NoteEditingPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null && e.Parameter is EditViewModel model)
            {
                DataContext = model;
            }
        }
    }
}