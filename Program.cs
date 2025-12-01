using System;

namespace КТ3

{
    
    class Book
    {
        public string Title;
        private int _pages;

        public int Pages
        {
            get { return _pages; }
            set
            {
                if (value >= 1) _pages = value;
                else _pages = 1;
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Книга: {Title}, страниц: {Pages}");
        }
    }

    
    class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public double Area()
        {
            return Width * Height;
        }
    }

    
    class Student
    {
        public string Name;
        private int _grade;

        public int Grade
        {
            get { return _grade; }
            set
            {
                if (value >= 1 && value <= 5) _grade = value;
            }
        }

        public void Print()
        {
            Console.WriteLine($"Студент: {Name}, оценка: {Grade}");
        }
    }

  
    class Program
    {
      
        static void ChangeBookTitle(Book b)
        {
            b.Title = "Новое название";
        }
 
        static void Main(string[] args)
        {
          

            
            Console.WriteLine("1. Класс Book:");
            Book book = new Book();
            book.Title = "Преступление и наказание";
            book.Pages = 500;
            book.PrintInfo();

            
            Console.WriteLine("2. Передача объектов:");
            Book testBook = new Book();
            testBook.Title = "Старое";
            Console.WriteLine($"До: {testBook.Title}");
            ChangeBookTitle(testBook);
            Console.WriteLine($"После: {testBook.Title}");

            
            Console.WriteLine("3. Класс Rectangle:");
            Rectangle rect = new Rectangle();
            rect.Width = 5;
            rect.Height = 10;
            Console.WriteLine($"Площадь: {rect.Area()}");

            
            Console.WriteLine("4. Класс Student:");
            Student student = new Student();
            student.Name = "Леша";
            student.Grade = 5;
            student.Print();

           
            Console.WriteLine("5. Дополнительный класс Phone:");
            Phone phone = new Phone();
            phone.Brand = "Samsung";
            phone.Battery = 85;
            phone.ShowInfo();

          
            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }

    
    class Phone
    {
        public string Brand;
        private int _battery;

        public int Battery
        {
            get { return _battery; }
            set
            {
                if (value >= 0 && value <= 100) _battery = value;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Телефон: {Brand}, заряд: {Battery}%");
        }
    }
}