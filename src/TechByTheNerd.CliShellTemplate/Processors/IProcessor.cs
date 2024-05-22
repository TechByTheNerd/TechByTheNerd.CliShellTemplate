namespace TechByTheNerd.CliShellTemplate.Processors
{
    /// <summary>
    /// Interface for a processor that can process commands.
    /// </summary>
    public interface IProcessor
    {
        /// <summary>
        /// Checks the command text to see if it is a command that this 
        /// processor can handle.
        /// </summary>
        /// <param name="commandText">The command text that the user typed.</param>
        /// <returns>A confidence level from 0.0 to 1.0 for how confident this 
        /// processor
        /// is that it can handle that <paramref name="commandText"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if the 
        /// <paramref name="commandText"/> 
        /// is null or empty.</exception>
        double CheckCommand(string commandText);

        /// <summary>
        /// Processes the command text.
        /// </summary>
        /// <param name="commandText">Process the command that the user 
        /// typed.</param>
        /// <returns>Returns an awaitable <see cref="Task"/> for the code that 
        /// is being executed.</returns>
        /// <exception cref="ArgumentException">Thrown if the 
        /// <paramref name="commandText"/>.</exception>
        Task ProcessAsync(string commandText);

        /// <summary>
        /// Gets a summary of the help text for this processor.
        /// </summary>
        /// <returns>A single line that has a column for potential keywords to use,
        /// and a second column with the description.</returns>
        string GetHelpSummary();

        /// <summary>
        /// Gets the detailed help text for a specific command.
        /// </summary>
        /// <param name="commandText">The command that the user typed.</param>
        /// <returns>A detailed description of how this process works with the 
        /// specified <paramref name="commandText"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if the 
        /// <paramref name="commandText"/>.</exception>
        string GetHelpDetails(string commandText);

        /// <summary>
        /// Gets a list of possible tab-completions for the input, based on the 
        /// <paramref name="input"/>.
        /// </summary>
        /// <returns>A list of possible completions for the input, based on the 
        /// <paramref name="input"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if the 
        /// <paramref name="input"/>.</exception>
        IEnumerable<string> GetCompletions(string input);
    }
}