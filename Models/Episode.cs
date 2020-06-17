using Prism.Mvvm;


namespace NET_TVShowPlaylist.Models
{
	/// <summary>
	/// Overview information about any one particular episode of a TV show.
	/// </summary>
	public class Episode : BindableBase
	{
		/// <summary>
		/// Constructor with the minimum information needed to create a new Episode record.
		/// </summary>
		/// <param name="name">Name of the episode.</param>
		/// <param name="season">Season number this episode belongs to within the TV show.</param>
		/// <param name="episode">Episode number within the season of this TV show.</param>
		/// <param name="length">Length of this episode in minutes.</param>
		/// <param name="watched">True if this episode has been watched, otherwise false.</param>
		public Episode(string name, int season, int episode, int length, bool watched)
		{
			ID = new uint();
			SeasonNum = season;
			EpisodeNum = episode;
			Name = name;
			LengthMinutes = length;
			Watched = watched;
		}

		/// <summary>
		/// Unique identifier for this episode.
		/// </summary>
		public uint ID { get; set; }

		/// <summary>
		/// Season number this episode belongs to within the TV show.
		/// </summary>
		/// <example>Season 3</example>
		public int SeasonNum { get; set; }

		/// <summary>
		/// Episode number within the season of this TV show.
		/// </summary>
		/// <example>Episode 5 of Season 2</example>
		public int EpisodeNum { get; set; }

		/// <summary>
		/// Name of this episode.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Length of this episode in minutes.
		/// </summary>
		public int LengthMinutes { get; set; }

		/// <summary>
		/// True if this episode has been watched, otherwise false.
		/// </summary>
		public bool Watched { get; set; }

		/// <inheritdoc/>
		public override string ToString()
		{
			return Name + " - Season #" + SeasonNum + " Episodes #" + EpisodeNum + " Length: " + LengthMinutes + " minute(s)" +
			(Watched ? " - Watched" : "");
		}
	}
}
