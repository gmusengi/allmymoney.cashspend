using Newtonsoft.Json;
using NUnit.Framework;
using RabbitMQ.Client;
using System.Text;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var connectionFactory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    string exchange = "spendexchange";
                    string routekey = "spend.cash";
                    channel.ExchangeDeclare(exchange, ExchangeType.Topic, true, false, null);
                    channel.QueueBind(channel.QueueDeclare("spend", true, false, false, null).QueueName, exchange, routekey, null);
                    byte[] body = Encoding.UTF8.GetBytes($"Cash spend: {JsonConvert.SerializeObject(new { firstname = "Gilbert", lastname = "Musengi" })}");
                    channel.BasicPublish(exchange, routekey, null, body);
                }
            }
            Assert.Pass();
        }
    }
}