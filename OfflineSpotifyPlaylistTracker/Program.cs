// See https://aka.ms/new-console-template for more information
using OfflineSpotifyPlaylistTracker;

var repositorySerivce = new RepositoryService();
var playlistManager = new PlaylistManager();
var spotifyService = new SpotifyService(repositorySerivce);

//playlistManager.StartPlaylist();
await repositorySerivce.ClearAllTracks();
var tracks = await spotifyService.GetPlaylistTracks();
await repositorySerivce.AddTracks(tracks);


Console.Read();