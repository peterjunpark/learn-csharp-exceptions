using System.Text.Json;
using Peter.DataParser.Utils;

namespace Peter.DataParser.GameDataParser
{
    public class GameDataParser(
        IUserInteractor userInteractor,
        IFileReader fileReader,
        IGameDataDeserializer gamesDeserializer,
        IGameDataPrinter gamesPrinter
    )
    {
        private readonly IUserInteractor _userInteractor = userInteractor;
        private readonly IFileReader _fileReader = fileReader;
        private readonly IGameDataDeserializer _gamesDeserializer = gamesDeserializer;
        private readonly IGameDataPrinter _gamesPrinter = gamesPrinter;

        public void Run()
        {
            string fileName = _userInteractor.GetValidFilePath();
            string fileContents = File.ReadAllText(fileName);
            List<Game> games = _gamesDeserializer.DeserializeFrom(fileContents, fileName);
            _gamesPrinter.Print(games);
        }
    }

    public interface IGameDataDeserializer
    {
        List<Game> DeserializeFrom(string fileContents, string fileName);
    }

    public class GameDataDeserializer(IUserInteractor userInteractor) : IGameDataDeserializer
    {
        private readonly IUserInteractor _userInteractor = userInteractor;

        public List<Game> DeserializeFrom(string fileContents, string fileName)
        {
            try
            {
                return JsonSerializer.Deserialize<List<Game>>(fileContents);
            }
            catch (JsonException ex)
            {
                _userInteractor.PrintError(
                    $"JSON in {fileName} was not in a valid format. JSON body:"
                );
                _userInteractor.PrintError(fileContents);
                throw new JsonException($"{ex.Message} The file is {fileName}", ex);
            }
        }
    }

    public interface IGameDataPrinter
    {
        void Print(List<Game> games);
    }

    public class GameDataPrinter(IUserInteractor userInteractor) : IGameDataPrinter
    {
        private readonly IUserInteractor _userInteractor = userInteractor;

        public void Print(List<Game> games)
        {
            if (games.Count < 1)
            {
                _userInteractor.PrintMessage("No games in the file.");
                return;
            }

            _userInteractor.PrintMessage(Environment.NewLine + "Loaded games:");
            foreach (Game game in games)
            {
                _userInteractor.PrintMessage(game.ToString());
            }
        }
    }
}
