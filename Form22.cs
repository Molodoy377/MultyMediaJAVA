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
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form19 newForm = new Form19();
            newForm.FormClosed += (s, args) => this.Show();
            newForm.Show();
            this.Hide();
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.SkyBlue;
        }
        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackColor = Color.SkyBlue;
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.SkyBlue;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.FormClosed += (s, args) => this.Show();
            newForm.Show();
            this.Hide();
        }
    }
}
