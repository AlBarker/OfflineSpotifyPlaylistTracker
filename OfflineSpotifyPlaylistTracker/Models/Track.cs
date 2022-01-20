namespace OfflineSpotifyPlaylistTracker.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string FileName { get; set; }
        public string AlbumArt { get; set; }
        public string UserId { get; set; }
    }
}
