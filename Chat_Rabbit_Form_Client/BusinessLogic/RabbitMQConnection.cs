using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Rabbit_Form_Client
{
    public class RabbitMQConnection
    {
        public IConnection GetConnection()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "192.168.99.100";
            factory.VirtualHost = "/";
            return factory.CreateConnection();
        }

        public string SendToForm(IConnection con, string message, string friendqueue)
        {
            var factory = new ConnectionFactory() { HostName = "192.168.99.100" };
            using (var channel = con.CreateModel())
            {
                channel.QueueDeclare(queue: friendqueue,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: friendqueue,
                                     basicProperties: null,
                                     body: body);
            }
            return message;
        }



        public bool send(IConnection con, string message, string friendqueue)
        {
            try
            {
                IModel channel = con.CreateModel();
                channel.ExchangeDeclare("messageexchange", ExchangeType.Direct);
                channel.QueueDeclare(friendqueue, true, false, false, null);
                channel.QueueBind(friendqueue, "messageexchange", friendqueue, null);
                var msg = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("messageexchange", friendqueue, null, msg);
            }
            catch (Exception e)
            {
                throw null;
            }
            return true;

        }
        public string receive(IConnection con, string myqueue)
        {
            try
            {
                IModel channel = con.CreateModel();
                channel.QueueDeclare(queue: myqueue, durable: true, exclusive: false, autoDelete: false, arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                BasicGetResult result = channel.BasicGet(queue: myqueue, autoAck: true);
                if (result != null)
                    return Encoding.UTF8.GetString(result.Body);
                else
                    return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

        }
    }
}
