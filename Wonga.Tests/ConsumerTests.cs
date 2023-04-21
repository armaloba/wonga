using System.Text;
namespace Wonga.Tests
{
    public class ConsumerTests
    {
        [Fact]
        public void ProcessReceivedMessage_WithValidMessageFormat_ShouldWriteExpectedOutputToConsole()
        {
            // Arrange
            var name = "Armand Maloba";
            var message = $"Hello my name is, {name}";
            byte[] body = Encoding.UTF8.GetBytes(message);

            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            Consumer.Message.ProcessReceivedMessage(body);

            // Assert
            var expectedResult = $"Hello {name}, I am your father!";
            var result = writer.ToString().TrimEnd();
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ProcessReceivedMessage_WithInvalidMessageFormat_ShouldWriteErrorMessageToConsole()
        {
            // Arrange
            var invalidMessageFormat = "Hello my names is,";
            byte[] body = Encoding.UTF8.GetBytes(invalidMessageFormat);

            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            Consumer.Message.ProcessReceivedMessage(body);

            // Assert
            var expectedResult = $"Received invalid message format: {invalidMessageFormat}";
            var result = writer.ToString().TrimEnd();
            Assert.NotEqual(expectedResult, result);
        }

        [Fact]
        public void ValidateReceivedMessage_WithValidMessageFormat_ShouldReturnName()
        {
            // Arrange
            var name = "Armand Maloba";
            var format = "Hello my name is,";
            var message = $"{format} {name}";

            // Act
            var result = Consumer.Message.ValidateReceivedMessage(format, message);

            // Assert
            Assert.Equal(name, result);
        }

        [Fact]
        public void ValidateReceivedMessage_WithInvalidMessageFormat_ShouldThrowArgumentException()
        {
            // Arrange
            var format = "Hello my name is,";
            var invalidMessageForm = "Hello my names is, Armand Maloba";

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Consumer.Message.ValidateReceivedMessage(format, invalidMessageForm));
        }
    }
}


