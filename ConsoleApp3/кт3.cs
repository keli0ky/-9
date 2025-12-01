using System;

// Задание 1: Класс Student
public class Student
{
    // Поля с разными модификаторами
    public string Name;                   // Public - имя должно быть доступно всем

    private int _age;                     // Private - возраст скрыт, изменяется только через метод
    protected string _faculty;            // Protected - доступен наследникам

    internal int StudentId;               // Internal - доступен только в этой сборке
    private protected string _group;      // Private protected - только в этой сборке и наследникам

    // Public конструктор - для создания объектов извне
    public Student(string name, int age)
    {
        Name = name;
        SetAge(age);  // Используем private метод
        _faculty = "Не определён";
        _group = "Без группы";
    }

    // Public метод - основной API для пользователей класса
    public void PrintInfo()
    {
        Console.WriteLine($"Студент: {Name}, Факультет: {_faculty}");
        Console.WriteLine($"Возраст: {_age}, Группа: {_group}");
    }

    // Private метод - только для внутреннего использования
    private void SetAge(int age)
    {
        if (age >= 16 && age <= 60)
            _age = age;
        else
            _age = 18;
    }

    // Protected метод - для использования в наследниках
    protected void SetFaculty(string faculty)
    {
        if (!string.IsNullOrEmpty(faculty))
            _faculty = faculty;
    }

    // Internal метод - для использования внутри сборки
    internal void ChangeId(int newId)
    {
        if (newId > 0)
            StudentId = newId;
    }

    // Private protected метод - для наследников в этой сборке
    private protected void SetGroup(string group)
    {
        _group = group;
    }
}

// Задание 2: Производный класс AdvancedStudent 
public class AdvancedStudent : Student
{
    // Public конструктор
    public AdvancedStudent(string name, int age) : base(name, age)
    {
        // Используем protected поле родителя
        _faculty = "Продвинутый факультет";

        // Используем private protected метод (доступен, т.к. в той же сборке)
        SetGroup("Продвинутая группа");

        // Private поле родителя недоступно: _age = 20; // Ошибка!
        // Private метод родителя недоступен: SetAge(20); // Ошибка!
    }

    // Public метод AdvancedStudent
    public void PrintAdvancedInfo()
    {
        Console.WriteLine($"Продвинутый студент: {Name}");
        Console.WriteLine($"Факультет: {_faculty}"); // Protected поле доступно

        // Используем protected метод родителя
        SetFaculty("Изменённый факультет");
    }
}

//  Задание 3: Класс StudentManager в той же сборке
internal class StudentManager
{
    private Student _student;

    public StudentManager(Student student)
    {
        _student = student;
    }

    // Используем internal метод Student
    public void UpdateStudentId(int id)
    {
        _student.ChangeId(id);
        Console.WriteLine($"ID студента {_student.Name} изменён на {_student.StudentId}");
    }
}

//  Задание 4: Тестовая программа 
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Тестирование базового класса Student ===");
        Student student = new Student("Иван", 20);

        // Public методы доступны
        student.PrintInfo();
        student.Name = "Пётр"; // Public поле доступно

        // Internal метод доступен (в той же сборке)
        student.ChangeId(12345);

        // Private методы недоступны
        // student.SetAge(25); // Ошибка!
        // int age = student._age; // Ошибка!

        // Protected методы недоступны
        // student.SetFaculty("Новый"); // Ошибка!

        Console.WriteLine("\n=== Тестирование AdvancedStudent ===");
        AdvancedStudent advStudent = new AdvancedStudent("Анна", 22);
        advStudent.PrintInfo();
        advStudent.PrintAdvancedInfo();

        Console.WriteLine("\n=== Тестирование StudentManager ===");
        StudentManager manager = new StudentManager(student);
        manager.UpdateStudentId(99999);

        // Internal класс доступен в той же сборке
        Console.WriteLine($"Менеджер работает со студентом: {student.Name}");

        // Попытка доступа к private/protected извне
        TestAccessRestrictions();
    }

    static void TestAccessRestrictions()
    {
        Console.WriteLine("\n=== Демонстрация ограничений доступа ===");

        Student student = new Student("Тестовый", 25);

        // Работает:
        Console.WriteLine($"Имя: {student.Name}");
        student.PrintInfo();

    }
}