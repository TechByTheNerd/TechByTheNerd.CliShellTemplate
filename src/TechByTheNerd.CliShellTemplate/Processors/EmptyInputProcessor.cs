namespace TechByTheNerd.CliShellTemplate.Processors
{
    /// <summary>
    /// A processor that handles an empty input.
    /// </summary>
    public class EmptyInputProcessor : ProcessorBase
    {
        /// <summary>
        /// Creates a new instance of this object.
        /// </summary>
        /// <param name="applicationState">Established an instance of application 
        /// state where application-wide values can be monitored.</param>
        /// <exception cref="ArgumentNullException">Thrown if the 
        /// <paramref name="applicationState"/> is null.</exception>
        public EmptyInputProcessor(IApplicationState applicationState)
            : base(applicationState, new List<RunnableCommandHelpText>
                {
                    new RunnableCommandHelpText { 
                        Keywords = new List<string> { "" }, 
                        Description = "No input provided." }
                })
        {
        }

        /// <inheritdoc/>
        public override double CheckCommand(string commandText)
        {
            if (string.IsNullOrWhiteSpace(commandText))
                return 1.0;
            else
                return 0.0;
        }

        /// <inheritdoc/>
        public override string GetHelpSummary()
        {
            return null;
        }
        
        /// <inheritdoc/>
        public override string GetHelpDetails(string commandText)
        {
            return "No help available for empty command.";
        }

        /// <inheritdoc/>
        public override Task ProcessAsync(string commandText)
        {
            return Task.Run(() =>
            {
                // Literally do nothing. They just entered an empty command.
            });
        }
    }
}