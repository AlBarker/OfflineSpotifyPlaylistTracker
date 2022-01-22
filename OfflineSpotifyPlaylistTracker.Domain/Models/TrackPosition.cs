using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineSpotifyPlaylistTracker.Domain.Models
{
    public class TrackPosition
    {
        public int Position { get; set; }
        public int TrackId { get; set; }
        public virtual Track Track { get; set; }
    }
}
