using OfflineSpotifyPlaylistTracker.Domain.Models;
using SpotifyAPI.Web;
using System.Linq;

namespace OfflineSpotifyPlaylistTracker
{
    public  class SpotifyService
    {

        public SpotifyService()
        {
        }
        public async Task<IEnumerable<Track>> GetPlaylistTracks()
        {
            var client = await GetClient();

            var playlistResponse = await client.Playlists.GetItems("2CuhODa4xTTlemWopeXG71");

            return playlistResponse.Items.Select((v, i) =>
            {
                var track = (FullTrack)v.Track;
                var artists = String.Join(", ", track.Artists.Select(x => x.Name));
                return new Track
                {
                    Id = i,
                    Name = track.Name,
                    Artist = artists,
                    FileName = String.Join(" ", artists, track.Name),
                    AlbumArt = track.Album.Images.FirstOrDefault()?.Url,
                    UserId = v.AddedBy.Id
                };
            });

        }

        private async Task<SpotifyClient> GetClient()
        {
            var config = SpotifyClientConfig.CreateDefault();
            var request = new ClientCredentialsRequest("", "");
            var response = await new OAuthClient(config).RequestToken(request);

            return new SpotifyClient(config.WithToken(response.AccessToken));
        }
    }
}