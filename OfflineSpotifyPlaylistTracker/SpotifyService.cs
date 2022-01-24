using OfflineSpotifyPlaylistTracker.Domain.Models;
using SpotifyAPI.Web;
using System.Linq;
using System.Web;

namespace OfflineSpotifyPlaylistTracker
{
    public  class SpotifyService
    {
        private readonly RepositoryService repositoryService;
        public SpotifyService(RepositoryService repositorySerivce)
        {
            this.repositoryService = repositorySerivce;
        }

        public async Task<IEnumerable<SpotifyTrackModel>> GetPlaylistTracks()
        {
            var client = await GetClient();

            var playlistResponse = await client.Playlists.GetItems("2rdxeAIgVMRLmNHiIAQqmV");

            var users = await repositoryService.GetUsers();

            return playlistResponse.Items.Select((v, i) =>
            {
                var track = (FullTrack)v.Track;
                var artists = String.Join(", ", track.Artists.Select(x => x.Name));
                var fileName = (String.Join(" ", artists, track.Name));
                var sanitisedFileName = fileName.Replace("/", "").Replace("?", "");
                return new SpotifyTrackModel
                {
                    Id = i + 1,
                    Name = track.Name,
                    Artist = artists,
                    FileName = sanitisedFileName,
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

    public class SpotifyTrackModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string FileName { get; set; }
        public string AlbumArt { get; set; }
        public string UserId { get; set; }
    }
}
