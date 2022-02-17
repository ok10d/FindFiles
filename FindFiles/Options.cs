using CommandLine;

namespace FindFiles
{
    internal class Options
    {
        [Option('f', "searchfor", Required = true, HelpText = "Files to search for.")]
        public IEnumerable<string>? SearchForList { get; set; }

        [Option('s', "searchdirectory", Required = true, HelpText = "Search directory.")]
        public string? SearchDirectory { get; set; }
    }
}
