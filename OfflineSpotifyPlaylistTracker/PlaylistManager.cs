using OfflineSpotifyPlaylistTracker.Domain.Models;
using OfflineSpotifyPlaylistTracker.Models;

namespace OfflineSpotifyPlaylistTracker
{
    public class PlaylistManager
    {
        private IPlaybackService _playbackService;
        private IRepositoryService _repositoryService;

        const int CountSongs = 100;

        public PlaylistManager()
        {
            _playbackService = new PlaybackService();
            _repositoryService = new RepositoryService();
        }

        public void StartPlaylist()
        {
            var currentSong = CountSongs;
            
            for (int i = currentSong; i > 0; i--)
            {
                //var track = _repositoryService.GetTrack(i);
                var track = new Track
                {
                    Name = "Hurricane",
                    FileName = "Aitch, AJ Tracey, Tay Keith Rain",
                };
                _playbackService.PlayFillerSound(i);
                _playbackService.PlaySong(track);
            }
        }

    }
}
