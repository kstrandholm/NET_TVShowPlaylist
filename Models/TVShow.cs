using CsvHelper.Configuration.Attributes;
using Prism.Mvvm;
using System.Collections.Generic;

namespace NET_TVShowPlaylist.Models
{
    /// <summary>
    /// Overview information about a TV show.
    /// </summary>
    public class TVShow : BindableBase
    {
        /// <summary>
        /// Constructor with the minimum information needed to create a new TV Show record.
        /// </summary>
        /// <param name="name">Name of the show.</param>
        /// <param name="seasons">Number of seasons in the show.</param>
        /// <param name="episodes">Total number of episodes in the show.</param>
        /// <param name="favorite">Whether this tv show is a favorite show or not.</param>
        public TVShow(string name, int seasons, int episodes, bool favorite, List<Episode> episodeList)
        {
            ID = new uint();
            Name = name;
            TotalSeasons = seasons;
            TotalEpisodes = episodes;
            Favorite = favorite;
            EpisodeList = episodeList;
        }

        /// <summary>
        /// Integer identifier for this TV show.
        /// </summary>
        [Ignore]
        public uint ID { get; }

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

        private List<Episode> _episodeList;
        /// <summary>
        /// List of episodes associated with this TV Show.
        /// </summary>
        public List<Episode> EpisodeList
        {
            get => _episodeList;
            set => SetProperty(ref _episodeList, value);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Name + " - Seasons: " + TotalSeasons + " Episodes: " + TotalEpisodes + (Favorite ? " - Favorite" : "");
        }
    }
}
