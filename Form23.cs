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
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            textBox1.TextChanged += textBox1_TextChanged;  // Было textBoxInput_TextChanged
            textBox1.KeyDown += textBox1_KeyDown;
            GenerateNewText();
        }
        private void GenerateNewText()
        {
            // ✅ Полная очистка старого изображения
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            pictureBox1.BackColor = Color.Transparent;

            currentText = testTexts[rand.Next(testTexts.Length)];
            pictureBox1.Image = CreateTextImage(currentText);

            textBox1.Text = "";
            textBox1.Focus();
            label1.Text = "Время: 0с";
            isTiming = false;
            timer1.Stop();
            label2.Text = "Результат: --";
            label2.ForeColor = Color.Black;
            label2.Font = new Font(label2.Font.FontFamily, label2.Font.Size, FontStyle.Regular);
        }


        private Bitmap CreateTextImage(string text)
        {
            int width = 700;
            int height = 180;
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);

            // ✅ ВАЖНО: ВКЛЮЧАЕМ СГЛАЖИВАНИЕ для красивого текста
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Фон
            g.Clear(Color.White);

            // Градиентный фон
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0), new Point(width, height),
                Color.FromArgb(255, 248, 250), Color.FromArgb(230, 240, 255)))
            {
                g.FillRectangle(brush, 30, 20, width - 60, height - 40);
            }

            // Рамка
            using (Pen borderPen = new Pen(Color.FromArgb(100, 150, 200), 3))
            {
                g.DrawRectangle(borderPen, 28, 18, width - 56, height - 36);
            }

            // Текст с эффектами
            string displayText = text.ToUpper();
            Font font = new Font("Segoe UI Black", 26, FontStyle.Bold);
            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.None
            };

            // Тень текста (мягче)
            using (Brush shadowBrush = new SolidBrush(Color.FromArgb(80, 80, 80)))
            {
                g.DrawString(displayText, font, shadowBrush, new PointF(35, 25), sf);
            }

            // Основной текст (ярче)
            using (Brush textBrush = new SolidBrush(Color.FromArgb(30, 60, 120)))
            {
                g.DrawString(displayText, font, textBrush, new PointF(32, 22), sf);
            }

            // ✅ Освобождаем Graphics
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
            // Ctrl+Enter = Новая строка
            // Enter = Проверка (только если нет Shift/Ctrl/Alt)
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Control)  // Ctrl+Enter — новая строка
                {
                    // Ничего не делаем — TextBox сам добавит новую строку
                    e.Handled = false;
                    e.SuppressKeyPress = false;
                }
                else  // Просто Enter — проверка
                {
                    button2_Click(null, null);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                // Безопасное освобождение изображения
                if (pictureBox1?.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
            }
            catch { /* Игнорируем ошибки освобождения */ }

            base.OnFormClosing(e);
        }

    }
}
