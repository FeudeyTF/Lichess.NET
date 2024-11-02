using Lichess.NET.Types;

namespace Lichess.NET.Clients.Authorized
{
    public class AccountClient : LichessAuthClient
    {
        public AccountClient(string token, TokenType tokenType = TokenType.Bearer) : base(token, tokenType)
        {
        }

        public async Task<User?> GetProfile()
            => await GetAuthJsonObject<User>(HttpMethod.Get, "account");

        public async Task<string> GetEmailAddress()
            => (await GetAuthJsonObject<Email>(HttpMethod.Get, "account")).EmailAddress;

        public async Task<UserPreferences?> GetPreferences()
            => await GetAuthJsonObject<UserPreferences>(HttpMethod.Get, "account", "preferences");

        public async Task<bool> IsKid()
            => (await GetAuthJsonObject<IsKid>(HttpMethod.Get, "account", "preferences")).Kid;
    }
}