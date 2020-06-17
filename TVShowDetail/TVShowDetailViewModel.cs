using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Events;
using NET_TVShowPlaylist.Models;

namespace NET_TVShowPlaylist.TVShowDetail
{
	public class TVShowDetailViewModel : BindableBase
	{
		private readonly IEventAggregator _eventAggregator;

		/// <summary>
		/// Constructor for a new TV Show Detail Window
		/// </summary>
		public TVShowDetailViewModel(IEventAggregator eventAggregator)
		{
			_eventAggregator = eventAggregator;
			_eventAggregator.GetEvent<TVShowSelectedEvent>().Subscribe(TVShowSelected);
		}

		private void TVShowSelected(TVShow selectedShow)
		{

		}
	}
}
