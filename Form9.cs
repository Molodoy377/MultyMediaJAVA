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
    public partial class Form9 : Form
    {
        private string audioPath = @"D:\Учёба\Мультимедийка\Курсач\Сокеты.mp3";
        public Form9()
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
    }
}
