using Chat_Rabbit_Form_Client.Models;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            UserLoginDB dl = new UserLoginDB();

            string email = this.tbUser.Text;
            string password = this.tbPassword.Text;
            User user = dl.login(email, password);
            if (user.userid > 0)
            {
                string sesionusername = user.email;
                string sesionuserid = user.userid.ToString();

                Form1 Chat = new Form1(user);
                Chat.Show();
                this.Hide();
            }
            else
            {
            }

        }
    }
}
