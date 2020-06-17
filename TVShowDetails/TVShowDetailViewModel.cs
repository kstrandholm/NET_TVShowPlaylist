using NET_TVShowPlaylist.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;

namespace NET_TVShowPlaylist.TVShowDetails
{
	public class TVShowDetailViewModel : BindableBase, IDialogAware
	{
		private readonly IEventAggregator _eventAggregator;
		private readonly IRegionManager _regionManager;

		private DelegateCommand<string> _closeDialogCommand;
		public DelegateCommand<string> CloseDialogCommand =>
			_closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

		public string Title => throw new NotImplementedException();

		public event Action<IDialogResult> RequestClose;

		public bool CanCloseDialog() => true;

		/// <summary>
		/// Constructor for a new TV Show Detail Window.
		/// </summary>
		public TVShowDetailViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
		{
			_regionManager = regionManager;
			_eventAggregator = eventAggregator;

			// Subscribe to Events
			_eventAggregator.GetEvent<TVShowSelectedEvent>().Subscribe(TVShowSelected);
		}

		private void CloseDialog(string parameter)
		{
			ButtonResult result = ButtonResult.None;

			if (parameter?.ToLower() == "true")
				result = ButtonResult.OK;
			else if (parameter?.ToLower() == "false")
				result = ButtonResult.Cancel;

			RaiseRequestClose(new DialogResult(result));
		}

		public virtual void RaiseRequestClose(IDialogResult dialogResult)
		{
			RequestClose?.Invoke(dialogResult);
		}

		public void OnDialogClosed()
		{
			throw new NotImplementedException();
		}

		public void OnDialogOpened(IDialogParameters parameters)
		{
			throw new NotImplementedException();
		}

		private void TVShowSelected(TVShow selectedShow)
		{

		}
	}
}
