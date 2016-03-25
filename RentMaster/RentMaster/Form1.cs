using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections;


namespace RentMaster
{

    public partial class Form1 : Form
    {
        string rentMasterSqlConnection;
        private SQLiteConnection rentMasterSqlConnection2;

        //use datatables instead of datagridview
        DataTable rentalDataTable = new DataTable();
        DataTable guestsDataTable = new DataTable();
        private DataGridView roomsDataGridView = new DataGridView();
        private DataGridView guestsDataGridView = new DataGridView();
        private DataGridView rentaltypesDataGridView;
        private bool showRooms = false;
        private bool showGuests = false;
        SQLiteCommand command;
        //SQLiteDataReader reader;
        GuestForm newGuestForm = new GuestForm();



        public Form1()
        {
            InitializeComponent();
            //set up the variables we care about
            //setuproomsDataGridView();
            //setuprentaltypesDataGridView();
            //get rid of the stuff we don't need right now
            this.Controls.Remove(rentalTypePanel);
            this.Controls.Remove(rentalsPanel);

            //set up the tables
            setupguestsDataTable();
            setuprentalDataTable();
        }

        private void hideRooms()
        {
            if (showRooms == true)
            {
                showRooms = false;
                this.Controls.Remove(roomsDataGridView);
                roomButton.Text = "Show Rentals";
                guestButton.Enabled = true;
            }

        }

        private void setuprentalDataTable()
        {
            //set up the table
            rentalDataTable.Columns.Add("rental_id", typeof(Int64));
            rentalDataTable.Columns.Add("rental_type", typeof(rentalType));
            rentalDataTable.Columns.Add("rental_name", typeof(string));
            rentalDataTable.Columns.Add("guest", typeof(Guest));
            rentalDataTable.Columns.Add("rental_check_in_time", typeof(DateTime));
            rentalDataTable.Columns.Add("rental_expiration_time", typeof(DateTime));
            rentalDataTable.Columns.Add("rental_inout", typeof(bool));
            rentalDataTable.Columns.Add("rental_check_out_time", typeof(DateTime));
            rentalDataTable.Columns.Add("rental_notes", typeof(string));


            //bind it to the viewer
            roomsDataGridView.DataSource = rentalDataTable;

            //the viewer defaults
            roomsDataGridView.Name = "RentalsView";
            roomsDataGridView.Location = new Point(10, 30);
            roomsDataGridView.Size = new Size(750, 250);
            roomsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            roomsDataGridView.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
            roomsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            roomsDataGridView.GridColor = Color.Black;
            roomsDataGridView.RowHeadersVisible = false;
            roomsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;


        }

