using System;
using System.Collections.Generic;
using Jellyfin.Plugin.Aleator.Configuration;
using MediaBrowser.Controller;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using MediaBrowser.Common.Plugins;

namespace Jellyfin.Plugin.Aleator
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages 
    {
        public Plugin(IServerApplicationPaths appPaths, IXmlSerializer xmlSerializer)
            : base(appPaths, xmlSerializer)
        {
            Instance = this;
        }

        public override string Name => "Aleator";

        public static Plugin Instance { get; private set; }

        public override string Description
            => "Aleator: Display shuffled content from your libraries on the home screen.";

        public PluginConfiguration PluginConfiguration => Configuration;

        private readonly Guid _id = new Guid("e9a8b6c0-3a6b-4e1e-a7e6-63d03a45893b");
        public override Guid Id => _id;

        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new[]
            {
                new PluginPageInfo
                {
                    Name = "Aleator",
                    EmbeddedResourcePath = GetType().Namespace + ".Configuration.configurationpage.html"
                }
            };
        }
    }
}
