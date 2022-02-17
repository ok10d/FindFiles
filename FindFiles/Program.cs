using FindFiles;
using CommandLine;
using System.Diagnostics;

Parser.Default.ParseArguments<Options>(args)
   .WithParsed(Run);

static void Run(Options opts)
{
    if (opts.SearchForList is not null)
    {
        foreach (var searchFor in opts.SearchForList)
        {
            Console.WriteLine($"Searching For: {searchFor}");
            var files = FileHelper.GetFiles(opts.SearchDirectory, "*.*");

            List<FileInfo> found = new();

            foreach (var filename in files)
            {
                try
                {
                    FileInfo file = new(filename);
                    if (file.Name.Contains(searchFor, StringComparison.InvariantCultureIgnoreCase))
                        found.Add(file);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            foreach (var file in found.OrderByDescending(x => x.Length))
            {
                string? version = FileVersionInfo.GetVersionInfo(Path.Combine(Environment.SystemDirectory, file.FullName)).FileVersion;
                if (version is null)
                    version = "";
                Console.WriteLine($"{file.GetHumanReadableFileSize(),-10} Version:{version,-10} {file.FullName} ");
            }
            Console.WriteLine($"Total: {found.Count} files. {Environment.NewLine}");
        }
    }
}


