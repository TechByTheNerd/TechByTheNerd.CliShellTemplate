namespace TechByTheNerd.CliShellTemplate.Processors
{
    public class HelpProcessor  : ProcessorBase
    {
        public HelpProcessor(IApplicationState applicationState)
            : base(applicationState, new List<RunnableCommandHelpText>
            {
                new RunnableCommandHelpText { Keywords = new List<string> { "h", "help", "?" }, Description = "Shows this help screen." }
            })
        {
        }

        public override IEnumerable<string> GetCompletions(string input)
        {
            var helpKeywords = _commands.SelectMany(command => command.Keywords).ToList();

            // If the input is a prefix of one of the help keywords, return the help keywords as completions.
            if (helpKeywords.Any(keyword => keyword.StartsWith(input)))
            {
                return helpKeywords;
            }

            // If the input is one of the help keywords followed by a space, return the completions from the other processors.
            if (helpKeywords.Any(keyword => input.StartsWith(keyword + " ")))
            {
                var otherCompletions = _applicationState.Processors
                    .Where(processor => !(processor is HelpProcessor))
                    .SelectMany(processor => processor.GetCompletions(input.Substring(input.IndexOf(' ') + 1)));

                return otherCompletions;
            }

            return Enumerable.Empty<string>();
        }

        public override string GetHelpDetails(string commandText)
        {
            string output = @"Help on Help:
----------------
Using 'help' shows available commands you can run or show help for a specific command. 
To use help like that, type 'help' or '?' followed by the command you want help with. 
For example: 'help exit'.

Command Recall:
You can use your up and down arrow keys to recall previous commands you have run.

Tab Completion:
You can use the tab key to auto-complete commands. If there are multiple options, you can press tab again to cycle through them.";

            return output;
        }

        public override Task ProcessAsync(string commandText)
        {
            return Task.Run(() =>
            {
                string command = commandText.TrimStart('h', 'e', 'l', 'p', '?').TrimStart();

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine("Available commands:");

                    Console.WriteLine("");
                    foreach (var processor in _applicationState.Processors)
                    {
                        string summaryText = processor.GetHelpSummary();

                        if (!string.IsNullOrWhiteSpace(summaryText))
                            Console.WriteLine(summaryText);
                    }
                    Console.WriteLine("");
                }
                else
                {
                    IProcessor bestMatchProcessor = _applicationState.Processors
                        .OrderByDescending(p => p.CheckCommand(command))
                        .FirstOrDefault();

                    // No need to check if bestMatchProcessor is null because 
                    // UnknownCommandProcessor will always be returned if no 
                    // other processor can handle the command
                    Console.WriteLine(bestMatchProcessor.GetHelpDetails(command));
                }
            });
        }
    }
}