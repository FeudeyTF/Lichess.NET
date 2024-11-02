using Lichess.NET.Types.Puzzles;

namespace Lichess.NET.Clients.Authorized
{
    /// <summary>
    /// Client, that works with <a href="https://lichess.org/api#tag/Puzzles">Puzzles</a> endpoints
    /// </summary>
    public partial class PuzzlesClient : LichessAuthClient
    {
        public PuzzlesClient(string token, TokenType tokenType = TokenType.Bearer) : base(token, tokenType)
        {
        }

        /// <summary>
        /// Gets user's puzzle activity from <a href="https://lichess.org/api#tag/Puzzles/operation/apiPuzzleActivity">get your puzzle activity</a> endpoint
        /// </summary>
        /// <param name="max">How many entries to download. Defaults download all activity.</param>
        /// <param name="beforeDate">Download entries before this date. Defaults to now</param>
        /// <returns>User's puzzle activity</returns>
        public async Task<List<PuzzleActivity>> GetPuzzleActivity(int? max = default, DateTime beforeDate = default)
        {
            string queryParams = Utils.GetQueryParametersString(("max", max), ("before", beforeDate));
            return Utils.ParseNDJsonObject<PuzzleActivity>(await GetQAuthGetRequestContent("puzzle", "activity" + queryParams) ?? "");
        }

        /// <summary>
        /// Gets user's puzzle dashboard from <a href="https://lichess.org/api#tag/Puzzles/operation/apiPuzzleDashboard">get your puzzle dashboard</a> endpoint
        /// </summary>
        /// <param name="days">How many days to look back when aggregating puzzle results</param>
        /// <returns>User's puzzle dashboard</returns>
        public async Task<PuzzleDashboard?> GetPuzzleDashboard(int days)
        {
            return await GetAuthJsonObject<PuzzleDashboard>(HttpMethod.Get, "puzzle", "dashboard", days.ToString());
        }
    }
}
