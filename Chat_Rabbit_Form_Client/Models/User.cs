using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Rabbit_Form_Client.Models
{
    public class User
    {
        public int userid { get; set; }

        public string email { get; set; }

        public string mobile { get; set; }

        public string password { get; set; }

        public string confirmpassword { get; set; }

        public string dob { get; set; }
    }
}
