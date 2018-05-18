using Chat_Rabbit_Form_Client.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Rabbit_Form_Client
{
    public partial class Form1 : Form
    {
        StringBuilder textRecived;
        User user;


        public Form1(User user)
        {
            InitializeComponent();
            textRecived = new StringBuilder();
            this.user = user;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.ChatLoad();
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            RabbitMQConnection obj = new RabbitMQConnection();
            IConnection con = obj.GetConnection();

            //bool flag = obj.send(con, this.tbMessageSent.Text, "frendqueue");

            this.tbMessagesDisplay.Text = textRecived.Append("Me: ").AppendLine(obj.SendToForm(con, this.tbMessageSent.Text, "friendqueue")).ToString();

            //this.ChatLoad();
            this.tbMessagesDisplay.Text = textRecived.Append("The Other: ").AppendLine(obj.receive(con, "friendqueue")).ToString();          
        }

        private void ChatLoad()
        {
            var factory = new ConnectionFactory() { HostName = "192.168.99.100" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "friendqueue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    this.tbMessagesDisplay.Text = this.textRecived.Append("The other: ").AppendLine(message).ToString();
                };
                channel.BasicConsume(queue: "friendqueue",
                                     autoAck: true,
                                     consumer: consumer);
            }
        }
    }
}
