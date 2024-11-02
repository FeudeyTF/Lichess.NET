using Lichess.NET.Types;

namespace Lichess.NET.Clients.Default
{
    public class TeamsClient : LichessApiClient
    {
        /// <summary>
        /// Client, that works with <a href="https://lichess.org/api#tag/Teams">Teams</a> endpoints
        /// </summary>
        internal TeamsClient() { }

        /// <summary>
        /// Gets user's teams from <a href="https://lichess.org/api#tag/Teams/operation/teamOfUsername">get teams of a player</a> endpoint
        /// </summary>
        /// <param name="username">User's name</param>
        /// <returns>User's teams</returns>
        public async Task<List<Team>> GetUserTeamsAsync(string username)
        {
            var teams = await GetJsonObject<List<Team>>(HttpMethod.Get, "team", "of", username);
            if (teams == null)
                return [];
            return teams;
        }

        /// <summary>
        /// Gets team by ID from <a href="https://lichess.org/api#tag/Teams/operation/teamShow">get a single team</a> endpoint
        /// </summary>
        /// <param name="username">ID of a team</param>
        /// <returns>Team's info</returns>
        public async Task<Team?> GetTeamAsync(string id)
        {
            return await GetJsonObject<Team>(HttpMethod.Get, "team", id);
        }
    }
}
