using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form12_drawString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Microsoft Visual C#", this.Font, Brushes.DarkGreen, 10, 10);
            Font afont = new Font("Tahoma", 12, FontStyle.Regular);
            e.Graphics.DrawString("Microsoft Visual C#", afont, Brushes.Black, 10, 30);

            Font hfont = new Font("Tahoma", 40, FontStyle.Regular);
            string header = "Hello world!";
            int w = (int)e.Graphics.MeasureString(header, hfont).Width;
            int h = (int)e.Graphics.MeasureString(header, hfont).Height;

            int x = (this.ClientSize.Width - w) / 2;
            int y = (this.ClientSize.Height - h) / 2;
            e.Graphics.DrawString(header, hfont, System.Drawing.Brushes.DarkGoldenrod, x, y +h);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
