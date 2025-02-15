using System;
using System.Collections.Generic;

namespace CourseManagement
{
    class Program
    {
        static Dictionary<string, (int capacity, List<string> students)> courses = new Dictionary<string, (int, List<string>)>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить курс");
                Console.WriteLine("2. Посмотреть курс");
                Console.WriteLine("3. Удалить курс");
                Console.WriteLine("4. Записать студента на курс");
                Console.WriteLine("5. Показать список студентов на курсе");
                Console.WriteLine("6. Удалить студента из курса");
                Console.WriteLine("7. Выход");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCourse();
                        break;
                    case "2":
                        ViewCourse();
                        break;
                    case "3":
                        DeleteCourse();
                        break;
                    case "4":
                        EnrollStudent();
                        break;
                    case "5":
                        ViewStudents();
                        break;
                    case "6":
                        RemoveStudent();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
        }

        static void AddCourse()
        {
            Console.Write("Введите название курса: ");
            string courseName = Console.ReadLine();
            Console.Write("Введите количество мест на курсе: ");
            int capacity = int.Parse(Console.ReadLine());

            if (courses.ContainsKey(courseName))
            {
                Console.WriteLine("Курс с таким названием уже существует.");
            }
            else
            {
                courses[courseName] = (capacity, new List<string>());
                Console.WriteLine("Курс добавлен.");
            }
        }

        static void ViewCourse()
        {
            Console.Write("Введите название курса: ");
            string courseName = Console.ReadLine();

            if (courses.ContainsKey(courseName))
            {
                var course = courses[courseName];
                Console.WriteLine($"Курс: {courseName}");
                Console.WriteLine($"Количество мест: {course.capacity}");
                Console.WriteLine($"Количество записанных студентов: {course.students.Count}");
            }
            else
            {
                Console.WriteLine("Курс не найден.");
            }
        }

        static void DeleteCourse()
        {
            Console.Write("Введите название курса: ");
            string courseName = Console.ReadLine();

            if (courses.ContainsKey(courseName))
            {
                courses.Remove(courseName);
                Console.WriteLine("Курс удален.");
            }
            else
            {
                Console.WriteLine("Курс не найден.");
            }
        }

        static void EnrollStudent()
        {
            Console.Write("Введите название курса: ");
            string courseName = Console.ReadLine();
            Console.Write("Введите имя студента: ");
            string studentName = Console.ReadLine();

            if (courses.ContainsKey(courseName))
            {
                var course = courses[courseName];
                if (course.students.Count < course.capacity)
                {
                    course.students.Add(studentName);
                    Console.WriteLine("Студент записан на курс.");
                }
                else
                {
                    Console.WriteLine("Нет свободных мест на курсе.");
                }
            }
            else
            {
                Console.WriteLine("Курс не найден.");
            }
        }

        static void ViewStudents()
        {
            Console.Write("Введите название курса: ");
            string courseName = Console.ReadLine();

            if (courses.ContainsKey(courseName))
            {
                var course = courses[courseName];
                Console.WriteLine($"Студенты на курсе {courseName}:");
                foreach (var student in course.students)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.WriteLine("Курс не найден.");
            }
        }

        static void RemoveStudent()
        {
            Console.Write("Введите название курса: ");
            string courseName = Console.ReadLine();
            Console.Write("Введите имя студента: ");
            string studentName = Console.ReadLine();

            if (courses.ContainsKey(courseName))
            {
                var course = courses[courseName];
                if (course.students.Contains(studentName))
                {
                    course.students.Remove(studentName);
                    Console.WriteLine("Студент удален из курса.");
                }
                else
                {
                    Console.WriteLine("Студент не найден на курсе.");
                }
            }
            else
            {
                Console.WriteLine("Курс не найден.");
            }
        }
    }
}
