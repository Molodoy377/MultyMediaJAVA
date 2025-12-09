using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AxWMPLib;

namespace MultyMediaJAVA
{
    public partial class Form2 : Form
    {
        private string audioPath = @"D:\Учёба\Мультимедийка\Курсач\Основы Java - 1. Введение в Java.mp3";

        public Form2()
        {
            InitializeComponent();
            this.Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1 != null)
            {
                axWindowsMediaPlayer1.Visible = true;           // ПОКАЗЫВАЕМ плеер
                axWindowsMediaPlayer1.uiMode = "full";          // Полный интерфейс с кнопками
                axWindowsMediaPlayer1.Dock = DockStyle.None;     // Фиксируем докинг
                axWindowsMediaPlayer1.Location = new Point(350, 6300); // Фиксируем позицию
                axWindowsMediaPlayer1.settings.volume = 50;
            }
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.SkyBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.Control;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e); // Плеер закрывается автоматически
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            // Только переход - плеер продолжает работать сам
            Form1 newForm = new Form1();
            newForm.FormClosed += (s, args) => this.Show();
            newForm.Show();
            this.Hide();
        }

        private void axWindowsMediaPlayer1_Enter_1(object sender, EventArgs e)
        {
            // Только инициализация плеера БЕЗ управления воспроизведением
            if (axWindowsMediaPlayer1 != null)
            {
                axWindowsMediaPlayer1.settings.setMode("loop", true);

                // Только установка файла - управление пользователем
                if (File.Exists(audioPath))
                {
                    axWindowsMediaPlayer1.URL = audioPath;
                    // НЕТ play() - пользователь сам нажимает Play в плеере
                }
            }
        }
    }
}
