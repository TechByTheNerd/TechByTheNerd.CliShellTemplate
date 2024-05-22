
namespace TechByTheNerd.CliShellTemplate.Processors
{
    /// <summary>
    /// Abstract base class for an <see cref="IProcessor"/> that can process commands.
    /// </summary>
    public abstract class ProcessorBase : IProcessor
    {
        protected readonly IApplicationState _applicationState;
        protected readonly List<RunnableCommandHelpText> _commands;

        /// <summary>
        /// Creates a new instance of this object.
        /// </summary>
        /// <param name="applicationState">Establishes an application state that 
        /// can be shared among components of this application.</param>
        /// <param name="commands">A list of possible ways to invole this 
        /// processor.</param>
        /// <exception cref="ArgumentNullException">Thrown if the 
        /// <paramref name="applicationState"/> or <paramref name="commands"/> 
        /// is null.</exception>
        protected ProcessorBase(IApplicationState applicationState, List<RunnableCommandHelpText> commands)
        {
            _applicationState = applicationState ?? throw new ArgumentNullException(nameof(applicationState));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        /// <inheritdoc/>
        public virtual double CheckCommand(string commandText)
        {
            return _commands?.Any(command =>
                command.Keywords?.Any(keyword => keyword != null
                    && commandText.StartsWith(keyword)) == true) == true ? 1.0 : 0.0;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<string> GetCompletions(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Enumerable.Empty<string>();

            return _commands?.SelectMany(command =>
                command.Keywords?.Where(keyword => keyword?.StartsWith(input) ?? false) ?? Enumerable.Empty<string>()) 
                ?? Enumerable.Empty<string>();
        }

        /// <inheritdoc/>
        public virtual string GetHelpSummary()
        {
            string keywords = string.Join(", ", _commands?.FirstOrDefault()?.Keywords ?? Enumerable.Empty<string>());
            string description = _commands?.FirstOrDefault()?.Description ?? "";

            return $"{keywords.PadRight(20)}{description}";
        }

        /// <inheritdoc/>
        public abstract string GetHelpDetails(string commandText);

        /// <inheritdoc/>
        public abstract Task ProcessAsync(string commandText);
    }

}