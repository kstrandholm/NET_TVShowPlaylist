using Prism.Mvvm;
using System.Collections.Generic;
using NET_TVShowPlaylist.Models;
using System.Linq;

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

        private IEnumerable<TVShow> _tvShows;
        public IEnumerable<TVShow> TVShows
        {
            get => _tvShows;
            set { SetProperty(ref _tvShows, value); }
        }

        public MainWindowViewModel()
        {
            var file = ImportFiles.ImportTVShowFile("..\\..\\ShowInformation\\Shows.csv").ToList();
        }
    }
}
