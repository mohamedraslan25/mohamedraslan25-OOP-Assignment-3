
using System;
using System.Collections.Generic;
using src;

Store<Student> students = new Store<Student>();

students.Add(new Student(1, "Ahmed"));
students.Add(new Student(2, "Mohamed"));
students.Add(new Student(3, "Ali"));

Console.WriteLine("=== GetById ===");

Student? student = students.GetById(2);
Console.WriteLine(student != null
    ? $"Found: {student.Id} - {student.Name}"
    : "Student not found");

Student? missingStudent = students.GetById(99);
Console.WriteLine(missingStudent == null
    ? "Student not found"
    : missingStudent.Name);

Console.WriteLine();
Console.WriteLine("=== Duplicate ID Test ===");

try
{
    students.Add(new Student(1, "Another Ahmed"));
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine();
Console.WriteLine("=== Remove Test ===");

Console.WriteLine($"Removed student 2: {students.Remove(2)}");
Console.WriteLine($"Removed student 2 again: {students.Remove(2)}");

Console.WriteLine();
Console.WriteLine("=== GetAll ===");

IReadOnlyCollection<Student> allStudents = students.GetAll();

foreach (Student item in allStudents)
{
    Console.WriteLine($"{item.Id} - {item.Name}");
}

Console.WriteLine($"Students remaining: {allStudents.Count}");

Console.WriteLine();
Console.WriteLine("Course Store Test");

Store<Course> courses = new Store<Course>();

courses.Add(new Course(101, "C# Basics", 1500m));
courses.Add(new Course(102, "ASP.NET Core", 2500m));

Console.WriteLine(courses.GetById(101)?.Title);
