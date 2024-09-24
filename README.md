<h1 align="center">Jellyfin Aleator Plugin</h1>

<p align="center">
The Aleator plugin displays shuffled movies and shows on the home screen from selected libraries.
</p>

## Install Process

### From Repository
1. In Jellyfin, go to dashboard -> plugins -> Repositories -> add and paste this link: https://raw.githubusercontent.com/yababakets/jellyfin-plugin-aleator-master/master/manifest.json

2. Go to Catalog and search for the Aleator plugin.
3. Click on it and install.
4. Restart Jellyfin.

### From .zip file
1. Download the .zip file from the release page.
2. Extract it and place the .dll file in a folder called `plugins/Aleator` under the program data directory or inside the portable install directory.
3. Restart Jellyfin.

## User Guide
1. To display shuffled content from your selected libraries, configure the plugin settings.
2. You can select which libraries to shuffle and how many items to display in a row.

## Build Process
1. Clone or download this repository.
2. Ensure you have the .NET Core SDK set up and installed.
3. Build the plugin with the following command:
   ```sh
   dotnet publish --configuration Release --output bin



