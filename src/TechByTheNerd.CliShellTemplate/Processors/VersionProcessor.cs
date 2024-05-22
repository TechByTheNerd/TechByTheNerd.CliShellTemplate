namespace TechByTheNerd.CliShellTemplate.Processors
{
    public class VersionProcessor : ProcessorBase
    {
        public VersionProcessor(IApplicationState applicationState)
            : base(applicationState, new List<RunnableCommandHelpText>
            {
                new RunnableCommandHelpText { Keywords = new List<string> { "ver", "version" }, Description = "Shows version information." }
            })
        {
        }

        public override string GetHelpDetails(string commandText)
        {
            return @"Help on Version Information:
---------------------------
This 'ver' or 'version' command shows version information.";
        }

        public override Task ProcessAsync(string commandText)
        {
            return Task.Run(() =>
            {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                var assemblyLocation = assembly.Location;

                var fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assemblyLocation);
                var fileInfo = new System.IO.FileInfo(assemblyLocation);

                Console.WriteLine("");
                Console.WriteLine("Version Information:");
                Console.WriteLine("--------------------");
                Console.WriteLine($"Assembly Version....: {assembly.GetName().Version}");
                Console.WriteLine($"File Version........: {fileVersionInfo.FileVersion}");
                Console.WriteLine($"CLR Version.........: {Environment.Version}");
                Console.WriteLine($"OS Version..........: {Environment.OSVersion}");
                Console.WriteLine($"OS Platform.........: {Environment.OSVersion.Platform}");
                Console.WriteLine($"OS Service Pack.....: {Environment.OSVersion.ServicePack}");
                Console.WriteLine($"OS Version String...: {Environment.OSVersion.VersionString}");
                Console.WriteLine($"OS 64-bit...........: {Environment.Is64BitOperatingSystem}");
                Console.WriteLine($"Process 64-bit......: {Environment.Is64BitProcess}");
                Console.WriteLine("");
                Console.WriteLine("File Information:");
                Console.WriteLine("----------------");
                Console.WriteLine($"File Size...........: {fileInfo.Length} bytes");
                Console.WriteLine($"File Creation Date..: {fileInfo.CreationTime}");
                Console.WriteLine("");
            });
        }
    }
}