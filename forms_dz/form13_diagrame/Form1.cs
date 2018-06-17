using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form13_diagrame
{
    public partial class Form1 : Form
    {
        private double[] d;

        private void drawDiagram(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font dfont = new Font("Tahoma", 9);
            Font hfont = new Font("Tahoma", 14, FontStyle.Regular);
            string header = "Dollar rate change";

            int wh = (int)g.MeasureString(header, hfont).Width;
            int x = (this.ClientSize.Width - wh) / 2;
            g.DrawString(header, hfont, System.Drawing.Brushes.Aquamarine, x, 5);

            double max = d[0];
            double min = d[0];
            for(int i = 0; i < d.Length; i++)
            {
                if (d[i] > max)
                    max = d[i];
                if (d[i] < min)
                    min = d[i];
            }

            int x1, y1;
            int w, h;
            w = (ClientSize.Width-40-5*(d.Length-1)) / d.Length;
            x1 = 20;

            for(int i = 0; i < d.Length; i++)
            {
                y1 = this.ClientSize.Height - 20 - (int)((this.ClientSize.Height - 100) * (d[i] - min / max - min));
                g.DrawString(Convert.ToString(d[i]), dfont, System.Drawing.Brushes.Black, x1, y1 - 20);

                h = ClientSize.Height - y1 - 20 + 1;
                g.FillRectangle(Brushes.ForestGreen, x1, y1, w, h);
               
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
