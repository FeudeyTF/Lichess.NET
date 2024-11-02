using Lichess.NET.Clients.Default;

namespace Lichess.NET.Clients
{
    public class LichessClient : LichessApiClient
    {
        public readonly TeamsClient Teams;

        public readonly TokensClient Tokens;

        public readonly UsersClient Users;

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