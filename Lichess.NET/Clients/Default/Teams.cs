﻿using Lichess.NET.Types;

namespace Lichess.NET.Clients.Default
{
    public class TeamsClient : LichessApiClient
    {
        internal TeamsClient() { }

        public async Task<List<Team>> GetUserTeamsAsync(string username)
        {
            var teams = await GetJsonObject<List<Team>>(HttpMethod.Get, "team", "of", username);
            if (teams == null)
                return [];
            return teams;
        }

        public async Task<Team?> GetTeamAsync(string id)
        {
            return await GetJsonObject<Team>(HttpMethod.Get, "team", id);
        }
    }
}