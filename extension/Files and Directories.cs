namespace Extensions
{
    public static class FileEx
    {
        public static bool NotExists(string path)
        {
            return !System.IO.File.Exists(path);
        }
    }
    public static class DirectoryEx
    {
        public static bool NotExists(string path)
        {
            return !System.IO.Directory.Exists(path);
        }
    }
}
