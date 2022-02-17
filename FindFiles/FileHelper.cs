namespace FindFiles
{
    internal class FileHelper
    {
        public static IEnumerable<string> GetFiles(string? root, string? searchPattern)
        {
            ArgumentNullException.ThrowIfNull(root);
            ArgumentNullException.ThrowIfNull(searchPattern);

            Stack<string> pending = new();
            pending.Push(root);
            while (pending.Count != 0)
            {
                var path = pending.Pop();
                string[]? next = null;
                try
                {
                    next = Directory.GetFiles(path, searchPattern);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                if (next != null && next.Length != 0)
                    foreach (var file in next) yield return file;
                try
                {
                    next = Directory.GetDirectories(path);
                    foreach (var subdir in next) pending.Push(subdir);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
