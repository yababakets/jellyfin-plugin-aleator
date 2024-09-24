<h1 align="center">Jellyfin Aleator Plugin</h1>

<p align="center">
The Aleator plugin displays shuffled movies and shows on the home screen from selected libraries;

</p>

## Install Process


## From Repository
1. In jellyfin, go to dashboard -> plugins -> Repositories -> add and paste this link https://raw.githubusercontent.com/yababakets/jellyfin-plugin-aleator-master/master/manifest.json
2. Go to Catalog and search for the plugin you want to install
3. Click on it and install
4. Restart Jellyfin


## From .zip file
1. Download the .zip file from release page
2. Extract it and place the .dll file in a folder called ```plugins/Merge Versions``` under  the program data directory or inside the portable install directory
3. Restart Jellyfin

## User Guide
1. To merge your movies or episodes you can do it from Schedule task or directly from the configuration of the plugin.
2. Spliting is only avaible through the configuration



## Build Process
1. Clone or download this repository
2. Ensure you have .NET Core SDK setup and installed
3. Build plugin with following command.
```sh
dotnet publish --configuration Release --output bin
```
4. Place the resulting .dll file in a folder called ```plugins/Merge versions``` under  the program data directory or inside the portable install directory


