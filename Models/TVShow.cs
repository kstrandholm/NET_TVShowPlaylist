using Prism.Mvvm;


namespace NET_TVShowPlaylist.Models
{
    /// <summary>
    /// Overview information about a TV show.
    /// </summary>
    public class TVShow : BindableBase
    {
        /// <summary>
        /// Integer identifier for this TV show.
        /// </summary>
        public uint ShowID { get; set; }

        /// <summary>
        /// Total number of seasons that have been aired and are available to watch.
        /// </summary>
        public int TotalSeasons { get; set; }

        /// <summary>
        /// Total number of episodes that have been aired and are available to watch.
        /// </summary>
        public int TotalEpisodes { get; set; }

        /// <summary>
        /// True if this show is a favorite, otherwise false.
        /// </summary>
        public bool Favorite { get; set; }
    }
}
