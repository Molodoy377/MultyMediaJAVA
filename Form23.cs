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
        "public class Calculator {\r\n    public int add(int a, int b) {\r\n        return a + b;\r\n    }\r\n    \r\n    public double add(double a, double b) {\r\n        return a + b;\r\n    }\r\n    \r\n    public int add(int a, int b, int c) {\r\n        return a + b + c;\r\n    }\r\n    \r\n    public static void main(String[] args) {\r\n        Calculator calc = new Calculator();\r\n        System.out.println(calc.add(2, 3));        // 5\r\n        System.out.println(calc.add(2.5, 3.7));    // 6.2\r\n        System.out.println(calc.add(1, 2, 3));     // 6\r\n    }\r\n}\r\n",
        "interface Animal {\r\n    void makeSound();\r\n}\r\n\r\nclass Dog implements Animal {\r\n    public void makeSound() {\r\n        System.out.println(\"Гав-гав!\");\r\n    }\r\n}\r\n\r\nclass Cat implements Animal {\r\n    public void makeSound() {\r\n        System.out.println(\"Мяу-мяу!\");\r\n    }\r\n}\r\n\r\npublic class Main {\r\n    public static void main(String[] args) {\r\n        Animal[] animals = {new Dog(), new Cat()};\r\n        for (Animal animal : animals) {\r\n            animal.makeSound();  // Полиморфное поведение\r\n        }\r\n    }\r\n}\r\n",
        "public class Person {\r\n    private String name;\r\n    private int age;\r\n    \r\n    // Геттеры и сеттеры\r\n    public String getName() { return name; }\r\n    public void setName(String name) { \r\n        if (name != null && !name.trim().isEmpty())\r\n            this.name = name; \r\n    }\r\n    \r\n    public int getAge() { return age; }\r\n    public void setAge(int age) {\r\n        if (age > 0 && age < 150)\r\n            this.age = age;\r\n    }\r\n}\r\n\r\nclass Main {\r\n    public static void main(String[] args) {\r\n        Person person = new Person();\r\n        person.setName(\"Иван\");\r\n        person.setAge(25);\r\n        System.out.println(person.getName() + \", \" + person.getAge());\r\n    }\r\n}\r\n",
        "class Vehicle {\r\n    protected String brand;\r\n    \r\n    public Vehicle(String brand) {\r\n        this.brand = brand;\r\n    }\r\n    \r\n    public void start() {\r\n        System.out.println(brand + \" заводится...\");\r\n    }\r\n}\r\n\r\nclass Car extends Vehicle {\r\n    private int doors;\r\n    \r\n    public Car(String brand, int doors) {\r\n        super(brand);  // Вызов конструктора родителя\r\n        this.doors = doors;\r\n    }\r\n    \r\n    @Override\r\n    public void start() {\r\n        super.start();  // Вызов метода родителя\r\n        System.out.println(\"Автомобиль с \" + doors + \" дверями готов!\");\r\n    }\r\n}\r\n\r\npublic class Main {\r\n    public static void main(String[] args) {\r\n        Car car = new Car(\"Toyota\", 4);\r\n        car.start();\r\n    }\r\n}\r\n",
        "public class ExceptionExample {\r\n    public static int divide(int a, int b) throws ArithmeticException {\r\n        if (b == 0) {\r\n            throw new ArithmeticException(\"Деление на ноль!\");\r\n        }\r\n        return a / b;\r\n    }\r\n    \r\n    public static void main(String[] args) {\r\n        try {\r\n            int result = divide(10, 0);\r\n        } catch (ArithmeticException e) {\r\n            System.out.println(\"Ошибка: \" + e.getMessage());\r\n        } finally {\r\n            System.out.println(\"Блок finally выполнен\");\r\n        }\r\n    }\r\n}\r\n",
        "public class HelloWorld { public static void main(String[] args) { System.out.println(Hello, World!);} }"
        };
        public Form23()
        {
            InitializeComponent();

            // Устанавливаем размер PictureBox
            pictureBox1.Size = new Size(700, 500);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BackColor = Color.White;

            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;

            GenerateNewText();
        }
        private void GenerateNewText()
        {
            // ✅ Полная очистка старого изображения
            if (pictureBox1.Image != null)
            {
                var oldImage = pictureBox1.Image;
                pictureBox1.Image = null;
                oldImage.Dispose();
            }

            currentText = testTexts[rand.Next(testTexts.Length)];

            // Создаем изображение с автоматическим подбором размера текста
            pictureBox1.Image = CreateTextImage(currentText);

            textBox1.Text = "";
            textBox1.Focus();
            label1.Text = "";
            isTiming = false;
            timer1.Stop();
            label2.Text = "Результат: --";
            label2.ForeColor = Color.Black;
            label2.Font = new Font(label2.Font.FontFamily, label2.Font.Size, FontStyle.Regular);
        }

        private Bitmap CreateTextImage(string text)
        {
            int width = pictureBox1.Width > 0 ? pictureBox1.Width : 700;
            int height = pictureBox1.Height > 0 ? pictureBox1.Height : 500;

            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);

            try
            {
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

                // Подбираем размер шрифта, чтобы текст вместился
                string displayText = text.ToUpper();
                RectangleF textRect = new RectangleF(30, 20, width - 60, height - 40);

                // Начинаем с большого шрифта и уменьшаем, пока текст не поместится
                float fontSize = 26;
                bool textFits = false;

                while (!textFits && fontSize > 6)
                {
                    using (Font testFont = new Font("Segoe UI", fontSize, FontStyle.Bold))
                    using (StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Near,
                        Trimming = StringTrimming.None,
                        FormatFlags = StringFormatFlags.NoWrap
                    })
                    {
                        SizeF textSize = g.MeasureString(displayText, testFont, (int)textRect.Width, sf);

                        // Проверяем, помещается ли текст
                        if (textSize.Height <= textRect.Height)
                        {
                            textFits = true;
                            break;
                        }
                    }
                    fontSize -= 0.5f; // Уменьшаем размер шрифта
                }

                // Если текст все еще не помещается, включаем обрезку и перенос по словам
                if (!textFits)
                {
                    fontSize = 26;
                    using (Font testFont = new Font("Segoe UI", fontSize, FontStyle.Bold))
                    using (StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Near,
                        Trimming = StringTrimming.EllipsisWord,
                        FormatFlags = StringFormatFlags.LineLimit
                    })
                    {
                        // Еще раз измеряем с учетом переноса
                        SizeF textSize = g.MeasureString(displayText, testFont, (int)textRect.Width, sf);

                        // Подгоняем размер шрифта, если нужно
                        while (textSize.Height > textRect.Height && fontSize > 8)
                        {
                            fontSize -= 0.5f;
                            using (Font smallerFont = new Font("Segoe UI", fontSize, FontStyle.Bold))
                            {
                                textSize = g.MeasureString(displayText, smallerFont, (int)textRect.Width, sf);
                            }
                        }
                    }
                }

                // Отрисовываем текст с подобранным размером - БЕЗ ТЕНИ
                using (Font finalFont = new Font("Segoe UI", fontSize, FontStyle.Bold))
                using (StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Near,
                    Trimming = StringTrimming.EllipsisWord,
                    FormatFlags = StringFormatFlags.LineLimit
                })
                using (Brush textBrush = new SolidBrush(Color.FromArgb(30, 60, 120)))
                {
                    // Только основной текст, без тени
                    g.DrawString(displayText, finalFont, textBrush, textRect, sf);
                }
            }
            finally
            {
                g.Dispose();
            }

            return bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            isTiming = false;

            string userText = textBox1.Text.Trim();
            string currentTextNormalized = currentText.Trim();

            // Сравниваем с нормализованными строками
            bool isCorrect = string.Equals(userText, currentTextNormalized, StringComparison.OrdinalIgnoreCase);

            TimeSpan elapsed = DateTime.Now - startTime;

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
                // Показываем только начало текста для экономии места
                string shortText = currentTextNormalized.Length > 50
                    ? currentTextNormalized.Substring(0, 50) + "..."
                    : currentTextNormalized;

                label2.Text = $"✗ ОШИБКА! Проверьте текст";
                label2.ForeColor = Color.Red;

                // Для отладки можно показать разницу
                MessageBox.Show($"Введенный текст:\n{userText}\n\nОжидаемый текст:\n{currentTextNormalized}",
                    "Сравнение текста", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.FormClosed += (s, args) => this.Show();
            newForm.Show();
            this.Hide();
        }
        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.SkyBlue;
        }
    }
}