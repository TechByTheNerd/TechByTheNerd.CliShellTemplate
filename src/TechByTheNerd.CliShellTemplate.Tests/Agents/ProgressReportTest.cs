using TechByTheNerd.CliShellTemplate.Agents;
using Xunit;

namespace TechByTheNerd.CliShellTemplate.Tests.Agents
{
    public class ProgressReportTests
    {
        [Fact]
        public void IsComplete_DefaultValue_ShouldBeFalse()
        {
            // Arrange
            var progressReport = new ProgressReport();

            // Act

            // Assert
            Assert.False(progressReport.IsComplete);
        }

        [Fact]
        public void StatusText_DefaultValue_ShouldBeProcessing()
        {
            // Arrange
            var progressReport = new ProgressReport();

            // Act

            // Assert
            Assert.Equal("Processing...", progressReport.StatusText);
        }

        [Fact]
        public void StatusDateTime_DefaultValue_ShouldBeDefaultDateTime()
        {
            // Arrange
            var progressReport = new ProgressReport();

            // Act

            // Assert
            Assert.Equal(default(DateTime), progressReport.StatusDateTime);
        }

        [Fact]
        public void PercentComplete_DefaultValue_ShouldBeZero()
        {
            // Arrange
            var progressReport = new ProgressReport();

            // Act

            // Assert
            Assert.Equal(0, progressReport.PercentComplete);
        }
    }
}