using Lichess.NET.Types;

namespace Lichess.NET.Clients.Authorized
{
    /// <summary>
    /// Client, that works with <a href="https://lichess.org/api#tag/Account">Account</a> endpoints
    /// </summary>
    public class AccountClient : LichessAuthClient
    {
        public AccountClient(string token, TokenType tokenType = TokenType.Bearer) : base(token, tokenType)
        {
        }

        /// <summary>
        /// Gets user's profile from <a href="https://lichess.org/api#tag/Account/operation/accountMe">get my profile</a> endpoint
        /// </summary>
        /// <returns>User's profile</returns>
        public async Task<User?> GetProfile()
            => await GetAuthJsonObject<User>(HttpMethod.Get, "account");

        /// <summary>
        /// Gets user's email from <a href="https://lichess.org/api#tag/Account/operation/accountEmail">get my email</a> endpoint
        /// </summary>
        /// <returns>User's email</returns>
        public async Task<string> GetEmailAddress()
            => (await GetAuthJsonObject<Email>(HttpMethod.Get, "account")).EmailAddress;

        /// <summary>
        /// Gets user's preferences from <a href="https://lichess.org/api#tag/Account/operation/account">get my preferences</a> endpoint
        /// </summary>
        /// <returns>User's preferences</returns>
        public async Task<UserPreferences?> GetPreferences()
            => await GetAuthJsonObject<UserPreferences>(HttpMethod.Get, "account", "preferences");

        /// <summary>
        /// Gets user's kid status from <a href="https://lichess.org/api#tag/Account/operation/accountKid">get my kid mode status</a> endpoint
        /// </summary>
        /// <returns>User's kid status</returns>
        public async Task<bool> IsKid()
            => (await GetAuthJsonObject<IsKid>(HttpMethod.Get, "account", "preferences")).Kid;
    }
}