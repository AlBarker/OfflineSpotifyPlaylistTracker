using Microsoft.AspNetCore.Mvc;
using OfflineSpotifyPlaylistTracker;

namespace OfflineSpotifyPlaylistTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly RepositoryService repositoryService;

        public TrackController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            repositoryService = new RepositoryService();
        }

        [HttpGet(Name = "GetPlayedTracks")]
        public async Task<IEnumerable<TrackViewModel>> Get()
        {
            var tracks = await repositoryService.GetPlayedTracks();

            return tracks
                .OrderBy(x => x.TrackPosition.Position)
                .Select(x => new TrackViewModel
            {
                Name = x.Name,
                Artist = x.Artist,
                Position = x.TrackPosition.Position,
                AddedByName = x.User.DisplayName,
                AddedByImage = x.User.ImageName,
                AlbumArt = x.AlbumArt
            });
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