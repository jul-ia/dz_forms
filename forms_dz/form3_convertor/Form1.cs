using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form3_convertor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            if (e.KeyChar == '.')
                e.KeyChar = ',';
            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') != -1)
                    e.Handled = true;
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (sender.Equals(textBox1))
                        textBox2.Focus();
                    else
                        button1.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "";
            if ((textBox1.Text.Length == 0) || (textBox2.Text.Length == 0))
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double dollar;
            double hrn;

            try
            {
                dollar = Convert.ToDouble(textBox2.Text);
                hrn = dollar * Convert.ToDouble(textBox1.Text);
                label3.Text = hrn.ToString("n") + " hrn.";
            }
            catch
            {
                textBox1.Focus();
            }
        }

    }
}
