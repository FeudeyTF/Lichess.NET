using System.Text.Json.Serialization;

namespace Lichess.NET.Types.Arena
{
    public class Variant
    {
        public string Key = string.Empty;

        [JsonPropertyName("_short")]
        public string Short = string.Empty;

        public string Name = string.Empty;
    }
}
