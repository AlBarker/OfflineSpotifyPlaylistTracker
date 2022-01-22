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
    }
}
