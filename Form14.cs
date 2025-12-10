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
        private const string CorrectAnswer1 = "using System;\r\nusing System.Collections.Generic;\r\n\r\npublic class X\r\n{\r\n    private List<int> values = new List<int>();\r\n    \r\n    public void Add(int value)\r\n    {\r\n        values.Add(value);\r\n    }\r\n    \r\n    public bool Remove(int value)\r\n    {\r\n        return values.Remove(value);\r\n    }\r\n    \r\n    public int Count => values.Count;\r\n    \r\n    public int[] GetAll()\r\n    {\r\n        return values.ToArray();\r\n    }\r\n}\r\n";
        private const string CorrectAnswer2 = "public class SortedContainer : IX\r\n{\r\n    private List<int> values = new List<int>();\r\n    \r\n    public void Add(int value)\r\n    {\r\n        values.Add(value);\r\n        values.Sort();\r\n    }\r\n    \r\n    public bool Remove(int value) => values.Remove(value);\r\n    \r\n    public int Count => values.Count;\r\n    \r\n    public int[] GetAll() => values.ToArray();\r\n}\r\n public class UniqueContainer : IX\r\n{\r\n    private HashSet<int> values = new HashSet<int>();\r\n    \r\n    public void Add(int value)\r\n    {\r\n        values.Add(value);\r\n    }\r\n    \r\n    public bool Remove(int value) => values.Remove(value);\r\n    \r\n    public int Count => values.Count;\r\n    \r\n    public int[] GetAll() => values.ToArray();\r\n}\r\n public class StatisticsContainer : IX\r\n{\r\n    private List<int> values = new List<int>();\r\n    \r\n    public void Add(int value)\r\n    {\r\n        values.Add(value);\r\n    }\r\n    \r\n    public bool Remove(int value) => values.Remove(value);\r\n    \r\n    public int Count => values.Count;\r\n    \r\n    public int[] GetAll() => values.ToArray();\r\n}\r\n";
        private const string CorrectAnswer3 = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\n\r\npublic class Student\r\n{\r\n    public int Id { get; }\r\n    public string Name { get; }\r\n    public int Age { get; }\r\n\r\n    public Student(int id, string name, int age)\r\n    {\r\n        Id = id;\r\n        Name = name;\r\n        Age = age;\r\n    }\r\n\r\n    public override string ToString()\r\n    {\r\n        return $\"{Id}: {Name}, {Age} лет\";\r\n    }\r\n}\r\n\r\npublic class StudentGroup // Класс «X»\r\n{\r\n    // Выбор: List<Student> — динамический список с сохранением порядка\r\n    private readonly List<Student> students = new List<Student>();\r\n\r\n    public void AddStudent(Student student)\r\n    {\r\n        if (student == null)\r\n            throw new ArgumentNullException(nameof(student));\r\n\r\n        // Не добавляем студента с уже существующим Id\r\n        if (students.Any(s => s.Id == student.Id))\r\n            throw new InvalidOperationException($\"Студент с Id={student.Id} уже существует.\");\r\n\r\n        students.Add(student);\r\n    }\r\n\r\n    public bool RemoveStudentById(int id)\r\n    {\r\n        var student = students.FirstOrDefault(s => s.Id == id);\r\n        if (student == null)\r\n            return false;\r\n\r\n        students.Remove(student);\r\n        return true;\r\n    }\r\n\r\n    public Student FindByName(string name)\r\n    {\r\n        return students.FirstOrDefault(s => \r\n            s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));\r\n    }\r\n\r\n    public IReadOnlyList<Student> GetAll()\r\n    {\r\n        return students.AsReadOnly();\r\n    }\r\n\r\n    public int Count => students.Count;\r\n\r\n    public double GetAverageAge()\r\n    {\r\n        if (students.Count == 0)\r\n            return 0;\r\n        return students.Average(s => s.Age);\r\n    }\r\n}\r\n";
        private const string CorrectAnswer4 = "using System;\r\nusing System.Collections.Generic;\r\n\r\npublic class XContainer\r\n{\r\n    // Приватное поле — полная инкапсуляция коллекции\r\n    private readonly List<int> _data = new List<int>();\r\n\r\n    // Публичные свойства и методы — контролируемый доступ\r\n    public int Count => _data.Count;\r\n\r\n    public void Add(int value)\r\n    {\r\n        if (value < 0)\r\n            throw new ArgumentException(\"Значение должно быть неотрицательным.\");\r\n        _data.Add(value);\r\n    }\r\n\r\n    public bool Remove(int value)\r\n    {\r\n        return _data.Remove(value);\r\n    }\r\n\r\n    public bool Contains(int value)\r\n    {\r\n        return _data.Contains(value);\r\n    }\r\n\r\n    // Только чтение данных — защищает от модификации\r\n    public IReadOnlyList<int> GetData()\r\n    {\r\n        return _data.AsReadOnly();\r\n    }\r\n\r\n    public int GetMaxValue()\r\n    {\r\n        if (_data.Count == 0)\r\n            return 0;\r\n        return _data.Max();\r\n    }\r\n\r\n    public double GetAverage()\r\n    {\r\n        if (_data.Count == 0)\r\n            return 0;\r\n        return _data.Average();\r\n    }\r\n\r\n    // Полная очистка контейнера\r\n    public void Clear()\r\n    {\r\n        _data.Clear();\r\n    }\r\n}\r\n";
        private const string CorrectAnswer5 = "public interface ILibraryItem\r\n{\r\n    string Title { get; }\r\n    bool IsAvailable { get; }\r\n\r\n    string GetInfo();\r\n    void Borrow();   // взять\r\n    void Return();   // вернуть\r\n}\r\n public class Book : ILibraryItem\r\n{\r\n    public string Title { get; }\r\n    public string Author { get; }\r\n    public int Year { get; }\r\n    public bool IsAvailable { get; private set; }\r\n\r\n    public Book(string title, string author, int year)\r\n    {\r\n        Title = title;\r\n        Author = author;\r\n        Year = year;\r\n        IsAvailable = true;\r\n    }\r\n\r\n    public string GetInfo()\r\n    {\r\n        return $\"Книга: \\\"{Title}\\\", автор: {Author}, год: {Year}, доступна: {IsAvailable}\";\r\n    }\r\n\r\n    public void Borrow()\r\n    {\r\n        if (!IsAvailable)\r\n            throw new InvalidOperationException($\"Книга \\\"{Title}\\\" уже выдана.\");\r\n        IsAvailable = false;\r\n    }\r\n\r\n    public void Return()\r\n    {\r\n        IsAvailable = true;\r\n    }\r\n}\r\n public class Magazine : ILibraryItem\r\n{\r\n    public string Title { get; }\r\n    public int IssueNumber { get; }\r\n    public int Year { get; }\r\n    public bool IsAvailable { get; private set; }\r\n\r\n    public Magazine(string title, int issueNumber, int year)\r\n    {\r\n        Title = title;\r\n        IssueNumber = issueNumber;\r\n        Year = year;\r\n        IsAvailable = true;\r\n    }\r\n\r\n    public string GetInfo()\r\n    {\r\n        return $\"Журнал: \\\"{Title}\\\", выпуск №{IssueNumber}, {Year} г., доступен: {IsAvailable}\";\r\n    }\r\n\r\n    public void Borrow()\r\n    {\r\n        if (!IsAvailable)\r\n            throw new InvalidOperationException($\"Журнал \\\"{Title}\\\" уже выдан.\");\r\n        IsAvailable = false;\r\n    }\r\n\r\n    public void Return()\r\n    {\r\n        IsAvailable = true;\r\n    }\r\n}\r\n public class Newspaper : ILibraryItem\r\n{\r\n    public string Title { get; }\r\n    public DateTime Date { get; }\r\n    public bool IsAvailable { get; private set; }\r\n\r\n    public Newspaper(string title, DateTime date)\r\n    {\r\n        Title = title;\r\n        Date = date;\r\n        IsAvailable = true;\r\n    }\r\n\r\n    public string GetInfo()\r\n    {\r\n        return $\"Газета: \\\"{Title}\\\", дата: {Date:dd.MM.yyyy}, доступна: {IsAvailable}\";\r\n    }\r\n\r\n    public void Borrow()\r\n    {\r\n        if (!IsAvailable)\r\n            throw new InvalidOperationException($\"Газета \\\"{Title}\\\" уже выдана.\");\r\n        IsAvailable = false;\r\n    }\r\n\r\n    public void Return()\r\n    {\r\n        IsAvailable = true;\r\n    }\r\n}\r\n using System;\r\nusing System.Collections.Generic;\r\n\r\npublic class Program\r\n{\r\n    public static void Main()\r\n    {\r\n        List<ILibraryItem> items = new List<ILibraryItem>\r\n        {\r\n            new Book(\"Война и мир\", \"Л. Н. Толстой\", 1869),\r\n            new Magazine(\"Наука и жизнь\", 5, 2024),\r\n            new Newspaper(\"Известия\", new DateTime(2025, 12, 10))\r\n        };\r\n\r\n        Console.WriteLine(\"Все элементы библиотеки:\");\r\n        foreach (ILibraryItem item in items)\r\n        {\r\n            Console.WriteLine(item.GetInfo());   // Вызов GetInfo полиморфно\r\n        }\r\n\r\n        Console.WriteLine(\"\\nВыдаём первую и вторую позиции:\");\r\n        items[0].Borrow();   // Book.Borrow\r\n        items[1].Borrow();   // Magazine.Borrow\r\n\r\n        Console.WriteLine();\r\n        foreach (ILibraryItem item in items)\r\n        {\r\n            Console.WriteLine(item.GetInfo());   // Состояние IsAvailable изменилось по-разному\r\n        }\r\n\r\n        Console.WriteLine(\"\\nВозвращаем первую позицию:\");\r\n        items[0].Return();   // Book.Return\r\n\r\n        Console.WriteLine();\r\n        foreach (ILibraryItem item in items)\r\n        {\r\n            Console.WriteLine(item.GetInfo());\r\n        }\r\n    }\r\n}\r\n";
        public Form14()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // При старте очищаем TextBox
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = CorrectAnswer1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = CorrectAnswer2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox6.Text = CorrectAnswer3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox8.Text = CorrectAnswer4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox10.Text = CorrectAnswer5;
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
    }
}
