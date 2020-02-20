using Prism.Mvvm;


namespace NET_TVShowPlaylist.Models
{
    /// <summary>
    /// Overview information about any one particular episode of a TV show.
    /// </summary>
    public class Episode : BindableBase
    {
        /// <summary>
        /// Integer identifier for the TV show this episode belongs to.
        /// </summary>
        public uint ShowID { get; set; }

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
    }
}
