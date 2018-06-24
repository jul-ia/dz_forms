using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form17_parnyPicture
{
    public partial class Form1 : Form
    {
        const int nw = 4;
        const int nh = 4;
        const int np = (nw * nh) / 2;
        System.Drawing.Graphics g;
        Bitmap pics;
        int cw, ch;
        int[,] field = new int[nw, nh];

        int nopened = 0;
        int copened = 0;
        int[] open1 = new int[2];
        int[] open2 = new int[2];
        System.Windows.Forms.Timer timer1;

        public Form1()
        {
            InitializeComponent();
        }
    }
}
