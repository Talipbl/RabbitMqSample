using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new ConnectionFactory();
factory.HostName = "localhost";

using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    channel.QueueDeclare("ikincikuyruk", true, false, true);
    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
    channel.BasicConsume("ikincikuyruk", false, consumer);
    consumer.Received += (sender, args) =>
    {
        var body = args.Body.Span;
        Console.WriteLine(Encoding.UTF8.GetString(body));
    };
    Console.ReadLine();
}