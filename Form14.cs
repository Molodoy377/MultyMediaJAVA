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
    }
}
