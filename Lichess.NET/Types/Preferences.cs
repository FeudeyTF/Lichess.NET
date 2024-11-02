using System.Text.Json.Serialization;

namespace Lichess.NET.Types
{
    public class Preferences
    {
        public bool Dark;

        [JsonPropertyName("transp")]
        public bool Transparent;

        [JsonPropertyName("bgImg")]
        public string BackgroundImage = string.Empty;

        public bool Is3D;

        public string Theme = string.Empty;

        public string PieceSet = string.Empty;

        public string Theme3d = string.Empty;

        public string PieceSet3D = string.Empty;

        public string SoundSet = string.Empty;

        public int AutoQueen;

        public int AutoThreefold;

        public int Takeback;

        public int Moretime;

        public int ClockTenths;

        public bool ClockBar;

        public bool ClockSound;

        public bool Premove;

        public int Animation;

        public bool Captured;

        public bool Follow;

        public bool Highlight;

        public bool Destination;

        public int Coords;

        public int Replay;

        public int Challenge;

        public int Message;

        public int SubmitMove;

        public int ConfirmResign;

        public int InsightShare;

        public int KeyboardMove;

        public int Zen;

        public int Ratings;

        public int MoveEvent;

        public int RookCastle;
    }
}
