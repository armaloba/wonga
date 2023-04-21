
namespace Wonga.Tests
{
    public class ProducerTests
    {
        [Fact]
        public void ProduceMessage_ShouldThrowArgumentNullException_WhenMessageIsNull()
        {
            // Arrange
            string message = null!;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => Producer.Message.ProduceMessage(message));
        }

        [Fact]
        public void ProduceMessage_ShouldThrowArgumentNullException_WhenMessageIsEmpty()
        {
            // Arrange
            var message = string.Empty;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => Producer.Message.ProduceMessage(message));
        }

        [Fact]
        public void ProduceMessage_ShouldReturnSameMessage_WhenMessageIsValid()
        {
            // Arrange
            string message = "I am a test message";

            // Act
            var result = Producer.Message.ProduceMessage(message);

            // Assert
            Assert.Equal(message, result);
        }

        [Fact]
        public void GetRabbitMQChannel_ShouldReturnChannel_WhenValidUriIsPassed()
        {
            // Arrange
            string validUri = "amqp://guest:guest@localhost:5672";

            // Act
            var channel = Producer.Message.GetRabbitMQChannel(validUri);

            // Assert
            Assert.NotNull(channel);
        }

        [Fact]
        public void GetRabbitMQChannel_ShouldThrowBrokerUnreachableException_WhenInvalidUriIsPassed()
        {
            // Arrange
            var invalidUri = "amqp://guest:guest@localhost:2468";

            // Act and Assert
            Assert.Throws<RabbitMQ.Client.Exceptions.BrokerUnreachableException>(() =>
            {
                Producer.Message.GetRabbitMQChannel(invalidUri);
            });
        }
    }
}

