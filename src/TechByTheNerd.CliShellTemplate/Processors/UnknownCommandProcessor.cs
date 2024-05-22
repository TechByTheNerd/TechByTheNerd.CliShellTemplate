namespace TechByTheNerd.CliShellTemplate.Processors
{
    public class UnknownCommandProcessor : ProcessorBase
    {
        public UnknownCommandProcessor(IApplicationState applicationState)
            : base(applicationState, new List<RunnableCommandHelpText>
            {
                new RunnableCommandHelpText { Keywords = null, Description = "Unknown command." }
            })
        {
        }
        public override double CheckCommand(string commandText)
        {
            return 0.1;
        }

        public override string GetHelpDetails(string commandText)
        {
            return $"No help available for this unknown command \"{commandText}\".";
        }

        public override string GetHelpSummary()
        {
            return null;
        }

        public override Task ProcessAsync(string commandText)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Unknown command: {commandText}");
            });
        }
    }
}