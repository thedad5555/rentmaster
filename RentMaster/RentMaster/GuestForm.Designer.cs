namespace RentMaster
{
    partial class GuestForm
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
            this.guestViewPanel = new System.Windows.Forms.Panel();
            this.guestFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.guestViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // guestViewPanel
            // 
            this.guestViewPanel.Controls.Add(this.textBox1);
            this.guestViewPanel.Controls.Add(this.guestFirstNameTextBox);
            this.guestViewPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guestViewPanel.Location = new System.Drawing.Point(0, 361);
            this.guestViewPanel.Name = "guestViewPanel";
            this.guestViewPanel.Size = new System.Drawing.Size(784, 100);
            this.guestViewPanel.TabIndex = 0;
            // 
            // guestFirstNameTextBox
            // 
            this.guestFirstNameTextBox.Location = new System.Drawing.Point(12, 13);
            this.guestFirstNameTextBox.Name = "guestFirstNameTextBox";
            this.guestFirstNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.guestFirstNameTextBox.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(219, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // GuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.guestViewPanel);
            this.Name = "GuestForm";
            this.Text = "GuestForm";
            this.Load += new System.EventHandler(this.GuestForm_Load);
            this.guestViewPanel.ResumeLayout(false);
            this.guestViewPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel guestViewPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox guestFirstNameTextBox;
    }
}