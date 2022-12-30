using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace BinaryPatcher;

public class Targets
{
    private class PatchFile
    {
        public string Name { get; init; } = null!;
        public string Path { get; init; } = null!;
        public Dictionary<long, string> Payload { get; init; } = null!;
    }
    
    public static async Task Run()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(PascalCaseNamingConvention.Instance)
            .Build();

        var yamlFiles = Directory.GetFiles(currentDirectory, "*.yml", SearchOption.TopDirectoryOnly)
            .Select(Path.GetFileNameWithoutExtension)
            .Cast<string>()
            .ToList();

        string file;
        
        if (!yamlFiles.Any())
        {
            Interface.Write(" | x | No patch files found");
            return;
        }

        if (yamlFiles.Count is 1)
            file = yamlFiles.First();
        else
        {
            var selections = new SelectionPrompt<string>()
                .Title("Select a [green]patch file[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more files)[/]");
            selections.AddChoices(yamlFiles);
        
            file = AnsiConsole.Prompt(selections);
        }

        var fileFull = $"{file}.yml";
        var filePath = Path.Combine(currentDirectory, fileFull);
        var fileContent = await File.ReadAllTextAsync(filePath);
        var patches = deserializer.Deserialize<List<PatchFile>>(fileContent);

        const string @default = "Fill me in";
        bool fail = false;
        if (patches.Any(x => x.Name == @default))
        {
            Interface.Write($" | x | Please edit the 'Name' field in the '{fileFull}' file");
            fail = true;
        }
        if (patches.Any(x => x.Path == @default))
        {
            Interface.Write($" | x | Please edit the 'Path' field in the '{fileFull}' file");
            fail = true;
        }
        
        if (fail)
            return;

        Patch(patches);
    }

    private static void Patch(List<PatchFile> patchFile)
    {
        foreach (var patch in patchFile)
        {
            if (!File.Exists(patch.Path))
            {
                Interface.Write($" | x | {patch.Name} not found.", ConsoleColor.Gray);
                continue;
            }
            var backup = $"{patch.Path}.bak";
            if (File.Exists(backup))
            {
                Interface.Write($" | > | {patch.Name} has already been patched.", ConsoleColor.Blue);
                continue;
            }
            TaskKill.Run(Path.GetFileNameWithoutExtension(patch.Path));
            File.Copy(patch.Path, backup);
            using (var fileStream = new FileStream(patch.Path, FileMode.Open, FileAccess.Write, FileShare.Write))
            {
                foreach (var entry in patch.Payload)
                {
                    var bytes = Converters.HexToBytes(entry.Value);
                    fileStream.Seek(entry.Key, SeekOrigin.Begin);
                    fileStream.Write(bytes, 0, bytes.Length);
                }
            }
            Interface.Write($" | ✓ | Successfully patched {patch.Name}.", ConsoleColor.Green);
        }
    }
}