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
    class Register
    {
        private DBconnect db;

        public int individualRegister(string name, string surname, string dob, string email, string number, string password)
        {
            string command = "INSERT INTO individual (Name, Surname, DateOfBirth, Email, ContactNumber, Password) VALUES (" + "'" + 
                name + "'" + "," + "'" + surname + "'" + "," + "'" + dob + "'" + "," + "'"+ email + "'" + "," + "'" + number + "'" + "," + "'" + password + "'"+ ");";

            try
            {
                db = new DBconnect();
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand(command, db.connection);
                cmd.ExecuteNonQuery();
                db.closeConnection();
                return 1;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }
    }
}
