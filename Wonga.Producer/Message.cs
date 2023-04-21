using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System.Text;

namespace Wonga.Producer
{
    public class Message
    {
        public const string QUEUE_NAME = "message-communication-queue";
        public static string ProduceMessage(string message)
        {
            if(string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            using var channel = GetRabbitMQChannel("amqp://guest:guest@localhost:5672");

            channel.QueueDeclare(
                queue: QUEUE_NAME,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );

            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("", QUEUE_NAME, null, body);

            return message;
        }

        public static IModel GetRabbitMQChannel(string uri)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(uri)
            };

            try
            {
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();
                return channel;
            }
            catch (BrokerUnreachableException ex)
            {
                throw ex;
            }           
        }
    }
}

