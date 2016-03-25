using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace RentMaster
{
    public class rentalType
    {
        public string rent_type_name { get; set; }
        public Int64 rent_type_id { get; set; }

        public override string ToString()
        {
            return rent_type_name;
        }

        public void get_rental_type_name(Int64 newType, string rentMasterSqlConnection)
        {
            rent_type_id = newType; 
            // this is where we get the information from the database
             //we're already assuming we're working with non nulls here
             string sql = "select * from rent_type where rent_type_id = '" + newType + "';";
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
                            this.rent_type_name = (string)reader["rent_type_name"];
                        }//if (reader.Read())
                    }//using (SQLiteDataReader reader = command.ExecuteReader())
                }//using (SQLiteCommand command = new SQLiteCommand(sql, c))
            }//public void get_rental_type_name(Int64 newType)
        }//public void get_rental_type_name(Int64 newType, string rentMasterSqlConnection)


    }//end class
}
