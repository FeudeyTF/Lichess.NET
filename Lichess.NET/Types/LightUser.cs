using Lichess.NET.Clients;

namespace Lichess.NET.Types
{
    public class LightUser
    {
        public string ID = string.Empty;

        public string Name = string.Empty;

        public string Flair = string.Empty;

        public async Task<User?> GetFullUser(LichessClient client)
            => await client.GetUserAsync(Name);
    }
}
