using Lichess.NET.Types.Tokens;
using System.Text.Json;

namespace Lichess.NET.Clients.Default
{
    public class TokensClient : LichessApiClient
    {
        /// <summary>
        /// Client, that works with <a href="https://lichess.org/api#tag/OAuth">OAuth</a> endpoints
        /// </summary>
        internal TokensClient() {}

        /// <summary>
        /// Get's information from given tokens
        /// </summary>
        /// <param name="tokens">array of tokens to test</param>
        /// <returns>Token's information</returns>
        public async Task<Dictionary<string, TokenInfo>> TestTokens(params string[] tokens)
        {
            HttpRequestMessage msg = new(HttpMethod.Post, LICHESS_API_URL + string.Join("/", ["token", "test"]))
            {
                Content = new StringContent(string.Join(",", tokens))
            };
            var r = await (await SendRequestMessage(msg)).Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Dictionary<string, TokenInfo>>(r, SerializerOptions);
            if (result != null)
                return result;
            return [];
        }
    }
}
