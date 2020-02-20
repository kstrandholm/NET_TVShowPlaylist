﻿using CsvHelper;
using NET_TVShowPlaylist.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace NET_TVShowPlaylist
{
    public static class ImportFiles
    {
        public static List<TVShow> ImportTVShowFile(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = "|";
                var tvShowFile = csv.GetRecords<TVShowFile>().ToList();
                var tvShows = new List<TVShow>();

                foreach (var s in tvShowFile)
                {
                    tvShows.Add(new TVShow(s.Show, s.Seasons, s.Episodes, s.Favorite));
                }

                return tvShows;
            }
        }

        public static IEnumerable<Episode> ImportEpisodeFile(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = true;
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

        /// <summary>
        /// Overview information about a TV show
        /// as used for reading and writing to a file.
        /// </summary>
        private struct TVShowFile
        {
            /// <summary>
            /// Name of the TV show.
            /// </summary>
            public string Show { get;  set; }

            /// <summary>
            /// Total number of seasons that have been aired and are available to watch.
            /// </summary>
            public int Seasons { get;  set; }

            /// <summary>
            /// Total number of episodes that have been aired and are available to watch.
            /// </summary>
            public int Episodes { get;  set; }

            /// <summary>
            /// True if this show is a favorite, otherwise false.
            /// </summary>
            public bool Favorite { get;  set; }
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
