using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Wonga.Consumer;

const string QUEUE_NAME = "message-communication-queue";

var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672")
};

using var connnection = factory.CreateConnection();
using var channel = connnection.CreateModel();

channel.QueueDeclare(
    queue: QUEUE_NAME,
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, e) =>
{
    var receivedMessage = e.Body.ToArray();
    Message.ProcessReceivedMessage(receivedMessage);
};

channel.BasicConsume(queue: QUEUE_NAME, autoAck: true, consumer: consumer);
Console.ReadLine();


