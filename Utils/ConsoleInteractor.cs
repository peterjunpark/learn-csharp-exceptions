namespace Peter.DataParser.Utils
{
    public interface IUserInteractor
    {
        string GetValidFilePath();
        void PrintMessage(string message);
        void PrintError(string message);
    }

    public class ConsoleUserInteractor : IUserInteractor
    {
        private readonly ConsoleColor _originalConsoleColor = Console.ForegroundColor;

        public string GetValidFilePath()
        {
            while (true)
            {
                PrintMessage("Write the name of the file to read:");

                string fileName = Console.ReadLine() ?? "";

                if (fileName is null)
                {
                    PrintMessage("The file name cannot be null.");
                    continue;
                }

                if (fileName == string.Empty)
                {
                    PrintMessage("The file name cannot be empty.");
                    continue;
                }

                if (!File.Exists(fileName))
                {
                    PrintMessage("File does not exist.");
                    continue;
                }

                return fileName;
            }
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = _originalConsoleColor;
        }
    }
}
