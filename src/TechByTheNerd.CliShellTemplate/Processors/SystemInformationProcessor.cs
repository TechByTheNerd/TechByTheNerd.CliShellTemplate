
namespace TechByTheNerd.CliShellTemplate.Processors
{
    public class SystemInformationProcessor : ProcessorBase
    {
        public SystemInformationProcessor(IApplicationState applicationState)
            : base(applicationState, new List<RunnableCommandHelpText>
            {
                new RunnableCommandHelpText { Keywords = new List<string> { "sys", "info" }, Description = "Shows system information." }
            })
        {
        }

        public override string GetHelpDetails(string commandText)
        {
            return @"Help on System Information:
---------------------------
This 'sys' or 'info' command shows system information.";
        }

        public override Task ProcessAsync(string commandText)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("");
                Console.WriteLine("System Information:");
                Console.WriteLine($"OS..................: {Environment.OSVersion}");
                Console.WriteLine($"Processor Count.....: {Environment.ProcessorCount}");
                Console.WriteLine($"64-bit OS...........: {Environment.Is64BitOperatingSystem}");
                Console.WriteLine($"64-bit Process......: {Environment.Is64BitProcess}");
                Console.WriteLine($"Machine Name........: {Environment.MachineName}");
                Console.WriteLine($"User Name...........: {Environment.UserName}");
                Console.WriteLine($"User Domain Name....: {Environment.UserDomainName}");
                Console.WriteLine($"Current Directory...: {Environment.CurrentDirectory}");
                Console.WriteLine($"System Directory....: {Environment.SystemDirectory}");
                Console.WriteLine($"CLR Version.........: {Environment.Version}");
                Console.WriteLine($"Working Set.........: {Environment.WorkingSet}");
                Console.WriteLine($"System Page Size....: {Environment.SystemPageSize}");
                Console.WriteLine($"User Interactive....: {Environment.UserInteractive}");
                Console.WriteLine($"New Line............: {Environment.NewLine}");

                   
            });
        }
    }
}