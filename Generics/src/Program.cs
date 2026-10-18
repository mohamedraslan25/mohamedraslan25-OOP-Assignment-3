
using src;

StudentStore store = new StudentStore();

store.Add(new Student(1, "Ahmed"));
store.Add(new Student(2, "Mohamed"));
store.Add(new Student(3, "Ali"));

Student? student = store.GetById(2);

if (student != null)
{
    Console.WriteLine($"Found: {student.Id} - {student.Name}");
}

Student? missingStudent = store.GetById(99);
Console.WriteLine(missingStudent == null ? "Student not found" : missingStudent.Name);

Console.WriteLine("All students:");

foreach (Student item in store.GetAll())
{
    Console.WriteLine($"{item.Id} - {item.Name}");
}

bool removed = store.Remove(2);
Console.WriteLine($"Removed student 2: {removed}");

Console.WriteLine($"Students remaining: {store.GetAll().Count}");
