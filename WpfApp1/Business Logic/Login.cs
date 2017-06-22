using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using WpfApp1.DB_Layer;

namespace WpfApp1.Business_Logic
{
    class Login
    {
        private DBconnect db;

      

        public int LoginAttempt(string Email, string Password)
        {
            string email = Email;
            string password = Password;
            string command = "SELECT * from individual where Email='" + email + "' and Password='" + password + "'";
            try
            {
                db = new DBconnect();
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand(command, db.connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                cmd.CommandType = System.Data.CommandType.Text;
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                if(ds.Tables[0].Rows.Count > 0)
                {
                    db.closeConnection();
                    return 1;
                }
                else if (ds.Tables[0].Rows.Count > 1)
                {
                    db.closeConnection();
                    return 2;
                }
                else if (ds.Tables[0].Rows.Count == 0)
                {
                    db.closeConnection();
                    return 0;
                    
                }
                else
                {
                    db.closeConnection();
                    return 3;
                }
                
                
            }
            catch (Exception ex)
            {
                
                Console.Write(ex.ToString());
                return 3;
            }
        }
    }
}
