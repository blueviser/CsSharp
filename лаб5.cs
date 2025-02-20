using System;
using System.Collections.Generic;
using System.Linq;

// Перечисление предметов
public enum Subject
{
    Math,
    Physics,
    Chemistry
}

// Базовый класс для оценок
public class Grade
{
    public Subject Subject { get; set; }
    public int Score { get; set; }
    public DateTime Date { get; set; }

    public Grade(Subject subject, int score, DateTime date)
    {
        Subject = subject;
        Score = score;
        Date = date;
    }

    public override string ToString()
    {
        return $"Предмет: {Subject}, Оценка: {Score}, Дата: {Date.ToShortDateString()}";
    }
}

// Производный класс для оценок по математике
public class MathGrade : Grade
{
    public bool IsAdvanced { get; set; } // Дополнительное поле для оценок по математике

    public MathGrade(int score, DateTime date, bool isAdvanced) : base(Subject.Math, score, date)
    {
        IsAdvanced = isAdvanced;
    }

    public override string ToString()
    {
        return base.ToString() + $", Углубленный курс: {IsAdvanced}";
    }
}


public class Student
{
    public string Name { get; set; }
    public List<Grade> Grades { get; set; } = new List<Grade>();

    public Student(string name)
    {
        Name = name;
    }

    public void AddGrade(Grade grade)
    {
        Grades.Add(grade);
    }

    public void RemoveGrade(Grade grade)
    {
        Grades.Remove(grade);
    }

    public List<Grade> FindGradesBySubject(Subject subject)
    {
        return Grades.Where(g => g.Subject == subject).ToList();
    }

    public void PrintGrades()
    {
        if (Grades.Count == 0)
        {
            Console.WriteLine("У студента нет оценок.");
            return;
        }
        Console.WriteLine($"Оценки студента {Name}:");
        foreach (var grade in Grades)
        {
            Console.WriteLine(grade);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Student student = new Student("Иван Иванов");
        student.AddGrade(new Grade(Subject.Math, 90, new DateTime(2024, 3, 10)));
        student.AddGrade(new MathGrade(85, new DateTime(2024, 3, 15), true));
        student.AddGrade(new Grade(Subject.Physics, 95, new DateTime(2024, 3, 20)));

        student.PrintGrades();

        Console.WriteLine("\nОценки по математике:");
        foreach (var grade in student.FindGradesBySubject(Subject.Math))
        {
            Console.WriteLine(grade);
        }

        student.RemoveGrade(student.Grades.First(g => g.Subject == Subject.Math && g.Score == 90));

        Console.WriteLine("\nОценки после удаления:");
        student.PrintGrades();
    }
}
