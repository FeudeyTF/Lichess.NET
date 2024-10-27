using Lichess.NET.Converters.Scopes;
using System.Text.Json.Serialization;

namespace Lichess.NET.Types.Tokens
{
    public class TokenInfo
    {
        public string UserID = string.Empty;

        [JsonConverter(typeof(TokenScopesConverter))]
        public List<TokenScope> Scopes = [];

        public DateTime? Expires;
    }
}
