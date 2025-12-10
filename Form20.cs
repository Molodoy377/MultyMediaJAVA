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
    public partial class Form20 : Form
    {
        // Вопросы с вариантами (короткие формулировки для отображения)
        private readonly string[] questions =
        {
            " Жизненный цикл Java-программы.\nA) Загрузка\nB) Инициализация\nC) Выполнение\nD) Завершение",
            " Базовые типы данных.\nA) byte, short, int, long\nB) float, double, boolean\nC) char\nD) Все перечисленные",
            " Понятие класса. Синтаксис, структура.\nA) Описывает поведение и состояние\nB) Только методы\nC) Только поля\nD) Интерфейс",
            " Особенности ссылочных переменных. Создание экземпляров класса.\nA) Хранят значение\nB) Хранят ссылку на объект\nC) Хранят адрес в файле\nD) Хранят только примитивы",
            " Конструктор класса. Конструкторы с параметрами.\nA) Метод с возвращаемым типом\nB) Специальный метод без типа\nC) Поле класса\nD) Статический блок",
            " Автоматическая упаковка и распаковка базовых типов.\nA) Преобразование int -> Integer\nB) Преобразование String -> char[]\nC) Преобразование Object -> примитив\nD) Нет такого механизма",
            " Область видимости и время жизни переменных и объектов.\nA) Локальные видимы в методе\nB) Поля видимы в классе\nC) Статические видимы во всем приложении\nD) Все варианты",
            " Абстрактный тип данных. Примеры АТД.\nA) int\nB) Stack\nC) String\nD) double",
            " Понятие абстракции.\nA) Сокрытие деталей реализации\nB) Наследование\nC) Инкапсуляция\nD) Полиморфизм",
            " Понятие инкапсуляции.\nA) Разделение на пакеты\nB) Сокрытие данных через модификаторы доступа\nC) Наследование\nD) Абстракция",
            " Понятие пакета. Механизм импортирования.\nA) use\nB) import\nC) include\nD) require",
            " Модификаторы доступа. Доступ в пределах пакета. Конфликты имен.\nA) public\nB) private\nC) protected\nD) package-private (default)",
            " Понятие композиции.\nA) is-a\nB) has-a\nC) implements\nD) extends",
            " Понятие наследования.\nA) has-a\nB) is-a\nC) uses-a\nD) contains-a",
            " Инициализация базового класса.\nA) Поля инициализируются до конструктора\nB) Конструктор выполняется раньше полей\nC) super() вызывается после конструктора\nD) Статические блоки не выполняются"
        };

        private readonly string[] correctAnswers = { "C", "B", "D", "B", "B", "A", "B", "B", "A", "B", "B", "D", "B", "B", "C" };
        private readonly List<GroupBox> questionGroups = new List<GroupBox>();

        public Form20()
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

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.FormClosed += (s, args) => this.Show();
            newForm.Show();
            this.Hide();
        }
        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackColor = Color.SkyBlue;
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.SkyBlue;
        }
    }
}
