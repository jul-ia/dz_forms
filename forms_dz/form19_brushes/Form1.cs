using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace form19_brushes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.ForestGreen, 20, 20, 30, 60);
            e.Graphics.FillRectangle(Brushes.White, 50, 20, 30, 60);
            e.Graphics.FillRectangle(Brushes.Red, 80, 20, 30, 60);
            e.Graphics.DrawRectangle(Pens.Black, 20, 20, 90, 60);
            e.Graphics.DrawString("Solid Brush", this.Font, Brushes.Black, 20, 85);

            LinearGradientBrush lgBrush_1 = new LinearGradientBrush(
                            new RectangleF(200, 20, 90, 10), Color.Blue, Color.LightBlue, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(lgBrush_1, 200, 20, 90, 60);
            e.Graphics.DrawString("Linear Gredient - Horizontal", this.Font, Brushes.Black, 200, 85);
            LinearGradientBrush lgBrush_2 = new LinearGradientBrush(
                            new RectangleF(0, 0, 10, 60), Color.Blue, Color.LightBlue, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(lgBrush_2, 20, 120, 90, 60);
            e.Graphics.DrawString("Linear Gredient - Vertical", this.Font, Brushes.Black, 20, 185);

            try
            {
                TextureBrush tBrush = new TextureBrush(Image.FromFile("pic.bmp"));
                e.Graphics.FillRectangle(tBrush, 200, 120, 90, 60);
            }
            catch (System.IO.FileNotFoundException)
            {
                e.Graphics.DrawRectangle(Pens.Black, 200, 120, 90, 60);
                e.Graphics.DrawString("Source image", this.Font, Brushes.Black, 209, 135);
                e.Graphics.DrawString(" not found", this.Font, Brushes.Black, 218, 150);
            }
            e.Graphics.DrawString("TextureBrush", this.Font, Brushes.Black, 200, 185);

            HatchBrush hBrush = new HatchBrush(HatchStyle.DottedGrid, Color.Black, Color.Gold);
            e.Graphics.FillRectangle(hBrush, 20, 220, 90, 60);
            e.Graphics.DrawString("HatchBrush - DottedGrid", this.Font, Brushes.Black, 20, 285);

            HatchBrush hBrush_2 = new HatchBrush(HatchStyle.DiagonalCross, Color.Black, Color.Gold);
            e.Graphics.FillRectangle(hBrush_2, 200, 220, 90, 60);
            e.Graphics.DrawString("HatchBrush - DiagonalCross", this.Font, Brushes.Black, 200, 285);

        }
    }
}
