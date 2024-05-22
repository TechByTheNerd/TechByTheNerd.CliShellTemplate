namespace TechByTheNerd.CliShellTemplate.Agents
{
    /// <summary>
    /// Represents a progress report.
    /// </summary>
    public class ProgressReport
    {
        /// <summary>
        /// Gets or sets a value indicating whether the progress is complete.
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Gets or sets the status text.
        /// </summary>
        public string StatusText { get; set; } = "Processing...";

        /// <summary>
        /// Gets or sets the status date and time.
        /// </summary>
        public DateTime StatusDateTime { get; set; }

        /// <summary>
        /// Gets or sets the percentage of completion.
        /// </summary>
        public int PercentComplete { get; set; }
    }
}