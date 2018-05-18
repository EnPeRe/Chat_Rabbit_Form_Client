using Chat_Rabbit_Form_Client.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Rabbit_Form_Client
{
    public class UserLoginDB
    {
        SqlConnection con;
        private SqlCommand cmd;



        public UserLoginDB()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
        }
        public User login(string email, string password)
        {
            User user = new User();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string sql = "select * from tbluser where email='" + email + "' and password='" + password + "'";
            ds.Reset();

            using (cmd = new SqlCommand(sql, con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        user.userid = Convert.ToInt32(rdr["userid"].ToString());
                        user.email = rdr["email"].ToString();
                        user.mobile = rdr["mobile"].ToString();
                        user.password = rdr["password"].ToString();
                    }
                }
            }

            return user;
        }
        public List<User> getusers(int id)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            List<User> userlist = new List<User>();
            string sql = "select * from tbluser where userid<>" + id;
            ds.Reset();

            using (cmd = new SqlCommand(sql, con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        User user = new User();
                        user.userid = Convert.ToInt32(rdr["userid"].ToString());
                        user.email = rdr["email"].ToString();
                        user.mobile = rdr["mobile"].ToString();
                        user.password = rdr["password"].ToString();
                        user.dob = rdr["dob"].ToString();
                        userlist.Add(user);
                    }

                }
            }

            return userlist;
        }
    }
}
