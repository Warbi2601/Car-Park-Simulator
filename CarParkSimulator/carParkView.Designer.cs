namespace CarParkSimulator
{
    partial class carParkView
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
            this.components = new System.ComponentModel.Container();
            this.carPark = new System.Windows.Forms.Panel();
            this.Update = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // carPark
            // 
            this.carPark.BackgroundImage = global::CarParkSimulator.Properties.Resources.ParkingSpace;
            this.carPark.Location = new System.Drawing.Point(0, 0);
            this.carPark.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.carPark.Name = "carPark";
            this.carPark.Size = new System.Drawing.Size(505, 171);
            this.carPark.TabIndex = 0;
            // 
            // Update
            // 
            this.Update.Enabled = true;
            this.Update.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // carParkView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(505, 194);
            this.Controls.Add(this.carPark);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "carParkView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "carParkView";
            this.Deactivate += new System.EventHandler(this.carParkView_Leave);
            this.Load += new System.EventHandler(this.carParkView_Load);
            this.Leave += new System.EventHandler(this.carParkView_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel carPark;
        private System.Windows.Forms.Timer Update;
    }
}