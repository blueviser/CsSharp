using System;
using System.Collections.Generic;
using System.Linq;

namespace GradesPrototype
{
    // Структура оценки (без изменений)
    struct Grade
    {
        public string Subject;
        public int Score;
        public DateTime Date;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Grade> grades = new List<Grade>()
            {
                new Grade { Subject = "Math", Score = 85, Date = new DateTime(2023, 10, 1) },
                new Grade { Subject = "Physics", Score = 92, Date = new DateTime(2023, 10, 2) },
                new Grade { Subject = "Chemistry", Score = 78, Date = new DateTime(2023, 10, 3) }
            };

            // Выводим все оценки
            Console.WriteLine("Все оценки:");
            PrintGrades(grades);

            // Удаляем оценку по математике 
            grades.RemoveAll(g => g.Subject == "Math");
            Console.WriteLine("\nОценки после удаления оценки по математике:");
            PrintGrades(grades);

            // Ищем оценки по физике 
            List<Grade> physicsGrades = grades.Where(g => g.Subject == "Physics").ToList();
            Console.WriteLine("\nОценки по физике:");
            PrintGrades(physicsGrades);
        }

        // Метод для вывода оценок 
        static void PrintGrades(List<Grade> grades)
        {
            foreach (var grade in grades)
            {
                Console.WriteLine($"Предмет: {grade.Subject}, Оценка: {grade.Score}, Дата: {grade.Date.ToShortDateString()}");
            }
        }
    }
}
