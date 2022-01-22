using OfflineSpotifyPlaylistTracker.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineSpotifyPlaylistTracker
{
    public interface IRepositoryService
    {
        Track GetTrack(int number);
    }
    public class RepositoryService : IRepositoryService
    {
        public Track GetTrack(int number)
        {
            throw new NotImplementedException();
        }
    }
}
