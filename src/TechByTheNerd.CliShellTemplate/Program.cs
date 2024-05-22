using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TechByTheNerd.CliShellTemplate.Processors;

namespace TechByTheNerd.CliShellTemplate
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IApplicationState applicationState = new ApplicationState();

            applicationState.RegisterProcessors(
                new HelpProcessor(applicationState),
                new ExitProcessor(applicationState),
                new UnknownCommandProcessor(applicationState),
                new EmptyInputProcessor(applicationState),
                new SystemInformationProcessor(applicationState),
                new VersionProcessor(applicationState),
                new SampleWorkerProcessor(applicationState)
            );

            ReadLine.AutoCompletionHandler = new AutoCompletionHandler(applicationState);

            while (applicationState.IsRunning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("CLI Shell> ");
                Console.ResetColor();

                string command = ReadLine.Read();
                ReadLine.AddHistory(command);

                // var processorConfidences = applicationState.Processors
                //     .Select(p => new { Processor = p, Confidence = p.CheckCommand(command) })
                //     .OrderByDescending(p => p.Confidence)
                //     .ToList();

                // foreach (var processorConfidence in processorConfidences)
                // {
                //     Console.WriteLine($"Processor: {processorConfidence.Processor.GetType().Name}, Confidence: {processorConfidence.Confidence}");
                // }

                IProcessor processor = applicationState.Processors
                    .OrderByDescending(p => p.CheckCommand(command))
                    .FirstOrDefault();

                if (processor != null)
                {
                    // Console.ForegroundColor = ConsoleColor.Cyan;
                    // Console.WriteLine($"Processor chosen: {processor.GetType().Name}");
                    // Console.ResetColor();

                    await processor.ProcessAsync(command);
                }
            }
        }
    }
}