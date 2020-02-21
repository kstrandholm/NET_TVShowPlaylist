using CsvHelper;
using NET_TVShowPlaylist.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace NET_TVShowPlaylist
{
    /// <summary>
    /// Class to import and export CSV Files for the TV Shows and Episode lists.
    /// </summary>
    public static class FileImportExport
    {
        private const string SHOWS_FILE_PATH = "..\\..\\ShowInformation\\Shows.csv";
        private const string EPISODES_FILE_PATH = "..\\..\\ShowInformation\\Episodes\\";

        /// <summary>
        /// Import any TV Show and Episodes lists available at the const path.
        /// </summary>
        /// <returns>List of TV Shows and their related episodes.</returns>
        public static List<TVShow> ImportFiles()
        {
            using (var reader = new StreamReader(SHOWS_FILE_PATH))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = "|";

                var tvShowFile = csv.GetRecords<TVShowFile>().ToList();
                var tvShows = new List<TVShow>();
                var episodes = new List<List<Episode>>();

                foreach (var s in tvShowFile)
                {
                    var episodeList = ImportEpisodeFile(s);
                    var show = new TVShow(s.Show, s.Seasons, s.Episodes, s.Favorite, episodeList);
                    tvShows.Add(show);
                }

                return tvShows;
            }
        }

        /// <summary>
        /// Import any Episodes associated with the provided TV Show available at the const path.
        /// </summary>
        /// <param name="show">TV Show to receive the list of episodes for.</param>
        /// <returns>List of episodes associated with the provided TV Show.</returns>
        private static List<Episode> ImportEpisodeFile(TVShowFile show)
        {
            try
            {
                using (var reader = new StreamReader(EPISODES_FILE_PATH + show.Show + ".csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.Delimiter = "|";
                    var episodeFile = csv.GetRecords<EpisodeFile>().ToList();
                    var episodes = new List<Episode>();

                    foreach (var e in episodeFile)
                    {
                        episodes.Add(new Episode(e.Name, e.Season, e.Episode, e.Length, e.Watched));
                    }

                    return episodes;
                }
            }
            catch
            {
                return new List<Episode>();
            }
        }

        /// <summary>
        /// Write out the TV Show's details to a file.
        /// </summary>
        /// <param name="tvShows"></param>
        public static void ExportTVShowFile(IEnumerable<TVShow> tvShows)
        {
            var tvShowFile = new List<TVShowFile>();

            foreach (var show in tvShows)
            {
                tvShowFile.Add(
                    new TVShowFile()
                    {
                        Show = show.Name,
                        Seasons = show.TotalSeasons,
                        Episodes = show.TotalEpisodes,
                        Favorite = show.Favorite
                    });
            }
            // TODO: Optional ConvertFileToModel and ConvertModelToFile methods

            using (var writer = new StreamWriter(SHOWS_FILE_PATH))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = "|";
                csv.WriteRecords(tvShowFile);
            }
        }

        /// <summary>
        /// Write out the TV Show's episode details to a file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="episodes"></param>
        public static void ExportEpisodeFile(string path, IEnumerable<Episode> episodes)
        {
            var episodeFile = new List<EpisodeFile>();

            foreach (var ep in episodes)
            {
                episodeFile.Add(
                    new EpisodeFile()
                    {
                        Episode = ep.EpisodeNum,
                        Name = ep.Name,
                        Length = ep.LengthMinutes,
                        Season = ep.SeasonNum,
                        Watched = ep.Watched
                    });
            }

            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = "|";
                csv.WriteRecords(episodeFile);
            }
        }

        /// <summary>
        /// Overview information about a TV show
        /// as used for reading and writing to a file.
        /// </summary>
        private struct TVShowFile
        {
            /// <summary>
            /// Name of the TV show.
            /// </summary>
            public string Show { get; set; }

            /// <summary>
            /// Total number of seasons that have been aired and are available to watch.
            /// </summary>
            public int Seasons { get; set; }

            /// <summary>
            /// Total number of episodes that have been aired and are available to watch.
            /// </summary>
            public int Episodes { get; set; }

            /// <summary>
            /// True if this show is a favorite, otherwise false.
            /// </summary>
            public bool Favorite { get; set; }
        }

        /// <summary>
        /// Overview information about any one particular episode of a TV show
        /// as used for reading and writing to a file.
        /// </summary>
        private class EpisodeFile
        {
            /// <summary>
            /// Season number this episode belongs to within the TV show.
            /// </summary>
            /// <example>Season 3</example>
            public int Season { get; set; }

            /// <summary>
            /// Episode number within the season of this TV show.
            /// </summary>
            /// <example>Episode 5 of Season 2</example>
            public int Episode { get; set; }

            /// <summary>
            /// Name of this episode.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Length of this episode in minutes.
            /// </summary>
            public int Length { get; set; }

            /// <summary>
            /// True if this episode has been watched, otherwise false.
            /// </summary>
            public bool Watched { get; set; }
        }
    }
}
