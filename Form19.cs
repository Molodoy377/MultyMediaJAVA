using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultyMediaJAVA
{
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.FormClosed += (s, args) => this.Show();
            newForm.Show();
            this.Hide();
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.SkyBlue;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.SkyBlue;
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
        }
        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.SkyBlue;
        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
        }
        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.SkyBlue;
        }
        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form20 newForm = new Form20();
            newForm.FormClosed += (s, args) => this.Show();
            newForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form21 newForm = new Form21();
            newForm.FormClosed += (s, args) => this.Show();
            newForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form22 newForm = new Form22();
            newForm.FormClosed += (s, args) => this.Show();
            newForm.Show();
            this.Hide();
        }
    }
}
