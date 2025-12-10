using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultyMediaJAVA
{
    public partial class Form23 : Form
    {
        private string currentText = "";
        private DateTime startTime;
        private bool isTiming = false;
        private readonly Random rand = new Random();
        private readonly string[] testTexts = {
        "HELLO WORLD", "JAVA PROGRAMMING", "C# WINDOWS FORMS",
        "TEXT TYPING TEST", "SOFTWARE DEVELOPMENT", "QUICK BROWN FOX" 
        };
        public Form23()
        {
            InitializeComponent();
            textBox1.TextChanged += textBox1_TextChanged;  // Было textBoxInput_TextChanged
            textBox1.KeyDown += textBox1_KeyDown;
            GenerateNewText();
        }
        private void GenerateNewText()
        {
            // Генерируем случайный текст
            currentText = testTexts[rand.Next(testTexts.Length)];

            // Создаем изображение с текстом
            pictureBox1.Image = CreateTextImage(currentText);

            // Очищаем поле ввода
            textBox1.Text = "";
            textBox1.Focus();

            // Сбрасываем время
            label1.Text = "Время: 0с";
            isTiming = false;
            timer1.Stop();

            label2.Text = "Результат: --";
        }

        private Bitmap CreateTextImage(string text)
        {
            // Размеры изображения
            int width = 700;
            int height = 180;
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);

            // Фон
            g.Clear(Color.LightGray);
            g.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), 0, 0, width, height);

            // Градиентный фон
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0), new Point(width, height),
                Color.WhiteSmoke, Color.LightBlue))
            {
                g.FillRectangle(brush, 50, 30, width - 100, height - 60);
            }

            // Текст с эффектами
            string displayText = text.ToUpper();
            Font font = new Font("Arial Black", 28, FontStyle.Bold);
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            // Тень текста
            g.DrawString(displayText, font, Brushes.DarkGray, new PointF(52, 32), sf);
            // Основной текст
            g.DrawString(displayText, font, Brushes.DarkBlue, new PointF(50, 30), sf);

            g.Dispose();
            return bmp;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            isTiming = false;

            string userText = textBox1.Text.Trim().ToUpper();
            TimeSpan elapsed = DateTime.Now - startTime;

            bool isCorrect = userText == currentText;

            if (isCorrect && elapsed.TotalSeconds > 0)  // ✅ Защита от деления на 0
            {
                // ✅ ТОЧНЫЙ подсчёт символов в минуту
                int charCount = currentText.Length;  // Количество символов в тексте
                double seconds = elapsed.TotalSeconds;
                double wpm = (charCount / seconds) * 60;  // символов/мин

                label2.Text = $"✓ ПРАВИЛЬНО! {wpm:F1} зн/мин ({seconds:F1}с)";
                label2.ForeColor = Color.Green;
                label2.Font = new Font(label2.Font.FontFamily, 11, FontStyle.Bold);
            }
            else if (isCorrect)
            {
                label2.Text = "✓ ПРАВИЛЬНО! (слишком быстро)";
                label2.ForeColor = Color.Green;
            }
            else
            {
                label2.Text = $"✗ ОШИБКА! Правильно: {currentText}";
                label2.ForeColor = Color.Red;
            }

            pictureBox1.BackColor = isCorrect ? Color.LightGreen : Color.LightCoral;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateNewText();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!isTiming)
            {
                startTime = DateTime.Now;
                isTiming = true;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isTiming)
            {
                TimeSpan elapsed = DateTime.Now - startTime;
                label1.Text = $"Время: {elapsed.TotalSeconds:F1}с";
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            pictureBox1?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
