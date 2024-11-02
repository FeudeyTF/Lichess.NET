using Lichess.NET.Types;
using Lichess.NET.Types.Streams;

namespace Lichess.NET.Clients.Default
{
    public class UsersClient : LichessApiClient
    {
        internal UsersClient() { }

        public async Task<User?> GetUserAsync(string username)
        {
            return await GetJsonObject<User>(HttpMethod.Get, "user", username);
        }

        public async Task<List<RatingHistoryEntry>?> GetRatingHistory(string name)
        {
            return await GetJsonObject<List<RatingHistoryEntry>>(HttpMethod.Get, "user", name, "rating-history");
        }

        public async Task<List<Status>?> GetPlayersStatus(params string[] names)
        {
            return await GetJsonObject<List<Status>>(HttpMethod.Get, "users", "status?ids=", string.Join(",", names));
        }

        public async Task<List<StreamInfo>?> GetLiveStreams()
        {
            return await GetJsonObject<List<StreamInfo>>(HttpMethod.Get, "streamer", "live");
        }
    }
}
