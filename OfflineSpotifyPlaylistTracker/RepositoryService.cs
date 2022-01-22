using Microsoft.EntityFrameworkCore;
using OfflineSpotifyPlaylistTracker.Domain;
using OfflineSpotifyPlaylistTracker.Domain.Models;

namespace OfflineSpotifyPlaylistTracker
{
    public class RepositoryService
    {
        public Track GetTrack(int number)
        {
            throw new NotImplementedException();
        }

        public async Task AddTracks(IEnumerable<SpotifyTrackModel> tracks)
        {
            using var context = new SpotifyPlaylistTrackerContext();
            var users = await GetUsers();

            var tracksToAdd = tracks.Select(x => new Track
            {
                Id = x.Id,
                Name = x.Name,
                Artist = x.Artist,
                AlbumArt = x.AlbumArt,
                FileName = x.FileName,
                UserId = users.First(u => u.Id == x.UserId).Id,
            });
            await context.Tracks.AddRangeAsync(tracksToAdd);
            await context.SaveChangesAsync();
        }

        public async Task<IList<User>> GetUsers()
        {
            using var context = new SpotifyPlaylistTrackerContext();
            return await context.Users.ToListAsync();
        }

        public async Task ClearAllTracks()
        {
            using var context = new SpotifyPlaylistTrackerContext();
            context.Tracks.RemoveRange(context.Tracks.ToList());

            await context.SaveChangesAsync();
        }

        public async Task DownloadAlbumArt(IEnumerable<SpotifyTrackModel> tracks)
        {
            Console.WriteLine("Starting to download album art. Clearing directory...");
            System.IO.DirectoryInfo di = new DirectoryInfo("C:\\Countdown\\art\\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            Console.WriteLine("Directory cleared");
            foreach (var track in tracks)
            {
                using (HttpClient client = new HttpClient())
                {
                    using (Stream streamToReadFrom = await client.GetStreamAsync(track.AlbumArt))
                    {
                        string fileToWriteTo = Path.GetFullPath($"C:\\Countdown\\art\\{track.FileName}.png");
                        //Console.WriteLine($"Downloading album art from {track.AlbumArt} and writing to {track.FileName}");
                        using (Stream streamToWriteTo = File.Open(fileToWriteTo, FileMode.Create))
                        {
                            await streamToReadFrom.CopyToAsync(streamToWriteTo);
                        }

                        Console.WriteLine($"Finished downloading album art for {track.Name} {track.Artist}");
                    }
                }
            }

            return;
           
        }
    }
}
