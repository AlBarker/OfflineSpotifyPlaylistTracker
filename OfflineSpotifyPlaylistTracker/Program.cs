// See https://aka.ms/new-console-template for more information
using OfflineSpotifyPlaylistTracker;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

//var playlistManager = new PlaylistManager();
var spotifyService = new SpotifyService();

//playlistManager.StartPlaylist();
var tracks = await spotifyService.GetPlaylistTracks();

//_usernames = new Dictionary<string, UsernameModel>
//            {
//                { "karnage11i", new UsernameModel("Alex Karney", "ak") },
//                { "magsatire", new UsernameModel("Jack McGrath", "jm") },
//                { "1232101260", new UsernameModel("Chris Quigley", "cq") },
//                { "1238290776", new UsernameModel("Joshua Landy", "jl") },
//                { "1233033915", new UsernameModel("Alex Barker", "ab") },
//                { "1244598275", new UsernameModel("Dan Hornblower", "dh") },
//                { "genjamon1234", new UsernameModel("Josh Anderson", "ja") },
//                { "12138108557", new UsernameModel("Veashka Rojas", "vr") },
//                { "gardenbed", new UsernameModel("Georgia Robinson", "gr") },
//                { "billysakalis", new UsernameModel("Billy Sakalis", "bs") },
//                { "braeden.wilson", new UsernameModel("Braeden Wilson", "bw") },
//                { "1278556031", new UsernameModel("Matt Knightbridge", "mk") },
//                { "griffkyn22", new UsernameModel("Griffyn Heels", "gh") }
//            };

Console.Read();