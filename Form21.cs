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
    public partial class Form21 : Form
    {
        // Вопросы с вариантами (короткие формулировки для отображения)
        private readonly string[] questions =
        {
            " Перегрузка методов — это:\nA) Изменение сигнатуры метода в подклассе\nB) Несколько методов с одним именем, но разными параметрами в одном классе\nC) Изменение возвращаемого типа для одного метода\nD) Удаление метода из класса",
            " Восходящее (upcasting) преобразование типов — это:\nA) Преобразование подкласса к типу суперкласса\nB) Преобразование суперкласса к типу подкласса\nC) Преобразование примитива в объект\nD) Явное приведение к интерфейсу",
            " Что верно для final-полей, final-методов и final-классов?\nA) final-поля нельзя изменить после инициализации; final-метод нельзя переопределить; final-класс нельзя наследовать\nB) final-поля могут изменяться; final-метод можно переопределять\nC) final-класс можно наследовать\nD) final-применим только к методам",
            " Инициализация статических данных происходит:\nA) При создании каждого экземпляра класса\nB) Один раз при загрузке класса в JVM (перед первым использованием)\nC) Только при вызове конструктора\nD) При сборке мусора",
            " Явная инициализация и инициализация с наследованием — что выполняется первым?\nA) Конструктор подкласса, затем конструктора суперкласса\nB) Инициализация полей суперкласса, затем полей подкласса, затем конструкторы (super() сначала)\nC) Статические поля подкласса, затем статические поля суперкласса\nD) Только статические блоки",
            " Полиморфизм в Java — это:\nA) Способ иметь несколько конструкторов\nB) Способ, когда один интерфейс используется для разных типов объектов (динамический выбор реализации)\nC) Способ скрыть поля класса\nD) Механизм пакетирования классов",
            " Порядок вызова конструкторов при создании подкласса:\nA) Сначала конструктор подкласса, затем суперкласса\nB) Сначала конструктор суперкласса (через super()), затем конструктора подкласса\nC) Только конструктор подкласса вызывается\nD) Конструкторы вызываются в случайном порядке",
            " Ковариантность возвращаемых типов означает:\nA) При переопределении метода возвращаемый тип может быть подклассом исходного возвращаемого типа\nB) При перегрузке метод может менять возвращаемый тип\nC) Возвращаемый тип всегда должен быть примитивом\nD) Java не поддерживает ковариантность",
            " Абстрактный класс отличается от интерфейса тем, что:\nA) Абстрактный класс может содержать реализацию методов и поля, интерфейс до Java 8 — только абстрактные методы\nB) Интерфейс может иметь состояния (поля экземпляра)\nC) Абстрактный класс нельзя наследовать\nD) Интерфейс может иметь конструкторы",
            " Интерфейс в Java используется для:\nA) Определения контракта (набор методов) без конкретной реализации (до Java 8)\nB) Содержания только полей и конструкторов\nC) Наследования реализации метода\nD) Замены класса Object",
            " Множественное наследование классов в Java:\nA) Поддерживается напрямую через extends несколько классов\nB) Не поддерживается для классов; достигается через интерфейсы\nC) Поддерживается только для final-классов\nD) Требует специального ключевого слова multiple",
            " Понятие потока исполнения (thread) — это:\nA) Объект, представляющий последовательность выполнения кода (параллельная/конкурентная)\nB) Только файл с кодом\nC) Тип данных для хранения чисел\nD) Способ сериализации объектов",
            " Класс Thread и интерфейс Runnable — как создавать поток:\nA) Реализовать Runnable и передать в Thread, или унаследовать Thread и переопределить run()\nB) Только наследовать Thread можно создавать поток\nC) Только реализовать Runnable можно создавать поток\nD) Использовать synchronized для создания потока",
            " Синхронизация потоков в Java обеспечивает:\nA) Одновременное выполнение нескольких потоков без блокировок\nB) Координацию доступа к общим ресурсам, предотвращая состояния гонки (synchronized)\nC) Ускорение выполнения потоков в любой ситуации\nD) Автоматическое масштабирование потоков",
            " Понятие сокета и класс InetAddress — это:\nA) Сокет — абстракция сетевого соединения; InetAddress хранит IP-адреса и методы для разрешения имен\nB) Сокет — класс для работы с файлами; InetAddress — класс для GUI\nC) Сокеты используются только в локальной памяти\nD) InetAddress — это протокол передачи данных"
        };

        private readonly string[] correctAnswers = { "B", "A", "A", "B", "B", "B", "B", "A", "A", "A", "B", "A", "A", "B", "A" };
        private readonly List<GroupBox> questionGroups = new List<GroupBox>();
        public Form21()
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
