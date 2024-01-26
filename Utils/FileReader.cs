namespace Peter.DataParser.Utils
{
    public interface IFileReader
    {
        string Read(string fileName);
    }

    public class LocalFileReader : IFileReader
    {
        public string Read(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
