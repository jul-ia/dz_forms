using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form16_planeFly
{
    public partial class Form1 : Form
    {

        System.Drawing.Bitmap sky, plane;
        Graphics g;
        int dx1, dx2;
        Rectangle rct1;
        Rectangle rct2;

        System.Random rnd;

        public Form1()
        {
            InitializeComponent();

            try
            {
                sky = Properties.Resources.sky;
                plane = Properties.Resources.plane;
                this.BackgroundImage = Properties.Resources.sky;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Flight", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            plane.MakeTransparent();
            this.ClientSize = new System.Drawing.Size(new Point(BackgroundImage.Width, BackgroundImage.Height));
            g = Graphics.FromImage(BackgroundImage);
            rnd = new System.Random();

            rct1.X = -40;
            rct1.Y = 20 + rnd.Next(20);
            rct1.Width = plane.Width;
            rct1.Height = plane.Height;

            rct2.X = -40;
            rct2.Y = rct1.Y + plane.Height + (ClientSize.Height - 300) / 2;
            rct2.Width = rct1.Width;
            rct2.Height = rct1.Height;
            dx1 = rnd.Next(5, 9);
            dx2 = rnd.Next(5, 9);
            timer1.Interval = 1;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.DrawImage(sky, new Point(0, 0));
            if (rct1.X < this.ClientRectangle.Width)
                rct1.X += dx1;
            else
            {
                rct1.X = -40;
                rct1.Y = 20 + rnd.Next(40);
                dx1 = rnd.Next(5, 9);
            }

            g.DrawImage(plane, rct1.X, rct1.Y);

            if (rct2.X < this.ClientRectangle.Width)
                rct2.X += dx2;
            else
            {
                rct2.X = -40;
                rct2.Y = rct1.Y + plane.Height + (ClientSize.Height - 300) / 2;
                dx2 = rnd.Next(5, 9);
            }

            g.DrawImage(plane, rct2.X, rct2.Y);
            Rectangle reg = new Rectangle(20, 20, sky.Width - 40, sky.Height - 40);
            g.DrawRectangle(Pens.Black, reg.X, reg.Y, reg.Width - 1, reg.Height - 1);
            this.Invalidate(reg);
        }
    }
}
