using Lichess.NET.Converters;
using System.Text.Json.Serialization;

namespace Lichess.NET.Types.Arena
{
    [JsonConverter(typeof(TeamBattleConverter))]
    public class TeamBattle
    {
        public Dictionary<string, List<string>>? Teams;

        public int LeadersNumber;
    }
}
