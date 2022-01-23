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
        public IEnumerable<TrackViewModel> Get()
        {
            var tracks = repositoryService.GetPlayedTracks();
        }
    }

    public class TrackViewModel
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public int Position { get; set; }
        public int AddedByName { get; set; }
        public int AddedByImage { get; set; }
        public string AlbumArt { get; set }
    }
}