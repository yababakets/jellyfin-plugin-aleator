using MediaBrowser.Model.Plugins;
using System;

namespace Jellyfin.Plugin.Aleator.Configuration
{
    public class PluginConfiguration : BasePluginConfiguration
    {
        // Array to hold the locations excluded from shuffling
        public string[] LocationsExcluded { get; set; }

        // Property to hold the number of items to display in a row
        public int ItemCount { get; set; }

        public PluginConfiguration()
        {
            LocationsExcluded = Array.Empty<string>();
            ItemCount = 3; // Default value for item count
        }
    }
}
