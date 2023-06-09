﻿using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using NotesUwpTask.ViewModel;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace NotesUwpTask
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel {  get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null && e.Parameter is MainViewModel model)
            {
                ViewModel = model;
                DataContext = model;
            }
        }
    }
}