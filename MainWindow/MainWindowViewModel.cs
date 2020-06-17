using Prism.Mvvm;
using System.Collections.Generic;
using NET_TVShowPlaylist.Models;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;

namespace NET_TVShowPlaylist.MainWindow
{
	public class MainWindowViewModel : BindableBase
	{
		private IEventAggregator _eventAggregator;

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

		public ICommand ShowDetailCommand { get; private set; }

		/// <summary>
		/// Constructor
		/// </summary>
		public MainWindowViewModel()
		{
			_eventAggregator = new EventAggregator();

			_tvShows = FileImportExport.ImportFiles();
			
			ShowDetailCommand = new DelegateCommand<TVShow>(OpenDetails);
		}

		public void OpenDetails(TVShow selectedShow)
		{
			var show = _tvShows.SingleOrDefault(s => s.Name == selectedShow.Name);

			// Raise event to create new TVShowDeatil window instance and pass in show variable
			_eventAggregator.GetEvent<TVShowSelectedEvent>().Publish(selectedShow);

			return;
		}
	}
}
