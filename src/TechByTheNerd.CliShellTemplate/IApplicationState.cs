using TechByTheNerd.CliShellTemplate.Processors;

namespace TechByTheNerd.CliShellTemplate
{
    public interface IApplicationState
    {
        bool IsRunning { get; }
        IEnumerable<IProcessor> Processors { get; }

        void RequestStop();
        void RegisterProcessors(params IProcessor[] processors);
        void DeregisterProcessors(params IProcessor[] processors);
    }
}