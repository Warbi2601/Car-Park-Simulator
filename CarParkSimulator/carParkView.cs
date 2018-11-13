using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkSimulator
{
    partial class carParkView : Form
    {
        public CarPark carParks;

        public carParkView(CarPark car)
        {
            carParks = car;
            try { Spaces = carParks.getMaxSpaces(); }
            catch { };

            InitializeComponent();
        }

        public int Spaces;

        private void carParkView_Load(object sender, EventArgs e)
        {
            const int spaceWidth = 75;

            carPark.Width = (Spaces * spaceWidth);
            int FormWidth = (Spaces * spaceWidth);

            if (FormWidth > spaceWidth * 8) FormWidth = 8 * spaceWidth;
            this.Width = FormWidth;

            for (int i = 0; i < Spaces; i++)
            {
                PictureBox pic = new PictureBox();
                pic.Size = new Size(10, 10);
                pic.Location = new Point((i * spaceWidth) + 32, 20);
                pic.BackColor = Color.Blue;
                pic.Name = i.ToString();

                carPark.Controls.Add(pic);
            }
        }

        void UpdateVisuals()
        {
            //Set all to red by deault;
            foreach (Control c in carPark.Controls)
            {
                c.BackColor = Color.Green;
            }

            //Display all full spaces as green.
            try
            {
                List<SpaceSensor> spaces = carParks.getAvailableSpaces();
                foreach (SpaceSensor s in spaces)
                {
                    foreach (Control c in carPark.Controls)
                    {
                        if (c is PictureBox) if (s.getID() == Int32.Parse(c.Name)) c.BackColor = Color.Red;
                    }
                }
            }
            catch { };

        }

        private void Update_Tick(object sender, EventArgs e)
        {
            UpdateVisuals();
        }

        private void carParkView_Leave(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
