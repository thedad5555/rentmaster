namespace RentMaster
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rentalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRentalTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRentalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.roomButton = new System.Windows.Forms.Button();
            this.guestButton = new System.Windows.Forms.Button();
            this.addRentalTypeButton = new System.Windows.Forms.Button();
            this.doneRentalTypeButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.filterDataTextBox = new System.Windows.Forms.TextBox();
            this.rentalTypePanel = new System.Windows.Forms.Panel();
            this.addRentalTypeTextBox = new System.Windows.Forms.TextBox();
            this.rentalsPanel = new System.Windows.Forms.Panel();
            this.roomTypesListComboBox = new System.Windows.Forms.ComboBox();
            this.rentaltypeLabel = new System.Windows.Forms.Label();
            this.RentalNameLabel = new System.Windows.Forms.Label();
            this.addRentalTextBox = new System.Windows.Forms.TextBox();
            this.rentalsDoneButton = new System.Windows.Forms.Button();
            this.rentalsAddButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.rentalTypePanel.SuspendLayout();
            this.rentalsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.rentalsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDatabaseToolStripMenuItem,
            this.openDatabaseToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // newDatabaseToolStripMenuItem
            // 
            this.newDatabaseToolStripMenuItem.Name = "newDatabaseToolStripMenuItem";
            this.newDatabaseToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.newDatabaseToolStripMenuItem.Text = "New Database";
            this.newDatabaseToolStripMenuItem.Click += new System.EventHandler(this.newDatabaseToolStripMenuItem_Click);
            // 
            // openDatabaseToolStripMenuItem
            // 
            this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
            this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openDatabaseToolStripMenuItem.Text = "Open Database";
            this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // rentalsToolStripMenuItem
            // 
            this.rentalsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editRentalTypesToolStripMenuItem,
            this.editRentalsToolStripMenuItem});
            this.rentalsToolStripMenuItem.Enabled = false;
            this.rentalsToolStripMenuItem.Name = "rentalsToolStripMenuItem";
            this.rentalsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.rentalsToolStripMenuItem.Text = "Rentals";
            // 
            // editRentalTypesToolStripMenuItem
            // 
            this.editRentalTypesToolStripMenuItem.Name = "editRentalTypesToolStripMenuItem";
            this.editRentalTypesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.editRentalTypesToolStripMenuItem.Text = "Edit Rental Types";
            this.editRentalTypesToolStripMenuItem.Click += new System.EventHandler(this.editRentalTypesToolStripMenuItem_Click);
            // 
            // editRentalsToolStripMenuItem
            // 
            this.editRentalsToolStripMenuItem.Name = "editRentalsToolStripMenuItem";
            this.editRentalsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.editRentalsToolStripMenuItem.Text = "Edit Rentals";
            this.editRentalsToolStripMenuItem.Click += new System.EventHandler(this.editRentalsToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // roomButton
            // 
            this.roomButton.Enabled = false;
            this.roomButton.Location = new System.Drawing.Point(0, 30);
            this.roomButton.Name = "roomButton";
            this.roomButton.Size = new System.Drawing.Size(106, 23);
            this.roomButton.TabIndex = 1;
            this.roomButton.Text = "Show Rentals";
            this.roomButton.UseVisualStyleBackColor = true;
            this.roomButton.Click += new System.EventHandler(this.roomButton_Click);
            // 
            // guestButton
            // 
            this.guestButton.Enabled = false;
            this.guestButton.Location = new System.Drawing.Point(111, 30);
            this.guestButton.Name = "guestButton";
            this.guestButton.Size = new System.Drawing.Size(109, 23);
            this.guestButton.TabIndex = 2;
            this.guestButton.Text = "Show Guests";
            this.guestButton.UseVisualStyleBackColor = true;
            this.guestButton.Click += new System.EventHandler(this.guestButton_Click);
            // 
            // addRentalTypeButton
            // 
            this.addRentalTypeButton.Location = new System.Drawing.Point(10, 36);
            this.addRentalTypeButton.Name = "addRentalTypeButton";
            this.addRentalTypeButton.Size = new System.Drawing.Size(99, 23);
            this.addRentalTypeButton.TabIndex = 3;
            this.addRentalTypeButton.Text = "Add Rental Type";
            this.addRentalTypeButton.UseVisualStyleBackColor = true;
            this.addRentalTypeButton.Click += new System.EventHandler(this.addRentalTypeButton_Click);
            // 
            // doneRentalTypeButton
            // 
            this.doneRentalTypeButton.Location = new System.Drawing.Point(189, 36);
            this.doneRentalTypeButton.Name = "doneRentalTypeButton";
            this.doneRentalTypeButton.Size = new System.Drawing.Size(75, 23);
            this.doneRentalTypeButton.TabIndex = 4;
            this.doneRentalTypeButton.Text = "Done";
            this.doneRentalTypeButton.UseVisualStyleBackColor = true;
            this.doneRentalTypeButton.Click += new System.EventHandler(this.doneRentalTypeButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.filterDataTextBox);
            this.mainPanel.Controls.Add(this.roomButton);
            this.mainPanel.Controls.Add(this.guestButton);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainPanel.Location = new System.Drawing.Point(0, 335);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 65);
            this.mainPanel.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter";
            // 
            // filterDataTextBox
            // 
            this.filterDataTextBox.Enabled = false;
            this.filterDataTextBox.Location = new System.Drawing.Point(3, 4);
            this.filterDataTextBox.Name = "filterDataTextBox";
            this.filterDataTextBox.Size = new System.Drawing.Size(217, 20);
            this.filterDataTextBox.TabIndex = 3;
            this.filterDataTextBox.TextChanged += new System.EventHandler(this.filterDataTextBox_TextChanged);
            // 
            // rentalTypePanel
            // 
            this.rentalTypePanel.Controls.Add(this.addRentalTypeTextBox);
            this.rentalTypePanel.Controls.Add(this.addRentalTypeButton);
            this.rentalTypePanel.Controls.Add(this.doneRentalTypeButton);
            this.rentalTypePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rentalTypePanel.Location = new System.Drawing.Point(0, 270);
            this.rentalTypePanel.Name = "rentalTypePanel";
            this.rentalTypePanel.Size = new System.Drawing.Size(800, 65);
            this.rentalTypePanel.TabIndex = 6;
            // 
            // addRentalTypeTextBox
            // 
            this.addRentalTypeTextBox.Location = new System.Drawing.Point(12, 3);
            this.addRentalTypeTextBox.Name = "addRentalTypeTextBox";
            this.addRentalTypeTextBox.Size = new System.Drawing.Size(251, 20);
            this.addRentalTypeTextBox.TabIndex = 5;
            // 
            // rentalsPanel
            // 
            this.rentalsPanel.Controls.Add(this.roomTypesListComboBox);
            this.rentalsPanel.Controls.Add(this.rentaltypeLabel);
            this.rentalsPanel.Controls.Add(this.RentalNameLabel);
            this.rentalsPanel.Controls.Add(this.addRentalTextBox);
            this.rentalsPanel.Controls.Add(this.rentalsDoneButton);
            this.rentalsPanel.Controls.Add(this.rentalsAddButton);
            this.rentalsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rentalsPanel.Location = new System.Drawing.Point(0, 181);
            this.rentalsPanel.Name = "rentalsPanel";
            this.rentalsPanel.Size = new System.Drawing.Size(800, 89);
            this.rentalsPanel.TabIndex = 8;
            // 
            // roomTypesListComboBox
            // 
            this.roomTypesListComboBox.FormattingEnabled = true;
            this.roomTypesListComboBox.Location = new System.Drawing.Point(375, 11);
            this.roomTypesListComboBox.Name = "roomTypesListComboBox";
            this.roomTypesListComboBox.Size = new System.Drawing.Size(121, 21);
            this.roomTypesListComboBox.Sorted = true;
            this.roomTypesListComboBox.TabIndex = 7;
            // 
            // rentaltypeLabel
            // 
            this.rentaltypeLabel.AutoSize = true;
            this.rentaltypeLabel.Location = new System.Drawing.Point(511, 14);
            this.rentaltypeLabel.Name = "rentaltypeLabel";
            this.rentaltypeLabel.Size = new System.Drawing.Size(65, 13);
            this.rentaltypeLabel.TabIndex = 5;
            this.rentaltypeLabel.Text = "Rental Type";
            // 
            // RentalNameLabel
            // 
            this.RentalNameLabel.AutoSize = true;
            this.RentalNameLabel.Location = new System.Drawing.Point(286, 11);
            this.RentalNameLabel.Name = "RentalNameLabel";
            this.RentalNameLabel.Size = new System.Drawing.Size(69, 13);
            this.RentalNameLabel.TabIndex = 3;
            this.RentalNameLabel.Text = "Rental Name";
            // 
            // addRentalTextBox
            // 
            this.addRentalTextBox.Location = new System.Drawing.Point(11, 8);
            this.addRentalTextBox.Name = "addRentalTextBox";
            this.addRentalTextBox.Size = new System.Drawing.Size(264, 20);
            this.addRentalTextBox.TabIndex = 2;
            // 
            // rentalsDoneButton
            // 
            this.rentalsDoneButton.Location = new System.Drawing.Point(145, 33);
            this.rentalsDoneButton.Name = "rentalsDoneButton";
            this.rentalsDoneButton.Size = new System.Drawing.Size(75, 23);
            this.rentalsDoneButton.TabIndex = 1;
            this.rentalsDoneButton.Text = "Done";
            this.rentalsDoneButton.UseVisualStyleBackColor = true;
            this.rentalsDoneButton.Click += new System.EventHandler(this.rentalsDoneButton_Click_1);
            // 
            // rentalsAddButton
            // 
            this.rentalsAddButton.Location = new System.Drawing.Point(8, 33);
            this.rentalsAddButton.Name = "rentalsAddButton";
            this.rentalsAddButton.Size = new System.Drawing.Size(75, 23);
            this.rentalsAddButton.TabIndex = 0;
            this.rentalsAddButton.Text = "Add Rental";
            this.rentalsAddButton.UseVisualStyleBackColor = true;
            this.rentalsAddButton.Click += new System.EventHandler(this.rentalsAddButton_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.rentalsPanel);
            this.Controls.Add(this.rentalTypePanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.rentalTypePanel.ResumeLayout(false);
            this.rentalTypePanel.PerformLayout();
            this.rentalsPanel.ResumeLayout(false);
            this.rentalsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDatabaseToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button roomButton;
        private System.Windows.Forms.Button guestButton;
        private System.Windows.Forms.ToolStripMenuItem rentalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRentalTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRentalsToolStripMenuItem;
        private System.Windows.Forms.Button addRentalTypeButton;
        private System.Windows.Forms.Button doneRentalTypeButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel rentalTypePanel;
        private System.Windows.Forms.TextBox addRentalTypeTextBox;
        private System.Windows.Forms.Panel rentalsPanel;
        private System.Windows.Forms.Label rentaltypeLabel;
        private System.Windows.Forms.Label RentalNameLabel;
        private System.Windows.Forms.TextBox addRentalTextBox;
        private System.Windows.Forms.Button rentalsDoneButton;
        private System.Windows.Forms.Button rentalsAddButton;
        private System.Windows.Forms.ComboBox roomTypesListComboBox;
        private System.Windows.Forms.TextBox filterDataTextBox;
        private System.Windows.Forms.Label label1;
    }
}

