namespace TechByTheNerd.CliShellTemplate
{
    public class AutoCompletionHandler : IAutoCompleteHandler
    {
        private IApplicationState _applicationState;

        public AutoCompletionHandler(IApplicationState applicationState)
        {
            _applicationState = applicationState;
        }

        public char[] Separators { get; set; } = new char[] { ' ', '.', '/' };

        public string[] GetSuggestions(string text, int index)
        {
            

            if (_applicationState == null)
            {
                Console.WriteLine("_applicationState is null");
                return new string[0];
            }

            if (_applicationState.Processors == null)
            {
                Console.WriteLine("_applicationState.Processors is null");
                return new string[0];
            }

            var nonNullProcessors = _applicationState.Processors.Where(p => p != null);

            if (nonNullProcessors == null)
            {
                Console.WriteLine("nonNullProcessors is null");
                return new string[0];
                
            }

            var completions = new List<string>();

            foreach (var processor in nonNullProcessors)
            {
                var processorCompletions = processor.GetCompletions(text);

                if (processorCompletions == null)
                {
                    Console.WriteLine($"processorCompletions is null for processor {processor.GetType().Name}");
                }
                else
                {
                    completions.AddRange(processorCompletions);
                }
            }

            return completions.ToArray();
        }
    }
}