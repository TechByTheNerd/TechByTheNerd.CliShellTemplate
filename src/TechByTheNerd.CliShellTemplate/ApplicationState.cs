using TechByTheNerd.CliShellTemplate.Processors;

namespace TechByTheNerd.CliShellTemplate
{
    public class ApplicationState : IApplicationState
    {
        public bool IsRunning { get; private set; } = true;
        private List<IProcessor> _processors = new List<IProcessor>();
        public IEnumerable<IProcessor> Processors => _processors.AsReadOnly();

        public void RequestStop()
        {
            IsRunning = false;
        }

        public void RegisterProcessors(params IProcessor[] processors)
        {
            if (processors is null)
                throw new ArgumentNullException(nameof(processors));

            _processors.AddRange(processors);
        }

        public void DeregisterProcessors(params IProcessor[] processors)
        {
            if (processors is null)
                throw new ArgumentNullException(nameof(processors));

            foreach (var item in processors)
                _processors.Remove(item);
        }
    }
}