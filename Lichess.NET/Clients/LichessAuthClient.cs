using Lichess.NET.Clients.Authorized;

namespace Lichess.NET.Clients
{
    /// <summary>
    /// Client for working with Lichess API endpoints, that require QAuth token
    /// </summary>
    public partial class LichessAuthClient : LichessApiClient
    {
        public readonly string QAuthToken;

        public readonly TokenType TokenType;

        /// <summary>
        /// Common client, that works with endpoints, which doesn't require tokens 
        /// </summary>
        public readonly LichessClient Default;

        /// <summary>
        /// Client, that works with <a href="https://lichess.org/api#tag/Puzzles">Puzzles</a> endpoints
        /// </summary>
        public readonly PuzzlesClient Puzzles;

        /// <summary>
        /// Client, that works with <a href="https://lichess.org/api#tag/Account">Account</a> endpoints
        /// </summary>
        public AccountClient Users;

        /// <param name="token"><a href="https://lichess.org/api#section/Introduction/Authentication">QAuth token</a> of a client</param>
        /// <param name="tokenType">Type of a token. Default is Bearer type</param>
        public LichessAuthClient(string token, TokenType tokenType = TokenType.Bearer)
        {
            QAuthToken = token;
            TokenType = tokenType;
            Default = new();
            Puzzles = new(token, tokenType);
            Users = new(token, tokenType);
        }

        protected async Task<string?> GetQAuthPostRequestContent(params string[] path)
            => await (await SendQAuthRequest(HttpMethod.Post, path, [])).Content.ReadAsStringAsync();

        protected async Task<string?> GetQAuthGetRequestContent(params string[] path)
            => await (await SendQAuthRequest(HttpMethod.Get, path, [])).Content.ReadAsStringAsync();

        protected async Task<HttpResponseMessage> SendQAuthPostRequest(params string[] path)
            => await SendQAuthRequest(HttpMethod.Post, path, []);

        protected async Task<HttpResponseMessage> SendQAuthGetRequest(params string[] path)
            => await SendQAuthRequest(HttpMethod.Get, path, []);

        protected async Task<HttpResponseMessage> SendQAuthPostRequest(string[] path, params (string name, string value)[] headers)
            => await SendQAuthRequest(HttpMethod.Post, path, headers);

        protected async Task<HttpResponseMessage> SendQAuthGetRequest(string[] path, params (string name, string value)[] headers)
            => await SendQAuthRequest(HttpMethod.Get, path, headers);

        protected async Task<HttpResponseMessage> SendQAuthRequest(HttpMethod method, string[] path, params (string name, string value)[] headers)
        {
            HttpRequestMessage msg = new(method, LICHESS_API_URL + string.Join("/", path));
            msg.Headers.Add("Authorization", $"{TokenType} {QAuthToken}");
            foreach (var (name, value) in headers)
                msg.Headers.Add(name, value);
            return await SendRequestMessage(msg);
        }

        protected async Task<TValue?> GetAuthJsonObject<TValue>(HttpMethod method, params string[] path)
            => await GetAuthJsonObject<TValue>(method, path, []);

        protected async Task<TValue?> GetAuthJsonObject<TValue>(HttpMethod method, string[] path, params (string name, string value)[] headers)
        {
            var respone = await SendQAuthRequest(method, path, headers);
            return await GetJsonObject<TValue>(respone);
        }
    }
}
