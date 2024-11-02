using Lichess.NET.Types.Arena;
using Lichess.NET.Types.Swiss;

namespace Lichess.NET.Clients.Default
{
    /// <summary>
    /// Client, that works with <a href="https://lichess.org/api#tag/Arena-tournaments"> Arena Tournaments</a> and <a href="https://lichess.org/api#tag/Swiss-tournaments">Swiss Tournaments</a> endpoints
    /// </summary>
    public class TournamentsClient : LichessApiClient
    {
        internal TournamentsClient() { }

        /// <summary>
        /// Gets team's arena tournaments by ID from <a href="https://lichess.org/api#tag/Arena-tournaments/operation/apiTeamArena">get team Arena tournaments</a> endpoint
        /// </summary>
        /// <param name="teamId">ID of a team</param>
        /// <returns>List of arena tournaments</returns>
        public async Task<List<ArenaTournament>> GetTeamArenaTournaments(string teamId)
            => await GetNDJsonObject<ArenaTournament>(new StreamReader(await GetFileAsync("team", teamId, "arena")));

        /// <summary>
        /// Gets team's swiss tournaments by ID from <a href="https://lichess.org/api#tag/Swiss-tournaments/operation/apiTeamSwiss">get team swiss tournaments</a> endpoint
        /// </summary>
        /// <param name="teamId">ID of a team</param>
        /// <returns>List of swiss tournaments</returns>
        public async Task<List<SwissTournament>> GetTeamSwissTournaments(string teamId)
            => await GetNDJsonObject<SwissTournament>(new StreamReader(await GetFileAsync("team", teamId, "swiss")));

        /// <summary>
        /// Gets arena tournament by ID from <a href="https://lichess.org/api#tag/Arena-tournaments/operation/tournament">get info about an Arena tournament</a> endpoint
        /// </summary>
        /// <param name="id">ID of an arena tournament</param>
        /// <returns>Arena tournament</returns>
        public async Task<ArenaTournament?> GetTournament(string id)
            => await GetJsonObject<ArenaTournament>(HttpMethod.Get, "tournament", id);

        /// <summary>
        /// Gets arena tournament results by ID from <a href="https://lichess.org/api#tag/Arena-tournaments/operation/resultsByTournament">get results of an Arena tournament</a> endpoint
        /// </summary>
        /// <param name="id">ID of an arena tournament</param>
        /// <param name="full">Add a sheet field to the player document. It's an expensive server computation that slows down the stream</param>
        /// <returns>Arena tournament results</returns>
        public async Task<List<SheetEntry>> GetTournamentSheet(string id, bool full = false)
            => await GetNDJsonObject<SheetEntry>("tournament", id, "results?sheet=" + full);

        /// <summary>
        /// Gets arena tournament results from file
        /// </summary>
        /// <param name="reader">Stream reader of a file</param>
        /// <returns>Arena tournament results</returns>
        public async Task<List<SheetEntry>> GetTournamentSheet(StreamReader reader)
            => await GetNDJsonObject<SheetEntry>(reader);

        /// <summary>
        /// Gets swiss tournament by ID from <a href="https://lichess.org/api#tag/Swiss-tournaments/operation/swiss">get info about an Swiss tournament</a> endpoint
        /// </summary>
        /// <param name="id">ID of a swiss tournament</param>
        /// <returns>Swiss tournament</returns>
        public async Task<SwissTournament?> GetSwissTournament(string id)
            => await GetJsonObject<SwissTournament>(HttpMethod.Get, "swiss", id);

        /// <summary>
        /// Gets swiss tournament results from file
        /// </summary>
        /// <param name="reader">Stream reader of a file</param>
        /// <returns>Swiss tournament results</returns>
        public async Task<List<SwissSheetEntry>> GetSwissTournamentSheet(StreamReader reader)
            => await GetNDJsonObject<SwissSheetEntry>(reader);

        /// <summary>
        /// Gets swiss tournament results by ID from <a href="https://lichess.org/api#tag/Swiss-tournaments/operation/resultsBySwiss">get results of a Swiss tournament</a> endpoint
        /// </summary>
        /// <param name="id">ID of a swiss tournament</param>
        /// <param name="number">Max number of players to fetch</param>
        /// <returns>Swiss tournament results</returns>
        public async Task<List<SwissSheetEntry>> GetSwissTournamentSheet(string id, int number = -1)
            => number == -1 ?
                await GetNDJsonObject<SwissSheetEntry>("swiss", id, "results") :
                await GetNDJsonObject<SwissSheetEntry>("swiss", id, "results?nb=" + number);

        /// <summary>
        /// Saves arena tournament results from <a href="https://lichess.org/api#tag/Arena-tournaments/operation/resultsByTournament">get results of an Arena tournament</a> endpoint
        /// </summary>
        /// <param name="path">Path for saving</param>
        /// <param name="id">ID of an arena tournament</param>
        /// <param name="full">Add a sheet field to the player document. It's an expensive server computation that slows down the stream</param>
        /// <returns>Nothing</returns>
        public async Task SaveTournamentSheet(string path, string id, bool full = false)
        {
            var stream = await GetFileAsync("tournament", id, "results?sheet=" + full);
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }
            stream.Close();
        }

        /// <summary>
        /// Saves swiss tournament results from <a href="https://lichess.org/api#tag/Swiss-tournaments/operation/resultsBySwiss">get results of a Swiss tournament</a> endpoint
        /// </summary>
        /// <param name="path">Path for saving</param>
        /// <param name="id">ID of a swiss tournament</param>
        /// <param name="number">Max number of players to fetch</param>
        /// <returns>Nothing</returns>
        public async Task SaveSwissTournamentSheet(string path, string id, int number = -1)
        {
            var stream = number == -1 ? await GetFileAsync("swiss", id, "results") :
                                        await GetFileAsync("swiss", id, "results?nb=" + number); ;
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }
            stream.Close();
        }
    }
}