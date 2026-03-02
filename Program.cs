using System.CommandLine;

namespace scl;

class Program
{
    static int Main(string[] args)
    {
        Option<FileInfo> fileOption = new("--file")
        {
            Description = "The file to read and display on the console"
        };

        RootCommand rootCommand = new("Sample app for System.CommandLine");
        rootCommand.Options.Add(fileOption);

        rootCommand.SetAction(parseResult =>
        {
            FileInfo? parsedFile = parseResult.GetValue(fileOption);
            if (parsedFile is null)
            {
                Console.Error.WriteLine("Error: --file option is required.");
                return 1;
            }
            ReadFile(parsedFile);
            return 0;
        });

        ParseResult parseResult = rootCommand.Parse(args);
        return parseResult.Invoke();
    }

    static void ReadFile(FileInfo file)
    {
        foreach (string line in File.ReadLines(file.FullName))
        {
            Console.WriteLine(line);
        }
    }
}