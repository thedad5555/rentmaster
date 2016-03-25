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
    public partial class GuestForm : Form
    {
        private DataGridView guestView;

        public GuestForm()
        {
            InitializeComponent();
            this.Size = new Size(800, 500);
        }

        private void GuestForm_Load(object sender, EventArgs e)
        {
            
            guestView = new DataGridView();
            //set up the default elements
            //total columns for now:  4
            guestView.AllowUserToAddRows = false;
            //the columns to display:  Room type, room name, current guest, check in time, check out time, in/out, notes
            //total columns:  8
            guestView.ColumnCount = 4;
            guestView.Name = "GuestsView";
            guestView.Location = new Point(10, 30);
            guestView.Size = new Size(750, 250);
            guestView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            guestView.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
            guestView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            guestView.GridColor = Color.Black;
            guestView.RowHeadersVisible = false;
            guestView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

            //set up the columns
            guestView.Columns[0].Name = "Rental ID";
            guestView.Columns[1].Name = "Rental Type";
            guestView.Columns[2].Name = "Rental Name";
            guestView.Columns[3].Name = "Current Guest";

            //add this datagridview to the current item
            this.Controls.Add(guestView);

            //populate the view with the data from the table



        }

    }
}
