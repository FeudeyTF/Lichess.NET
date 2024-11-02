using Lichess.NET.Types.Puzzles;

namespace Lichess.NET.Clients.Authorized
{
    public partial class PuzzlesClient : LichessAuthClient
    {
        public PuzzlesClient(string token, TokenType tokenType = TokenType.Bearer) : base(token, tokenType)
        {
        }

        public async Task<List<PuzzleActivity>> GetPuzzleActivity(int? max = default, DateTime beforeDate = default)
        {
            string queryParams = Utils.GetQueryParametersString(("max", max), ("before", beforeDate));
            return Utils.ParseNDJsonObject<PuzzleActivity>(await GetQAuthGetRequestContent("puzzle", "activity" + queryParams) ?? "");
        }

        public async Task<PuzzleDashboard?> GetPuzzleDashboard(int days)
        {
            return await GetAuthJsonObject<PuzzleDashboard>(HttpMethod.Get, "puzzle", "dashboard", days.ToString());
        }
    }
}
