﻿using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using NotesUwpTask.ViewModel;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesUwpTask.View
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class NoteCreatingPage : Page
    {
        public NoteCreatingPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (AddViewModel)e.Parameter;
        }
    }
}