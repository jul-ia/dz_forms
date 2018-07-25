using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form20_runningString
{
    public partial class Form1 : Form
    {
        Graphics g;

        Bitmap baner;
        Rectangle rct;

        public Form1()
        {
            InitializeComponent();
            //try
            //{
            //    baner = new Bitmap("pic.bmp");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Failed to load baner file\n" + ex.ToString(), "Baner");
            //    this.Close();
            //    return;
            //}
            baner = Properties.Resources.pic;

            g = this.CreateGraphics();
            rct.X = 0;
            rct.Y = 0;
            rct.Width = baner.Width;
            rct.Height = baner.Height;

            timer1.Interval = 15;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rct.X -= 1;

            if (Math.Abs(rct.X) > rct.Width)
                rct.X += rct.Width;

            for (int i = 0; i <= Convert.ToInt16(this.ClientSize.Width / rct.Width) + 1; i++)
                g.DrawImage(baner, rct.X + i * rct.Width, rct.Y);
        }
    }
}
