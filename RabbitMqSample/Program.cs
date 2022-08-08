// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text;


ConnectionFactory factory = new ConnectionFactory();
factory.HostName = "localhost";

using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    channel.QueueDeclare("ikincikuyruk2",true,false,true);
    byte[] byteMessage = Encoding.UTF8.GetBytes("Bu bir RabbitMQ kuyruğunun ikinci mesajıdır!");
    channel.BasicPublish(exchange: "", routingKey: "ikincikuyruk2", body: byteMessage);
}
