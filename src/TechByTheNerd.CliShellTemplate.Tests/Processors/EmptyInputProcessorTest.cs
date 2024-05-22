using Moq;
using TechByTheNerd.CliShellTemplate;
using TechByTheNerd.CliShellTemplate.Processors;

namespace TechByTheNerd.CliShellTemplate.Tests.Processors
{
    public class EmptyInputProcessorTests
    {
        [Fact]
        public void CheckCommand_ShouldReturnOne_ForNullCommandText()
        {
            // Arrange
            var applicationStateMock = new Mock<IApplicationState>();
            var processor = new EmptyInputProcessor(applicationStateMock.Object);

            // Act
            var result = processor.CheckCommand(null);

            // Assert
            Assert.Equal(1.0, result);
        }

        [Fact]
        public void CheckCommand_ShouldReturnOne_ForEmptyCommandText()
        {
            // Arrange
            var applicationStateMock = new Mock<IApplicationState>();
            var processor = new EmptyInputProcessor(applicationStateMock.Object);

            // Act
            var result = processor.CheckCommand("");

            // Assert
            Assert.Equal(1.0, result);
        }

        [Fact]
        public void CheckCommand_ShouldReturnZero_ForNonEmptyCommandText()
        {
            // Arrange
            var applicationStateMock = new Mock<IApplicationState>();
            var processor = new EmptyInputProcessor(applicationStateMock.Object);

            // Act
            var result = processor.CheckCommand("some command");

            // Assert
            Assert.Equal(0.0, result);
        }

        [Fact]
        public void GetHelpSummary_ShouldReturnNull()
        {
            // Arrange
            var applicationStateMock = new Mock<IApplicationState>();
            var processor = new EmptyInputProcessor(applicationStateMock.Object);

            // Act
            var result = processor.GetHelpSummary();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetHelpDetails_ShouldReturnNoHelpAvailable_ForAnyCommandText()
        {
            // Arrange
            var applicationStateMock = new Mock<IApplicationState>();
            var processor = new EmptyInputProcessor(applicationStateMock.Object);

            // Act
            var result = processor.GetHelpDetails("some command");

            // Assert
            Assert.Equal("No help available for empty command.", result);
        }

        [Fact]
        public async Task ProcessAsync_ShouldDoNothing_ForAnyCommandText()
        {
            // Arrange
            var applicationStateMock = new Mock<IApplicationState>();
            var processor = new EmptyInputProcessor(applicationStateMock.Object);

            // Act
            await processor.ProcessAsync("some command");

            // Assert
            // No assertions needed as the method should do nothing.
        }
    }
}