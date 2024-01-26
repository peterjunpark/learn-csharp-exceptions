namespace Peter.DataParser.GameDataParser
{
    public class Game
    {
        public required string Title { get; init; }
        public int ReleaseYear { get; init; }
        public decimal Rating { get; init; }

        public override string ToString()
        {
            return $"{Title} ({ReleaseYear}) | {Rating}";
        }
    }
}
