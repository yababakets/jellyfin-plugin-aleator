using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Logging;
using Jellyfin.Data.Enums;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Entities.Movies;
using MediaBrowser.Controller.Library;
using MediaBrowser.Model.IO;

namespace Jellyfin.Plugin.Aleator
{
    public class AleatorManager : IDisposable
    {
        private readonly ILibraryManager _libraryManager;
        private readonly Timer _timer;
        private readonly ILogger<AleatorManager> _logger; // TODO logging
        private readonly IFileSystem _fileSystem;

        public AleatorManager(
            ILibraryManager libraryManager,
            ILogger<AleatorManager> logger,
            IFileSystem fileSystem
        )
        {
            _libraryManager = libraryManager;
            _logger = logger;
            _fileSystem = fileSystem;
            _timer = new Timer(_ => OnTimerElapsed(), null, Timeout.Infinite, Timeout.Infinite);
        }

        // Method to display shuffled movies
        public void DisplayShuffledMovies(IProgress<double> progress)
        {
            _logger.LogInformation("Scanning libraries for movies to shuffle.");

            var movies = GetMoviesFromLibrary();

            // Shuffle logic
            var shuffledMovies = movies.OrderBy(x => Guid.NewGuid()).ToList();
            var current = 0;

            foreach (var movie in shuffledMovies)
            {
                current++;
                var percent = current / (double)shuffledMovies.Count * 100;
                progress?.Report((int)percent);

                // Log the displayed movie
                _logger.LogInformation($"Displaying {movie.Name} ({movie.ProductionYear})");
            }

            progress?.Report(100);
        }

        // Method to get movies from library
        private List<Movie> GetMoviesFromLibrary()
        {
            return _libraryManager
                .GetItemList(
                    new InternalItemsQuery
                    {
                        IncludeItemTypes = new[] { BaseItemKind.Movie },
                        IsVirtualItem = false,
                        Recursive = true,
                        HasTmdbId = true,
                    }
                )
                .Select(m => m as Movie)
                .Where(IsEligible)
                .ToList();
        }

        // Eligibility check for movies
        private bool IsEligible(BaseItem item)
        {
            if (
                Plugin.Instance.PluginConfiguration.LocationsExcluded != null
                && Plugin.Instance.PluginConfiguration.LocationsExcluded.Any(s =>
                    _fileSystem.ContainsSubPath(s, item.Path)
                )
            )
            {
                return false;
            }
            return true;
        }

        private void OnTimerElapsed() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _timer?.Dispose();
            }
        }
    }
}
