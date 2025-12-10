using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultyMediaJAVA
{
    public partial class Form12 : Form
    {
        private string audioPath = @"D:\Учёба\Мультимедийка\Курсач\Коллекции.mp3";
        public Form12()
        {
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            // Только инициализация плеера БЕЗ управления воспроизведением
            if (axWindowsMediaPlayer1 != null)
            {
                axWindowsMediaPlayer1.settings.setMode("loop", true);
                axWindowsMediaPlayer1.settings.autoStart = false;

                // Только установка файла - управление пользователем
                if (File.Exists(audioPath))
                {
                    axWindowsMediaPlayer1.URL = audioPath;
                    // НЕТ play() - пользователь сам нажимает Play в плеере
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form13 newForm = new Form13();
            newForm.FormClosed += (s, args) => this.Show();
            newForm.Show();
            this.Hide();
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.SkyBlue;
        }
    }
}
