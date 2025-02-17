using System;
using System.Collections.Generic;

public enum Subject
{
    Math,
    Physics,
    Chemistry
}

public struct Grade
{
    public Subject Subject;
    public int Score;
    public DateTime Date;
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Grade> grades = new List<Grade>();

        grades.Add(new Grade { Subject = Subject.Math, Score = 90, Date = new DateTime(2024, 3, 10) });
        grades.Add(new Grade { Subject = Subject.Physics, Score = 85, Date = new DateTime(2024, 3, 15) });
        grades.Add(new Grade { Subject = Subject.Chemistry, Score = 95, Date = new DateTime(2024, 3, 20) });
        grades.Add(new Grade { Subject = Subject.Math, Score = 88, Date = new DateTime(2024, 3, 25) });


        Console.WriteLine("Все оценки:");
        PrintGrades(grades);

        Subject searchSubject = Subject.Math;
        List<Grade> mathGrades = FindGradesBySubject(grades, searchSubject);
        Console.WriteLine($"\nОценки по {searchSubject}:");
        PrintGrades(mathGrades);

        int indexToRemove = grades.FindIndex(g => g.Subject == Subject.Math && g.Date == new DateTime(2024, 3, 10));
        if (indexToRemove != -1)
        {
            grades.RemoveAt(indexToRemove);
            Console.WriteLine("\nОценка удалена.");
            Console.WriteLine("Оценки после удаления:");
            PrintGrades(grades);
        }
        else
        {
            Console.WriteLine("\nОценка для удаления не найдена.");
        }

    }

    static void PrintGrades(List<Grade> grades)
    {
        if (grades.Count == 0)
        {
            Console.WriteLine("Список оценок пуст.");
            return;
        }
        foreach (Grade grade in grades)
        {
            Console.WriteLine($"Предмет: {grade.Subject}, Оценка: {grade.Score}, Дата: {grade.Date.ToShortDateString()}");
        }
    }


    static List<Grade> FindGradesBySubject(List<Grade> grades, Subject subject)
    {
        List<Grade> result = new List<Grade>();
        foreach (Grade grade in grades)
        {
            if (grade.Subject == subject)
            {
                result.Add(grade);
            }
        }
        return result;
    }
}
