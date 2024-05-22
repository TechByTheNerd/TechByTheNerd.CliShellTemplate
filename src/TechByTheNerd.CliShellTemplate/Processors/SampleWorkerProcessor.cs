using Spectre.Console;

namespace TechByTheNerd.CliShellTemplate.Processors
{
    public class SampleWorkerProcessor : ProcessorBase
    {
        public SampleWorkerProcessor(IApplicationState applicationState)
            : base(applicationState, new List<RunnableCommandHelpText>
            {
                new RunnableCommandHelpText { Keywords = new List<string> { "w", "work" }, Description = "Starts doing work." }
            })
        {
        }

        public override string GetHelpDetails(string commandText)
        {
            return @"Help on Sample Worker Information:
---------------------------
This 'w' or 'work' command will have this processor start doing work.";
        }

        public override Task ProcessAsync(string commandText)
        {
            return Task.Run(() =>
            {
                AnsiConsole.Progress()
            .Columns(new ProgressColumn[]
            {
                new SpinnerColumn(),           // Spinner
                new TaskDescriptionColumn(),    // Task description
                new ProgressBarColumn(),       // Progress bar
                new RemainingTimeColumn(),     // Remaining time
                new ElapsedTimeColumn(),       // Elapsed time
                new PercentageColumn()         // Percentage
            })
            .Start(ctx =>
            {
                // Define a new progress task with a total of 10 units
                var task = ctx.AddTask("[green]Working[/]...", new ProgressTaskSettings
                {
                    MaxValue = 10,
                    AutoStart = true
                });

                // Update the progress
                for (var i = 0; i <= 10; i++)
                {
                    task.Description = $"[green]Working on {i}/10[/]";
                    task.Increment(1);
                    Thread.Sleep(1000);
                }
            });
            });
        }
    }
}