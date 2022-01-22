// See https://aka.ms/new-console-template for more information
using OfflineSpotifyPlaylistTracker;

var repositorySerivce = new RepositoryService();
var playlistManager = new PlaylistManager();
var spotifyService = new SpotifyService(repositorySerivce);

//var args = Environment.GetCommandLineArgs();

if (args.Length == 0)
{
	Console.WriteLine("At least one argument is required");
	return;
}

var command = args[0];

switch (command)
{
	case "start":
		playlistManager.StartPlaylist();
		break;
	case "init-playlist":
        await repositorySerivce.ClearAllTracks();
        var tracks = await spotifyService.GetPlaylistTracks();
        await repositorySerivce.AddTracks(tracks);
        await repositorySerivce.DownloadAlbumArt(tracks);
		break;
	default:
		Console.WriteLine("Invalid command");
		break;
}
