// See https://aka.ms/new-console-template for more information
using OfflineSpotifyPlaylistTracker;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

var playlistManager = new PlaylistManager();
playlistManager.StartPlaylist();

Console.Read();