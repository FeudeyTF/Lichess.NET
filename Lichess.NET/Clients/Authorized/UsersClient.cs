using Lichess.NET.Types;

namespace Lichess.NET.Clients.Authorized
{
    public class UsersClient : LichessAuthClient
    {
        public UsersClient(string token, TokenType tokenType = TokenType.Bearer) : base(token, tokenType)
        {
        }

        public async Task<User?> GetUserInfo()
        {
            return await GetAuthJsonObject<User>(HttpMethod.Get, "account");
        }
    }
}
