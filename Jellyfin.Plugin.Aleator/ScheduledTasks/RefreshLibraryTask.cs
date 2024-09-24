using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Controller.Library;
using MediaBrowser.Model.IO;
using MediaBrowser.Model.Tasks;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Plugin.Aleator.ScheduledTasks
{
    public class ShuffleMoviesTask : IScheduledTask
    {
        private readonly ILogger _logger;
        private readonly AleatorManager _aleatorManager;

        public ShuffleMoviesTask(
            ILibraryManager libraryManager,
            ILogger<AleatorManager> logger,
            IFileSystem fileSystem
        )
        {
            _logger = logger;
            _aleatorManager = new AleatorManager(libraryManager, logger, fileSystem);
        }

        public Task Execute(CancellationToken cancellationToken, IProgress<double> progress)
        {
            _logger.LogInformation("Starting plugin, Shuffling Movies");
            _aleatorManager.DisplayShuffledMovies(progress); // Replace MergeMovies with DisplayShuffledMovies
            _logger.LogInformation("Movies shuffled and displayed");
            return Task.CompletedTask;
        }

        public IEnumerable<TaskTriggerInfo> GetDefaultTriggers()
        {
            // Run this task every 24 hours
            return new[]
            {
                new TaskTriggerInfo
                {
                    Type = TaskTriggerInfo.TriggerInterval,
                    IntervalTicks = TimeSpan.FromHours(24).Ticks
                }
            };
        }

        public Task ExecuteAsync(IProgress<double> progress, CancellationToken cancellationToken)
        {
            return Execute(cancellationToken, progress);
        }

        public string Name => "Shuffle and Display Movies";
        public string Key => "ShuffleMoviesTask";
        public string Description => "Scans libraries and shuffles movies to display on the home screen";
        public string Category => "Aleator";
    }

    public class ShuffleEpisodesTask : IScheduledTask
    {
        private readonly ILogger _logger;
        private readonly AleatorManager _aleatorManager;

        public ShuffleEpisodesTask(
            ILibraryManager libraryManager,
            ILogger<AleatorManager> logger,
            IFileSystem fileSystem
        )
        {
            _logger = logger;
            _aleatorManager = new AleatorManager(libraryManager, logger, fileSystem);
        }

        public async Task Execute(CancellationToken cancellationToken, IProgress<double> progress)
        {
            _logger.LogInformation("Starting plugin, Shuffling Episodes");
            _aleatorManager.DisplayShuffledMovies(progress); // Adjust if separate episode shuffling logic is required
            _logger.LogInformation("Episodes shuffled and displayed");
            await Task.CompletedTask;
        }

        public IEnumerable<TaskTriggerInfo> GetDefaultTriggers()
        {
            // Run this task every 24 hours
            return new[]
            {
                new TaskTriggerInfo
                {
                    Type = TaskTriggerInfo.TriggerInterval,
                    IntervalTicks = TimeSpan.FromHours(24).Ticks
                }
            };
        }

        public Task ExecuteAsync(IProgress<double> progress, CancellationToken cancellationToken)
        {
            return Execute(cancellationToken, progress);
        }

        public string Name => "Shuffle and Display Episodes";
        public string Key => "ShuffleEpisodesTask";
        public string Description => "Shuffles episodes from libraries and displays them on the home screen";
        public string Category => "Aleator";
    }
}
