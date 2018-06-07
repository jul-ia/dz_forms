﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form5_avto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum;
            double discount;
            double total;

            sum = 309000;
            discount = 0;
            if (checkBox1.Checked)
                sum += 8390;
            if (checkBox2.Checked)
                sum += 5990;
            if (checkBox3.Checked)
                sum += 7590;

            total = sum;
            string st;
            st = "Price: " + sum.ToString("C");

            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                discount = sum * 0.01;
                total -= discount;
                st += "\nDiscount (1%): " + discount.ToString() + "\nTotal amount: " + total.ToString("C");
            }
            label3.Text = st;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "";
        }
    }
}
