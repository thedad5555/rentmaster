using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace RentMaster
{
    class Guest
    {
        public Int64 guest_id { get; set; }
        public string guest_first_name { get; set; }
        public string guest_last_name { get; set; }
        public string guest_email { get; set; }

        public override string ToString()
        {
            return guest_first_name + " " + guest_last_name;
        }

        public void getGuestData(Int64 newGuestID, string rentMasterSqlConnection)
        {
            //this is where we get the information from the database
            //we're already assuming we're working with non nulls here
            string sql = "select * from guests where guest_id = '" + newGuestID + "';";
            using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))
            {
                c.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        //if there's actually a value to pull
                        if (reader.Read())
                        {
                            guest_id = newGuestID;
                            if (!reader.IsDBNull(reader.GetOrdinal("guest_first_name")))
                            {
                                guest_first_name = (string)reader["guest_first_name"];

                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("guest_last_name")))
                            {
                                guest_last_name = (string)reader["guest_last_name"];

                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("guest_email")))
                            {
                                guest_email = (string)reader["guest_email"];

                            }
                        }//if (reader.Read())
                    }//using (SQLiteDataReader reader = command.ExecuteReader())

                }//using (SQLiteCommand command = new SQLiteCommand(sql, c))
            }//using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))

        }//public void getGuestData(Int64 newGuestID, string rentMasterSqlConnection)
    }//class Guest
}//namespace RentMaster
