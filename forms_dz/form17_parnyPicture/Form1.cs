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
        const int nh = 3;
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

        private void cell(int i, int j)
        {
            int x, y;
            x = i * (cw + 2);
            y = j * (ch + 2) + menuStrip1.Height;

            if (field[i, j] > 200)
                g.FillRectangle(SystemBrushes.Control, x, y, cw + 2, ch + 2);

            if (field[i, j] > 100 && field[i, j] < 200)
            {
                g.DrawImage(pics, new Rectangle(x + 1, y + 1, cw, ch), new Rectangle((field[i, j] - 100) * cw, 0, cw, ch), GraphicsUnit.Pixel);
                g.DrawRectangle(Pens.Black, x + 1, y + 1, cw, ch);
            }

            if (field[i, j] > 0 && field[i, j] < 100)
            {
                g.FillRectangle(SystemBrushes.Control, x + 1, y + 1, cw, ch);
                g.DrawRectangle(Pens.Black, x + 1, y + 1, cw, ch);
            }
        }

        private void drawField()
        {
            for (int i = 0; i < nw; i++)
                for (int j = 0; j < nh; j++)
                    this.cell(i, j);
        }

        private void newGame()
        {
            Random rnd = new Random();
            int rndN;
            int[] buf = new int[np];

            for (int i = 0; i < nw; i++)
            {
                for (int j = 0; j < nh; j++)
                {
                    do
                    {
                        rndN = rnd.Next(np) + 1;
                    } while (buf[rndN - 1] == 2);
                    field[i, j] = rndN;
                    buf[rndN - 1]++;
                }
            }
            nopened = 0;
            copened = 0;
            this.drawField();
        }



        public Form1()
        {
            InitializeComponent();

            try
            {
                pics = new Bitmap("picture.bmp");
            }
            catch (Exception e)
            {
                MessageBox.Show("File 'picture.bmp' not found\n"+e.ToString(), "Парные картинки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            cw = (int)(pics.Width / np);
            ch = pics.Height;

            this.ClientSize = new System.Drawing.Size(nw * (cw + 2) + 1, nh * (ch + 2) + 1 + menuStrip1.Height);
            g = this.CreateGraphics();

            timer1 = new Timer();
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            timer1.Interval = 200;

            newGame();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            {
            int i, j;
            i = e.X / (cw + 3);
            j = (e.Y - menuStrip1.Height) / (ch + 3);

            if (timer1.Enabled && field[i, j] > 200)
            {
                return;
            }

            if (field[i, j] > 200)
                return;

            if (copened == 0)
            {
                copened++;
                open1[0] = i;
                open1[1] = j;
                field[i, j] += 100;
                this.cell(i, j);
                return;
            }
            if (copened == 1)
            {
                open2[0] = i;
                open2[1] = j;

                if (open1[0] == open2[0] && open1[1] == open2[1])
                    return;
                else
                {
                    copened++;
                    field[i, j] += 100;
                    this.cell(i, j);
                    if (field[open1[0], open1[1]] == field[open2[0], open2[1]])
                    {
                        nopened++;
                        field[open1[0], open1[1]] += 100;
                        field[open2[0], open2[1]] += 100;
                        copened = 0;
                        timer1.Enabled = true;
                    }
                }
                return;
            }
            if (copened == 2)
            {
                field[open1[0], open1[1]] -= 100;
                field[open2[0], open2[1]] -= 100;
                this.cell(open1[0], open1[1]);
                this.cell(open2[0], open2[1]);
                open1[0] = i;
                open1[1] = j;
                copened = 1;
                field[i, j] += 100;
                this.cell(i, j);
            }
        }
    }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //AboutBox1 a;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawField();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            this.cell(open1[0], open1[1]);
            this.cell(open2[0], open2[1]);

            timer1.Enabled = false;
            if (nopened == np)
                MessageBox.Show("You finished the game!");
        }
       
    }
}
