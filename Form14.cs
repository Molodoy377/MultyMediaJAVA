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
    public partial class Form14 : Form
    {
        private const string CorrectAnswer = "using System;\r\nusing System.Collections.Generic;\r\n\r\npublic class X\r\n{\r\n    private List<int> values = new List<int>();\r\n    \r\n    public void Add(int value)\r\n    {\r\n        values.Add(value);\r\n    }\r\n    \r\n    public bool Remove(int value)\r\n    {\r\n        return values.Remove(value);\r\n    }\r\n    \r\n    public int Count => values.Count;\r\n    \r\n    public int[] GetAll()\r\n    {\r\n        return values.ToArray();\r\n    }\r\n}\r\n";
        public Form14()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // При старте очищаем TextBox
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = CorrectAnswer;
        }
    }
}