        private void refreshrentalDataTable()
        {
            //get rid of the previous information
            rentalDataTable.Rows.Clear();

            //get the information from the database
            //now add in the information
            //open the database
            string sql = "select * from rental;";
            string sql2;

            using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))
            {
                c.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        Rental setupRooms = new Rental();
                        rentalType newRoom = new rentalType();
                        while (reader.Read())
                        {
                            setupRooms.rental_id = (Int64)reader["rental_id"];
                            setupRooms.rental_type_id = (Int64)reader["rental_type_id"];
                            sql2 = "select * from rent_type where rent_type_id='" + setupRooms.rental_type_id + "';";
                            using (SQLiteCommand command2 = new SQLiteCommand(sql2, c))
                            {
                                using (SQLiteDataReader reader2 = command2.ExecuteReader())
                                {
                                    newRoom.rent_type_id = setupRooms.rental_type_id;
                                    reader2.Read();
                                    newRoom.rent_type_name = (string)reader2["rent_type_name"];
                                }
                            }

                            setupRooms.rental_name = (string)reader["rental_name"];

                            if (!reader.IsDBNull(reader.GetOrdinal("guest_id")))
                            {
                                //MessageBox.Show("The damn guest id is "+(string)reader["guest_id"]+"!");
                                //setupRooms.guest_id = (Int64)reader["guest_id"];
                                setupRooms.rentalGuest.getGuestData((Int64)reader["guest_id"], rentMasterSqlConnection);
                            }
                            else
                            {
                                setupRooms.rentalGuest.guest_id = 0;
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("rental_check_in_time")))
                            {
                                setupRooms.rental_check_in_time = (DateTime)reader["rental_check_in_time"];
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("rental_expiration_time")))
                            {
                                setupRooms.rental_expiration_time = (DateTime)reader["rental_expiration_time"];
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("rental_inout")))
                            {
                                setupRooms.rental_inout = (bool)reader["rental_inout"];
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("rental_expiration_time")))
                            {
                                setupRooms.rental_check_out_time = (DateTime)reader["rental_expiration_time"];
                            }

                            /* just to make sure it all matches
                            rentalDataTable.Columns.Add("rental_id", typeof(Int64));
                            rentalDataTable.Columns.Add("rental_type", typeof(Rental));
                            rentalDataTable.Columns.Add("rental_name", typeof(string));
                            rentalDataTable.Columns.Add("guest", typeof(Guest));
                            rentalDataTable.Columns.Add("rental_check_in_time", typeof(DateTime));
                            rentalDataTable.Columns.Add("rental_expiration_time", typeof(DateTime));
                            rentalDataTable.Columns.Add("rental_inout", typeof(bool));
                            rentalDataTable.Columns.Add("rental_notes", typeof(string));
                            rentalDataTable.Columns.Add("rental_check_out_time", typeof(DateTime));

                            */

                            rentalDataTable.Rows.Add(setupRooms.rental_id, newRoom, setupRooms.rental_name, setupRooms.rentalGuest,
                                                       setupRooms.rental_check_in_time, setupRooms.rental_expiration_time, 
                                                       setupRooms.rental_inout, setupRooms.rental_check_out_time, 
                                                       setupRooms.rental_notes);
                        }//while(reader.Read())
                    }//using (SQLiteDataReader reader = command.ExecuteReader())
                }//using (SQLiteCommand command = new SQLiteCommand(sql, c))
            }//using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))


        }

        private void setupguestsDataTable()
        {
            guestsDataTable.Columns.Add("guest_id", typeof(Int64));
            guestsDataTable.Columns.Add("guest_first_name", typeof(string));
            guestsDataTable.Columns.Add("guest_last_name", typeof(string));
            guestsDataTable.Columns.Add("guest_email", typeof(string));

            guestsDataGridView.DataSource = guestsDataTable;

            //now the datagridview settings
            //set up the settings
            guestsDataGridView.AllowUserToAddRows = false;
            //the columns to display:  Room type, room name, current guest, check in time, check out time, in/out, notes
            //total columns:  4
            //guestsDataGridView.ColumnCount = 4;
            guestsDataGridView.Name = "GuestsView";
            guestsDataGridView.Location = new Point(10, 30);
            guestsDataGridView.Size = new Size(750, 250);
            guestsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            guestsDataGridView.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
            guestsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guestsDataGridView.GridColor = Color.Black;
            guestsDataGridView.RowHeadersVisible = false;
            guestsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;


        }

        private void refreshguestsDataTable()
        {
            //get rid of the previous information
            guestsDataTable.Rows.Clear();

            //get the information from the database
            //get the data
            //now get the data
            string sql = "select * from guests";
            Int64 guest_id;
            string guest_first_name;
            string guest_last_name;
            string guest_email;


            using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))
            {
                c.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("guest_id")))
                            {
                                guest_id = (Int64)reader["guest_id"];
                            }
                            else
                            {
                                guest_id = 0;
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("guest_first_name")))
                            {
                                guest_first_name = (string)reader["guest_first_name"];
                            }
                            else
                            {
                                guest_first_name = "";
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("guest_last_name")))
                            {
                                guest_last_name = (string)reader["guest_last_name"];
                            }
                            else
                            {
                                guest_last_name = "";
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("guest_email")))
                            {
                                guest_email = (string)reader["guest_email"];
                            }
                            else
                            {
                                guest_email = "";
                            }


                            guestsDataTable.Rows.Add(guest_id, guest_first_name, guest_last_name, guest_email);
                        }//while(reader.Read())

                    }//using (SQLiteDataReader reader = command.ExecuteReader())
                }//using (SQLiteCommand command = new SQLiteCommand(sql, c))
            }//using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))

        }

        private void setupguestsDataGridView()
        {
            
            //first, clear the view
            //guestsDataGridView.Rows.Clear();
            guestsDataGridView.Refresh();

            //set up the settings
            guestsDataGridView.AllowUserToAddRows = false;
            //the columns to display:  Room type, room name, current guest, check in time, check out time, in/out, notes
            //total columns:  4
            guestsDataGridView.ColumnCount = 4;
            guestsDataGridView.Name = "GuestsView";
            guestsDataGridView.Location = new Point(10, 30);
            guestsDataGridView.Size = new Size(750, 250);
            guestsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            guestsDataGridView.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
            guestsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guestsDataGridView.GridColor = Color.Black;
            guestsDataGridView.RowHeadersVisible = false;
            guestsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

            //setup the columns

            /*
            guestsDataGridView.Columns[0].Name = "Guest ID";
            guestsDataGridView.Columns[1].Name = "First Name";
            guestsDataGridView.Columns[2].Name = "Last Name";
            guestsDataGridView.Columns[3].Name = "Email Address";
            */

            //get the data
            //now get the data
            string sql = "select * from guests";
            Int64 guest_id;
            string guest_first_name;
            string guest_last_name;
            string guest_email;


            using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))
            {
                c.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("guest_id")))
                            {
                                guest_id = (Int64)reader["guest_id"];
                            }
                            else
                            {
                                guest_id = 0;
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("guest_first_name")))
                            {
                                guest_first_name = (string)reader["guest_first_name"];
                            }
                            else
                            {
                                guest_first_name = "";
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("guest_last_name")))
                            {
                                guest_last_name = (string)reader["guest_last_name"];
                            }
                            else
                            {
                                guest_last_name = "";
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("guest_email")))
                            {
                                guest_email = (string)reader["guest_email"];
                            }
                            else
                            {
                                guest_email = "";
                            }

                            guestsDataGridView.Rows.Add(guest_id, guest_first_name, guest_last_name, guest_email);
                        }//while(reader.Read())

                    }//using (SQLiteDataReader reader = command.ExecuteReader())
                }//using (SQLiteCommand command = new SQLiteCommand(sql, c))
            }//using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))


        }


        private void setuproomsDataGridView()
        {
            //clear the room
            roomsDataGridView.Rows.Clear();
            roomsDataGridView.Refresh();

            //set up the settings

            roomsDataGridView.AllowUserToAddRows = false;
            //the columns to display:  Room type, room name, current guest, check in time, check out time, in/out, notes
            //total columns:  9
            //roomsDataGridView.ColumnCount = 9;
            roomsDataGridView.Name = "RentalsView";
            roomsDataGridView.Location = new Point(10, 30);
            roomsDataGridView.Size = new Size(750, 250);
            roomsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            roomsDataGridView.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
            roomsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            roomsDataGridView.GridColor = Color.Black;
            roomsDataGridView.RowHeadersVisible = false;
            roomsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

            //set up the columns
            roomsDataGridView.Columns[0].Name = "Rental ID";
            roomsDataGridView.Columns[1].Name = "Rental Type";
            roomsDataGridView.Columns[2].Name = "Rental Name";
            roomsDataGridView.Columns[3].Name = "Current Guest";
            roomsDataGridView.Columns[4].Name = "Check In Time";
            roomsDataGridView.Columns[5].Name = "Expiration Time";
            roomsDataGridView.Columns[6].Name = "In/Out";
            roomsDataGridView.Columns[7].Name = "Check Out Time";
            roomsDataGridView.Columns[8].Name = "Notes";

            //now add in the information
            //open the database
            string sql = "select * from rental;";
            string sql2;

            using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))
            {
                c.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        Rental setupRooms = new Rental();
                        rentalType newRoom = new rentalType();
                        while (reader.Read())
                        {
                            setupRooms.rental_id = (Int64)reader["rental_id"];
                            setupRooms.rental_type_id = (Int64)reader["rental_type_id"];
                            sql2 = "select * from rent_type where rent_type_id='" + setupRooms.rental_type_id + "';";
                            using (SQLiteCommand command2 = new SQLiteCommand(sql2, c))
                            {
                                using (SQLiteDataReader reader2 = command2.ExecuteReader())
                                {
                                    newRoom.rent_type_id = setupRooms.rental_type_id;
                                    reader2.Read();
                                    newRoom.rent_type_name = (string)reader2["rent_type_name"];
                                }
                            }
                            setupRooms.rental_name = (string)reader["rental_name"];
                            if (!reader.IsDBNull(reader.GetOrdinal("guest_id")))
                            {
                                //MessageBox.Show("The damn guest id is "+(string)reader["guest_id"]+"!");
                                setupRooms.rentalGuest.getGuestData((Int64)reader["guest_id"], rentMasterSqlConnection);
                            }
                            else
                            {
                                setupRooms.rentalGuest.guest_id = 0;
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("rental_check_in_time")))
                            {
                                setupRooms.rental_check_in_time = (DateTime)reader["rental_check_in_time"];
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("rental_expiration_time")))
                            {
                                setupRooms.rental_expiration_time = (DateTime)reader["rental_expiration_time"];
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("rental_inout")))
                            {
                                setupRooms.rental_inout = (bool)reader["rental_inout"];
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("rental_expiration_time")))
                            {
                                setupRooms.rental_check_out_time = (DateTime)reader["rental_expiration_time"];
                            }

                            roomsDataGridView.Rows.Add(setupRooms.rental_id, newRoom, setupRooms.rental_name, setupRooms.rentalGuest,
                                                       setupRooms.rental_check_in_time, setupRooms.rental_expiration_time, setupRooms.rental_inout,
                                                       setupRooms.rental_check_out_time, setupRooms.rental_notes);
                        }//while(reader.Read())
                    }//using (SQLiteDataReader reader = command.ExecuteReader())
                }//using (SQLiteCommand command = new SQLiteCommand(sql, c))
            }//using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))


        }

        private void setuprentaltypesDataGridView()
        {
            rentaltypesDataGridView.AllowUserToAddRows = false;


            rentaltypesDataGridView.ColumnCount = 1;
            roomsDataGridView.Name = "RentalTypes";
            rentaltypesDataGridView.Location = new Point(10, 30);
            rentaltypesDataGridView.Size = new Size(750, 250);
            rentaltypesDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            rentaltypesDataGridView.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
            rentaltypesDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            rentaltypesDataGridView.GridColor = Color.Black;
            rentaltypesDataGridView.RowHeadersVisible = false;
            rentaltypesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

            //set up the columns
            rentaltypesDataGridView.Columns[0].Name = "Rental Type";

        }

        private void setuprentalsDataGridView()
        {
            rentaltypesDataGridView.AllowUserToAddRows = false;
            //the columns to display:  Room type, room name, current guest, check in time, check out time, in/out, notes
            //total columns:  7
            rentaltypesDataGridView.ColumnCount = 2;
            roomsDataGridView.Name = "Rentals";
            rentaltypesDataGridView.Location = new Point(10, 30);
            rentaltypesDataGridView.Size = new Size(750, 250);
            rentaltypesDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            rentaltypesDataGridView.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
            rentaltypesDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            rentaltypesDataGridView.GridColor = Color.Black;
            rentaltypesDataGridView.RowHeadersVisible = false;
            rentaltypesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

            //set up the columns
            rentaltypesDataGridView.Columns[0].Name = "Rental Type";
            rentaltypesDataGridView.Columns[1].Name = "Rental Name";
            //the rental type and the name.  Just display that information.


            string sql = "select * from rental;";
            string sql2;
            string rental_type_id;
            using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sql2 = "select * from rent_type WHERE rent_type_id = '" + reader["rental_type_id"] + "';";
                            using (SQLiteCommand cmd2 = new SQLiteCommand(sql2, c))
                            {
                                using (SQLiteDataReader reader2 = cmd2.ExecuteReader())
                                {
                                    reader2.Read();
                                    rental_type_id = (string)reader2["rent_type_name"];
                                    rentaltypesDataGridView.Rows.Add(rental_type_id, reader["rental_name"]);
                                }
                            }
                        }
                    }
                }


            }
        }

        private void newDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //put in the code to create a new database here

            //settings for openFileDialog1
            saveFileDialog1.Title = "Create Database";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Filter = "RentMaster Database(*.rentmaster)|*.rentmaster";

            //it should default to my documents



            DialogResult createFile = saveFileDialog1.ShowDialog();

            //make sure the dialog box opened ok
            if (createFile == DialogResult.OK)
            {

                //create the database
                SQLiteConnection.CreateFile(saveFileDialog1.FileName);

                //open the database
                rentMasterSqlConnection2 = new SQLiteConnection("Data Source=" + openFileDialog1.FileName + ";Version=3");
                rentMasterSqlConnection = "Data Source=" + openFileDialog1.FileName + ";Version=3";

                rentMasterSqlConnection2.Open();


                //now create the tables
                //create the rent type table
                //CREATE TABLE "rent_type" ("rent_type_id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, "rent_type_name" TEXT UNIQUE);
                string sql = "CREATE TABLE \"rent_type\" (\"rent_type_id\" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, \"rent_type_name\" TEXT UNIQUE);";
                //execute the command
                command = new SQLiteCommand(sql, rentMasterSqlConnection2);
                command.ExecuteNonQuery();
                //create the guests
                //CREATE TABLE "Guests"("guest_id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, "guest_first_name" TEXT, "guest_last_name" TEXT, "guest_email" TEXT)

                sql = "CREATE TABLE \"guests\"(\"guest_id\" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, \"guest_first_name\" TEXT, \"guest_last_name\" TEXT, \"guest_email\" TEXT)";
                command = new SQLiteCommand(sql, rentMasterSqlConnection2);
                command.ExecuteNonQuery();


                //create the rentals
                //CREATE TABLE "rental" ("rental_id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, "rental_type_id" INTEGER REFERENCES "rent_type" ("rent_type_id"), "rental_name" TEXT, "guest_id" INTEGER REFERENCES "Guests" ("guest_id"), "rental_check_in_date" DATE, "rental_check_in_time" TIME, "rental_inout" BOOLEAN, "rental_notes" TEXT)
                sql = "CREATE TABLE \"rental\" (\"rental_id\" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, \"rental_type_id\" INTEGER REFERENCES \"rent_type\" (\"rent_type_id\"), \"rental_name\" TEXT, \"guest_id\" INTEGER REFERENCES \"guests\" (\"guest_id\"), \"rental_check_in_date\" DATE, \"rental_check_in_time\" TIME, \"rental_inout\" BOOLEAN, \"rental_notes\" TEXT)";
                command = new SQLiteCommand(sql, rentMasterSqlConnection2);
                command.ExecuteNonQuery();

                //close the database
                command.Dispose();
                rentMasterSqlConnection2.Close();
                rentalsToolStripMenuItem.Enabled = true;


            }


        }

        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //put in the code to open an existing database
            //select the database
            DialogResult openDatabase = openFileDialog1.ShowDialog();

            //set the sqlite connector to this database
            //rentMasterSqlConnection = new SQLiteConnection("Data Source=" + openFileDialog1.FileName + ";Version=3");
            //we're changing how we connect instead of doing all of this opening and closing
            rentMasterSqlConnection = "Data Source=" + openFileDialog1.FileName + ";Version=3";
            rentMasterSqlConnection2 = new SQLiteConnection("Data Source=" + openFileDialog1.FileName + ";Version=3");
            //include some code to error check it
            rentalsToolStripMenuItem.Enabled = true;
            roomButton.Enabled = true;
            guestButton.Enabled = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void roomButton_Click(object sender, EventArgs e)
        {
            //if we're not showing the current rooms
            if (showRooms == false)
            {
                //setup the datagridview
                refreshrentalDataTable();
                //setuproomsDataGridView();

                //populate it with data
                this.Controls.Add(roomsDataGridView);

                //change the button to show that we can hide the rooms
                showGuests = false;
                showRooms = true;
                roomButton.Text = "Hide Rentals";
                guestButton.Enabled = false;
                menuStrip1.Enabled = false;
                filterDataTextBox.Enabled = true;


            }
            else //showRooms == true
            {
                hideRooms();
                menuStrip1.Enabled = true;
                guestButton.Enabled = true;
                filterDataTextBox.Enabled = false;



            }



        }

        private void editRentalTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //disable this menu until they're done
            rentalsToolStripMenuItem.Enabled = false;

            //swap out our panels
            this.Controls.Remove(mainPanel);
            this.Controls.Add(rentalTypePanel);

            //make sure the connection is active
            if (rentMasterSqlConnection == null)
            {
                //CREATE A MESSAGE WINDOW TELLING THEM TO OPEN THE DATABASE
                MessageBox.Show("You must open a database first before adding types!");
                addRentalTypeButton.Enabled = false;
            }
            else
            {
                //ok - let's do some stuff.
                //bring in the data grid view
                //create our data grid view
                rentaltypesDataGridView = null;
                rentaltypesDataGridView = new DataGridView();
                //initialize it
                setuprentaltypesDataGridView();

                this.Controls.Add(rentaltypesDataGridView);
                //go to the database
                //we know the database is open already
                //for the future:  add in some exception catching
                //change this to rentalTypes in the future?
                string sql = "select * from rent_type;";
                using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                rentaltypesDataGridView.Rows.Add(reader["rent_type_name"]);
                            }
                        }
                    }
                }
            }
        }

        private void doneRentalTypeButton_Click(object sender, EventArgs e)
        {
            //get rid of these buttons
            //get rid of the panel

            this.Controls.Remove(rentalTypePanel);

            //get rid of the datagridview
            this.Controls.Remove(rentaltypesDataGridView);

            //reset renttypesDataGridView
            rentaltypesDataGridView = null;

            //bring back the main panel

            this.Controls.Add(mainPanel);

            rentalsToolStripMenuItem.Enabled = true;

        }

        private void addRentalTypeButton_Click(object sender, EventArgs e)
        {
            //take what's inside of addRentalTypeTextBox and insert it into the database
            //then refresh our datagridview for rental types

            if (addRentalTypeTextBox.Text != "")
            {
                //string newRentalType = addRentalTypeTextBox.Text;

                //insert it into the database
                string sql = "INSERT INTO rent_type (rent_type_id, rent_type_name) values (null, '" + addRentalTypeTextBox.Text + "');";

                using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Added " + addRentalTypeTextBox.Text + " to the database!");
                //add a row into the current datatypebox
                rentaltypesDataGridView.Rows.Add(addRentalTypeTextBox.Text);
                addRentalTypeTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("You must enter a new rental type before using this option.");
            }


        }

        private void editRentalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get rid of the other panels
            this.Controls.Remove(mainPanel);

            //add in our own
            this.Controls.Add(rentalsPanel);

            //close off the menu until we're done
            rentalsToolStripMenuItem.Enabled = false;

            //we shouldn't have to check the database but add that in later

            //show off the datagrid
            rentaltypesDataGridView = null;
            rentaltypesDataGridView = new DataGridView();
            setuprentalsDataGridView();
            this.Controls.Add(rentaltypesDataGridView);


            //reset the combobox
            roomTypesListComboBox.Items.Clear();
            using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))
            {
                string sql = "select * from rent_type;";

                c.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        rentalType comboTracker;
                        //add these items into our combobox
                        while (reader.Read())
                        {

                            comboTracker = new rentalType();

                            comboTracker.rent_type_id = (Int64)reader["rent_type_id"];
                            comboTracker.rent_type_name = (string)reader["rent_type_name"];

                            roomTypesListComboBox.Items.Add(comboTracker);
                        }
                    }
                }
            }
        }

        private void rentalsDoneButton_Click(object sender, EventArgs e)
        {
            //ok close all this down
            this.Controls.Remove(rentalsPanel);
            rentaltypesDataGridView = null;

            //add back in the other items
            this.Controls.Add(mainPanel);

            rentalsToolStripMenuItem.Enabled = true;
        }

        private void rentalsAddButton_Click(object sender, EventArgs e)
        {
            //if the text box is blank don't add this stuff
            if (addRentalTextBox.Text == "")
            {
                MessageBox.Show("You have to enter a room - can't be blank.");
            }
            else
            {
                //get the information from the 
            }
        }

        private void rentalsDoneButton_Click_1(object sender, EventArgs e)
        {
            //get rid of the panel
            this.Controls.Remove(rentalsPanel);

            //reset the datagridview and get rid of it
            this.Controls.Remove(rentaltypesDataGridView);
            rentaltypesDataGridView = null;
            roomTypesListComboBox.Items.Clear();

            //reenable our menu item
            rentalsToolStripMenuItem.Enabled = true;

            //bring back the main panel
            this.Controls.Add(mainPanel);
        }

        //this will add a rental item to our spreadsheet list based on the rentalType that's been selected.
        private void rentalsAddButton_Click_1(object sender, EventArgs e)
        {
            //first make sure that we selected something in our combobox
            if (roomTypesListComboBox.SelectedItem == null)
            {
                MessageBox.Show("You must select a rental type before adding a rental!");
            }
            //we've selected an item.  Let's make sure this doesn't already exist in the system.
            else if (addRentalTextBox.Text == "")
            {
                MessageBox.Show("You can't have a blank name!");
            }
            else
            {
                //first, make sure the name is unique
                using (SQLiteConnection c = new SQLiteConnection(rentMasterSqlConnection))
                {
                    string sql = "select * from rental where rental_name='" + addRentalTextBox.Text + "';";

                    c.Open();
                    using (SQLiteCommand command = new SQLiteCommand(sql, c))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Rental names must be unique!");
                            }
                            else
                            {
                                //since it checks out, insert it into the database
                                sql = "INSERT INTO rental(rental_id, rental_type_id, rental_name, guest_id, rental_check_in_time, rental_expiration_time, rental_inout, rental_notes, rental_check_out_time) "
                        + "values(null, '" + (roomTypesListComboBox.SelectedItem as rentalType).rent_type_id + "', '" + addRentalTextBox.Text + "', null, null, null, null, null, null);";
                                //we already have a command so just use that
                                using (SQLiteCommand command2 = new SQLiteCommand(sql, c))
                                {
                                    command2.ExecuteNonQuery();
                                }
                                rentaltypesDataGridView.Rows.Add((roomTypesListComboBox.SelectedItem as rentalType).rent_type_name, addRentalTextBox.Text);
                                //now clear out the selected items
                                roomTypesListComboBox.SelectedIndex = -1;
                                addRentalTextBox.Text = "";
                            }
                        }
                    }
                }
            }
        }

        private void editGuestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //close all of the other items
            //show the current lists of guests.
            //would it be easiest to set it up as a separate form?

            newGuestForm.ShowDialog();

        }

        private void guestButton_Click(object sender, EventArgs e)
        {
            if (showGuests == false)
            {
                //first, disable the other button
                roomButton.Enabled = false;
                menuStrip1.Enabled = false;
                showGuests = true;
                guestButton.Text = "Hide Guests";
                filterDataTextBox.Enabled = true;

                //set up the datagrid view
                //guestsDataGridView = new DataGridView();
                //setupguestsDataGridView();
                refreshguestsDataTable();
                this.Controls.Add(guestsDataGridView);

            }
            else
            {
                roomButton.Enabled = true;
                menuStrip1.Enabled = true;
                showGuests = false;
                filterDataTextBox.Enabled = false;
                guestButton.Text = "Show Guests";
                this.Controls.Remove(guestsDataGridView);
            }


        }

        private void filterDataTextBox_TextChanged(object sender, EventArgs e)
        {
            //first, which are we in?  
            if (showGuests == true)
            {
                //filter the guests
                guestsDataTable.DefaultView.RowFilter = string.Format("guest_first_name LIKE '%{0}%' OR "+
                                                                       "guest_last_name LIKE '%{0}%' OR "+
                                                                      "guest_email LIKE '%{0}%'",
                                                                       filterDataTextBox.Text);

                //this is an experiment
                //guestsDataTable.DefaultView.RowFilter = string.Format("* LIKE '%{0}%'",
                //                                                       filterDataTextBox.Text);


            }

            if (showRooms == true)
            {
                //this works.  We need to be able to change things but let's roll with this for now.

                rentalDataTable.DefaultView.RowFilter = string.Format("rental_name LIKE '%{0}%'"+
                                                                       " OR Convert([guest], 'System.String') LIKE '%{0}%'"
                                                                       ,filterDataTextBox.Text);


            }
        }
    }
}
