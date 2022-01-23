using OfflineSpotifyPlaylistTracker.Domain.Models;
using OfflineSpotifyPlaylistTracker.Extensions;

namespace OfflineSpotifyPlaylistTracker
{
    public class PlaylistManager
    {
        private IPlaybackService playbackService;
        private RepositoryService repositoryService;

        const int CountSongs = 100;

        public PlaylistManager(RepositoryService repositorySerivce)
        {
            playbackService = new PlaybackService();
            repositoryService = repositorySerivce;
        }

        public void StartPlaylist()
        {
            var currentSong = CountSongs;
            
            for (int i = currentSong; i > 0; i--)
            {
                //var track = repositoryService.GetTrackFromTrackPosition(i);
                var track = new Track
                {
                    Name = "Hurricane",
                    FileName = "Aitch, AJ Tracey, Tay Keith Rain",
                };
                if (i % 5 == 0 || i < 5)
                {
                    playbackService.PlayFillerSound(i);

                }
                playbackService.PlaySong(track);
            }
        }

        public async Task ShufflePlaylist()
        {
            var tracks = await repositoryService.GetTracks();
            tracks.Shuffle();

            var trackPositions = new List<TrackPosition>();
            foreach (var (track, i) in tracks.WithIndex())
            {
                trackPositions.Add(new TrackPosition
                {
                    Position = i + 1,
                    TrackId = track.Id
                });
            }

            await repositoryService.ClearAndSaveTrackPositons(trackPositions);
        }
    }
}
