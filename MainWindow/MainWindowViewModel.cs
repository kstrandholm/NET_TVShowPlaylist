using Prism.Mvvm;
using System.Collections.Generic;
using NET_TVShowPlaylist.Models;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;

namespace NET_TVShowPlaylist.MainWindow
{
	public class MainWindowViewModel : BindableBase
	{
		private IEventAggregator _eventAggregator;
		private IDialogService _dialogService;

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
		/// Constructor.
		/// </summary>
		public MainWindowViewModel(IEventAggregator eventAggregator, IDialogService dialogService)
		{
			_eventAggregator = eventAggregator;
			_dialogService = dialogService;

			_tvShows = FileImportExport.ImportFiles();
			
			ShowDetailCommand = new DelegateCommand<TVShow>(OpenDetails);
		}

		public void OpenDetails(TVShow selectedShow)
		{
			_dialogService.ShowDialog("TVShowDialog", new DialogParameters(selectedShow.ToString()),
				r =>
				{
					if (r.Result == ButtonResult.None)
						Title = "Result is None";
					else if (r.Result == ButtonResult.OK)
						Title = "Result is OK";
					else if (r.Result == ButtonResult.Cancel)
						Title = "Result is Cancel";
					else
						Title = "I Don't know what you did!?";
				});

			// Raise event to create new TVShowDeatil window instance and pass in show variable.
			_eventAggregator.GetEvent<TVShowSelectedEvent>().Publish(selectedShow);

			return;
		}
	}
}
