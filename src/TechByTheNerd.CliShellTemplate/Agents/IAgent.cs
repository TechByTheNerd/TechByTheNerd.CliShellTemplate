using System;
using System.Threading.Tasks;

namespace TechByTheNerd.CliShellTemplate.Agents
{
    /// <summary>
    /// Represents an agent that can run asynchronously and report progress.
    /// </summary>
    public interface IAgent
    {
        /// <summary>
        /// Runs the agent asynchronously and reports progress.
        /// </summary>
        /// <param name="progress">An object that receives progress updates.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task RunAsync(IProgress<ProgressReport> progress);
    }
}