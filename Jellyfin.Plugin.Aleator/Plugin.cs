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

        private readonly Guid _id = new Guid("eb5d7894-8eef-4b36-aa6f-5d124e828ce1");
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
