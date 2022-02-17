namespace FindFiles
{
    public static class FileExtensions
    {
        public static string GetHumanReadableFileSize(this FileInfo file)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = file.Length;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }
            return String.Format("{0:0.##}{1}", len, sizes[order]);
        }
    }
}
