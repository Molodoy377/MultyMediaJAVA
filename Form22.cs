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
        // Вопросы с вариантами (короткие формулировки для отображения)
        private readonly string[] questions =
        {
            " Классы Socket и ServerSocket используются для:\\nA) Работы с файлами\\nB) Сетевого программирования (клиент-сервер)\\nC) Многопоточности\\nD) GUI",
            " Модель делегирования событий в Java использует:\\nA) Классы событий (EventObject) и обработчики событий\\nB) Только интерфейсы\\nC) Только лямбда-выражения\\nD) Наследование классов",
            " Интерфейсы слушателей событий (ActionListener, MouseListener) — это:\\nA) Классы с реализацией\\nB) Абстрактные классы\\nC) Интерфейсы с методами обработки событий\\nD) Конструкторы",
            " Классы адаптеров (MouseAdapter) используются для:\\nA) Упрощения реализации интерфейсов с множеством методов\\nB) Создания потоков\\nC) Работы с файлами\\nD) Сетевого программирования",
            " Исключение в Java возбуждается ключевым словом:\\nA) catch\\nB) throw\\nC) try\\nD) finally",
            " Стандартные исключения Java наследуются от:\\nA) RuntimeException и Exception\\nB) Error и Throwable\\nC) IOException и SQLException\\nD) Все варианты",
            " Блок finally выполняется:\\nA) Только при возникновении исключения\\nB) Всегда, независимо от исключения\\nC) Только при успешном выполнении\\nD) Никогда",
            " Поток данных (Stream) в Java — это:\\nA) Последовательность байтов для чтения/записи\\nB) Массив объектов\\nC) Список файлов\\nD) Класс для GUI",
            " InputStream и его наследники (FileInputStream, BufferedInputStream):\\nA) Для чтения байтовых данных\\nB) Для записи данных\\nC) Для работы с символами\\nD) Для сетевых соединений",
            " OutputStream и декораторы (BufferedOutputStream):\\nA) Для записи байтовых данных\\nB) Для чтения символов\\nC) Для работы с файлами\\nD) Для GUI",
            " Reader/Writer отличаются от Stream тем, что работают с:\\nA) Байтами\\nB) Символами (Unicode)\\nC) Объектами\\nD) Примитивными типами",
            " Для чтения файла символами используется:\\nA) FileInputStream\\nB) FileReader\\nC) BufferedInputStream\\nD) ObjectInputStream",
            " RandomAccessFile позволяет:\\nA) Чтение/запись в произвольную позицию файла\\nB) Только последовательное чтение\\nC) Только запись\\nD) Работу только с текстом",
            " Класс File используется для:\\nA) Чтения/записи содержимого файла\\nB) Получения информации о файле/директории (путь, размер, права)\\nC) Сериализации объектов\\nD) Сетевого программирования",
            " Коллекции Java (Collection Framework) включают основные интерфейсы:\\nA) List, Set, Map, Queue\\nB) Array, Vector, Hashtable\\nC) String, StringBuilder\\nD) InputStream, OutputStream"
        };

        private readonly string[] correctAnswers = { "B", "A", "C", "A", "B", "D", "B", "A", "A", "A", "B", "B", "A", "B", "A" };
        private readonly List<GroupBox> questionGroups = new List<GroupBox>();
        public Form22()
        {
            InitializeComponent();
            CreateQuiz();
        }
        private void CreateQuiz()
        {
            // Подключаем обработчики к элементам из дизайнера
            button1.Click += ButtonCheck_Click;

            // Динамически создаём 15 вопросов
            for (int i = 0; i < questions.Length; i++)
            {
                GroupBox gb = CreateQuestionGroupBox(i, questions[i]);
                questionGroups.Add(gb);
                flowLayoutPanel1.Controls.Add(gb);  // flowPanel из дизайнера
            }
        }

        private GroupBox CreateQuestionGroupBox(int index, string questionText)
        {
            var gb = new GroupBox
            {
                Text = $"Вопрос {index + 1}" + questionText,
                Size = new Size(820, 200),   // ✅ МАКСИМАЛЬНО УВЕЛИЧИЛИ: 820x200
                Margin = new Padding(8)
            };

            // ✅ Радиокнопки ЕЩЁ БОЛЬШЕ и с БОЛЬШИМ отступом
            var rbA = new RadioButton
            {
                Text = "A",
                Tag = "A",
                Location = new Point(25, 110),     // ✅ Больше отступ сверху
                Size = new Size(380, 32),          // ✅ Шире и выше
                Font = new Font("Segoe UI", 10F)   // ✅ КРУПНЕЕ шрифт
            };
            var rbB = new RadioButton
            {
                Text = "B",
                Tag = "B",
                Location = new Point(420, 110),    // ✅ Больше отступ слева
                Size = new Size(380, 32),
                Font = new Font("Segoe UI", 10F)
            };
            var rbC = new RadioButton
            {
                Text = "C",
                Tag = "C",
                Location = new Point(25, 150),     // ✅ Вторая строка ниже
                Size = new Size(380, 32),
                Font = new Font("Segoe UI", 10F)
            };
            var rbD = new RadioButton
            {
                Text = "D",
                Tag = "D",
                Location = new Point(420, 150),
                Size = new Size(380, 32),
                Font = new Font("Segoe UI", 10F)
            };
            gb.Controls.AddRange(new Control[] { rbA, rbB, rbC, rbD });
            return gb;
        }
        private void ButtonCheck_Click(object sender, EventArgs e)
        {
            int correctCount = 0;

            // Проверяем каждый вопрос
            for (int i = 0; i < questionGroups.Count; i++)
            {
                GroupBox gb = questionGroups[i];
                string selectedAnswer = null;

                // Ищем выбранную радиокнопку
                foreach (Control control in gb.Controls)
                {
                    if (control is RadioButton radio && radio.Checked)
                    {
                        selectedAnswer = radio.Tag.ToString();
                        break;
                    }
                }

                // Сравниваем с правильным ответом
                if (selectedAnswer == correctAnswers[i])
                    correctCount++;
            }

            // Вычисляем процент
            double percentage = (double)correctCount / questions.Length * 100;
            label1.Text = $"Результат: {correctCount}/15 — {percentage:F1}%";

            MessageBox.Show($"Правильных ответов: {correctCount} из 15\nПроцент: {percentage:F1}%",
                           "Результат теста", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
