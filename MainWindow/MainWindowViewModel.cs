using Prism.Mvvm;
using System.Collections.Generic;

namespace NET_TVShowPlaylist.MainWindow
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get => _title; 
            set { SetProperty(ref _title, value); }
        }

        private IEnumerable<Models.TVShow> _tvShows;
        public IEnumerable<Models.TVShow> TVShows
        {
            get => _tvShows;
            set { SetProperty(ref _tvShows, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
