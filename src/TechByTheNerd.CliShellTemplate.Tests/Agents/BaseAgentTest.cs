using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using TechByTheNerd.CliShellTemplate.Agents;
using Xunit;

namespace TechByTheNerd.CliShellTemplate.Tests.Agents
{
    public class BaseAgentTests
    {
        [Fact]
        public async Task RunAsync_ShouldReportProgress()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<BaseAgent>>();
            var progressMock = new Mock<IProgress<ProgressReport>>();

            var agent = new MockAgent(loggerMock.Object);

            progressMock.Setup(p => p.Report(It.IsAny<ProgressReport>()));

            // Act
            await agent.RunAsync(progressMock.Object);

            // Assert
            progressMock.Verify(p => p.Report(It.IsAny<ProgressReport>()), Times.AtLeastOnce);
        }
    }
}