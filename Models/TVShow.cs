using Prism.Mvvm;

namespace NET_TVShowPlaylist.Models
{
    /// <summary>
    /// Overview information about a TV show.
    /// </summary>
    public class TVShow : BindableBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="seasons"></param>
        /// <param name="episodes"></param>
        /// <param name="favorite"></param>
        public TVShow(string name, int seasons, int episodes, bool favorite)
        {
            ShowID = new uint();
            Name = name;
            TotalSeasons = seasons;
            TotalEpisodes = episodes;
            Favorite = favorite;
        }

        /// <summary>
        /// Integer identifier for this TV show.
        /// </summary>
        public uint ShowID { get; }

        private string _name;
        /// <summary>
        /// Name of the TV show.
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private int _totalSeasons;
        /// <summary>
        /// Total number of seasons that have been aired and are available to watch.
        /// </summary>
        public int TotalSeasons
        {
            get => _totalSeasons;
            set => SetProperty(ref _totalSeasons, value);
        }

        private int _totalEpisodes;
        /// <summary>
        /// Total number of episodes that have been aired and are available to watch.
        /// </summary>
        public int TotalEpisodes
        {
            get => _totalEpisodes;
            set => SetProperty(ref _totalEpisodes, value);
        }

        private bool _favorite;
        /// <summary>
        /// True if this show is a favorite, otherwise false.
        /// </summary>
        public bool Favorite
        {
            get => _favorite;
            set => SetProperty(ref _favorite, value);
        }
    }
}
