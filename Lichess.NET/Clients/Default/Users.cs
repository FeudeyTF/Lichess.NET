using Lichess.NET.Types;
using Lichess.NET.Types.Streams;

namespace Lichess.NET.Clients.Default
{
    /// <summary>
    /// Client, that works with <a href="https://lichess.org/api#tag/Users">Users</a> endpoints
    /// </summary>
    public class UsersClient : LichessApiClient
    {
        internal UsersClient() { }

        /// <summary>
        /// Gets user's public info from <a href="https://lichess.org/api#tag/Users/operation/apiUser">get user public data</a> endpoint
        /// </summary>
        /// <param name="username">User's name</param>
        /// <returns>User's public data</returns>
        public async Task<User?> GetUserAsync(string username)
        {
            return await GetJsonObject<User>(HttpMethod.Get, "user", username);
        }

        /// <summary>
        /// Gets user's public info from <a href="https://lichess.org/api#tag/Users/operation/apiUserRatingHistory">get rating history of a user</a> endpoint
        /// </summary>
        /// <param name="name">User's name</param>
        /// <returns>User's public data</returns>
        public async Task<List<RatingHistoryEntry>?> GetRatingHistory(string name)
        {
            return await GetJsonObject<List<RatingHistoryEntry>>(HttpMethod.Get, "user", name, "rating-history");
        }

        /// <summary>
        /// Gets players status from <a href="https://lichess.org/api#tag/Users/operation/apiUsersStatus">get real-time users status</a> endpoint
        /// </summary>
        /// <param name="names">Names of players</param>
        /// <returns>List of players status</returns>
        public async Task<List<Status>?> GetPlayersStatus(params string[] names)
        {
            return await GetJsonObject<List<Status>>(HttpMethod.Get, "users", "status?ids=", string.Join(",", names));
        }

        /// <summary>
        /// Gets live streams from <a href="https://lichess.org/api#tag/Users/operation/streamerLive">get live streamers</a> endpoint
        /// </summary>
        /// <returns>List of sreams info</returns>
        public async Task<List<StreamInfo>?> GetLiveStreams()
        {
            return await GetJsonObject<List<StreamInfo>>(HttpMethod.Get, "streamer", "live");
        }
    }
}
