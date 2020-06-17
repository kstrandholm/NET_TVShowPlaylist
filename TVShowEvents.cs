﻿using Prism.Events;
using NET_TVShowPlaylist.Models;

namespace NET_TVShowPlaylist
{
	/// <inheritdoc/>
	/// <summary>
	/// Event that indicates TV Show has been selected from the show list on the Main Window.
	/// </summary>
	public class TVShowSelectedEvent : PubSubEvent<TVShow> { }
}