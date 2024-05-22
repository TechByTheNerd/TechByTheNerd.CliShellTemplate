using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace TechByTheNerd.CliShellTemplate.Agents
{
    public class MockAgent : BaseAgent
    {
        public MockAgent(ILogger<BaseAgent> logger) : base(logger)
        {
        }

        public override async Task RunAsync(IProgress<ProgressReport> progress)
        {
            // Assign the progress object to the protected Progress property
            Progress = progress;

            // Simulate some work that reports progress
            for (int i = 0; i <= 100; i += 10)
            {
                // Create a new ProgressReport object
                var report = new ProgressReport
                {
                    PercentComplete = i,
                    StatusText = $"Processing... {i}% complete",
                    StatusDateTime = DateTime.Now
                };

                // Report progress
                Progress.Report(report);

                // Wait a bit before the next iteration
                await Task.Delay(100);
            }
        }
    }
}