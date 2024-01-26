using Peter.DataParser.GameDataParser;
using Peter.DataParser.Utils;

ConsoleUserInteractor userInteractor = new();
GameDataParser app =
    new(
        userInteractor,
        new LocalFileReader(),
        new GameDataDeserializer(userInteractor),
        new GameDataPrinter(userInteractor)
    );

Logger logger = new("log.txt");
try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Unexpected error :c");
    Console.WriteLine("Data parser will now shut down gracefully.");
    logger.Log(ex);
}

Console.WriteLine("Press any key to close.");
Console.ReadKey();
