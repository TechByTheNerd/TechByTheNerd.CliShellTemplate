using Microsoft.Extensions.Logging;

namespace TechByTheNerd.CliShellTemplate.Agents
{
    /// <summary>
    /// Represents a base implementation of the <see cref="IAgent"/> interface.
    /// </summary>
    public abstract class BaseAgent : IAgent
    {
        protected readonly ILogger<BaseAgent> Logger;
        protected IProgress<ProgressReport> Progress;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAgent"/> class.
        /// </summary>
        /// <param name="logger">The logger to use for logging.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="logger"/> is <c>null</c>.</exception>
        protected BaseAgent(ILogger<BaseAgent> logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Runs the agent asynchronously and reports progress.
        /// </summary>
        /// <param name="progress">An object that receives progress updates.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public abstract Task RunAsync(IProgress<ProgressReport> progress);

        /// <summary>
        /// Reports progress.
        /// </summary>
        /// <param name="isComplete">A value indicating whether the operation is complete.</param>
        /// <param name="statusText">A text describing the current status.</param>
        /// <param name="percentComplete">The percentage of the operation that is complete.</param>
        protected void ReportProgress(bool isComplete, string statusText, int percentComplete)
        {
            Progress?.Report(new ProgressReport
            {
                IsComplete = isComplete,
                StatusText = statusText,
                PercentComplete = percentComplete
            });
        }
    }
}