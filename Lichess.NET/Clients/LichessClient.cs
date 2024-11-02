using Lichess.NET.Clients.Default;

namespace Lichess.NET.Clients
{
    /// <summary>
    /// Client for working with Lichess API endpoints, that don't require QAuth token
    /// </summary>
    public class LichessClient : LichessApiClient
    {
        /// <summary>
        /// Client, that works with <a href="https://lichess.org/api#tag/Teams">Teams</a> endpoints
        /// </summary>
        public readonly TeamsClient Teams;

        /// <summary>
        /// Client, that works with <a href="https://lichess.org/api#tag/OAuth">OAuth</a> endpoints
        /// </summary>
        public readonly TokensClient Tokens;

        /// <summary>
        /// Client, that works with <a href="https://lichess.org/api#tag/Users">Users</a> endpoints
        /// </summary>
        public readonly UsersClient Users;

        /// <summary>
        /// Client, that works with <a href="https://lichess.org/api#tag/Arena-tournaments"> Arena Tournaments</a> and <a href="https://lichess.org/api#tag/Swiss-tournaments">Swiss Tournaments</a> endpoints
        /// </summary>
        public readonly TournamentsClient Tournaments;

        public LichessClient()
        {
            Teams = new();
            Tokens = new();
            Users = new();
            Tournaments = new();
        }
    }
}