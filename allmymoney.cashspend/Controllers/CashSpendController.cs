using System.Collections.Generic;
using System.Text;
using allmymoney.cashspend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace allmymoney.cashspend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CashSpendController : ControllerBase
    {
        CashSpendContext db;
        public CashSpendController(CashSpendContext _db)
        {
            db = _db;
        }
        // POST: api/CashSpend
        [HttpPost]
        public void Post([FromBody] CashSpendEntry value)
        {
            db.CashSpendEntries.Add(value);
            db.SaveChanges();

            SendMessageToBroker(value);
        }

        private void SendMessageToBroker(CashSpendEntry entry)
        {
            var connectionFactory = new ConnectionFactory { HostName = "10.0.75.1", UserName = "allmymoney", Password= "allmymoney" };
            using ( var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    string exchange = "spendexchange";
                    string routekey = "spend.cash";
                    channel.ExchangeDeclare(exchange, ExchangeType.Topic, true, false, null);
                    channel.QueueBind(channel.QueueDeclare("spend", true, false, false, null).QueueName, exchange, routekey, null);
                    byte[] body = Encoding.UTF8.GetBytes($"Cash spend: {JsonConvert.SerializeObject(entry)}");
                    channel.BasicPublish(exchange, routekey, null, body);
                }
            }
        }

        [HttpGet]
        public IEnumerable<CashSpendEntry> Get() =>
            db.CashSpendEntries;
    }
}
