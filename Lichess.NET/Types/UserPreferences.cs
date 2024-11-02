using System.Text.Json.Serialization;

namespace Lichess.NET.Types
{
    public class UserPreferences
    {
        [JsonPropertyName("prefs")]
        public Preferences Preferences = new();

        public string Language = string.Empty;
    }
}
