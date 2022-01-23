using Microsoft.AspNetCore.Mvc;
using OfflineSpotifyPlaylistTracker;

namespace OfflineSpotifyPlaylistTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackController : ControllerBase
    {
        private readonly RepositoryService repositoryService;

        public TrackController()
        {
            repositoryService = new RepositoryService();
        }

        [HttpGet(Name = "GetPlayedTracks")]
        public async Task<IList<TrackViewModel>> GetAsync()
        {
            var tracks = await repositoryService.GetPlayedTracks();

            var mappedTracks = tracks
                .OrderBy(x => x.TrackPosition.Position)
                .Select(x => new TrackViewModel
            {
                Name = x.Name,
                Artist = x.Artist,
                Position = x.TrackPosition.Position,
                AddedByName = x.User.DisplayName,
                AddedByImage = x.User.ImageName,
                AlbumArt = x.AlbumArt
            }).ToList();

            return mappedTracks;
        }
    }

    public class TrackViewModel
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public int Position { get; set; }
        public string AddedByName { get; set; }
        public string AddedByImage { get; set; }
        public string AlbumArt { get; set; }
    }
}