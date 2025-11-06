namespace PlainFile.Core
{
    public class SimpleTextFile
    {
        private readonly string _path;

        public SimpleTextFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Path cannot be null or empty.", nameof(path));
            }

            _path = path;

            var directory = Path.GetDirectoryName(_path);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_path))
            {
                using (File.Create(_path))
                {
                    // Create the file if it does not exist
                }
            }
        }
        public void WriteAllLines(string[] lines)
        {
            File.WriteAllLines(_path, lines);
        }

        public string[] ReadAllLines()
        {
            return File.ReadAllLines(_path);
        }
    }
}
