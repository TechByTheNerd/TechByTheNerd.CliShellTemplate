
namespace TechByTheNerd.CliShellTemplate.Processors
{
    public class ExitProcessor : ProcessorBase
    {
        public ExitProcessor(IApplicationState applicationState)
            : base(applicationState, new List<RunnableCommandHelpText>
            {
                new RunnableCommandHelpText { Keywords = new List<string> { "exit", "quit", "x", "q" }, Description = "Exits the application." }
            })
        {
        }

        public override string GetHelpDetails(string commandText)
        {
            return @"Help on Exiting:
----------------
To exit this program, type 'exit', 'quit', 'x', or 'q'. You can also use Ctrl+C 
and there is tab completion for these commands. For example, type 'ex' and press 
tab to auto-complete to 'exit'.";
        }

        public override Task ProcessAsync(string commandText)
        {
            _applicationState.RequestStop();
            return Task.CompletedTask;
        }
    }

}