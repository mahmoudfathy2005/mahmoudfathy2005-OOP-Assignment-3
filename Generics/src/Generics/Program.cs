namespace Generics;

internal class Program
{
    private static void Main(string[] args)
    {
        Store<Student> studentStore = new();

        studentStore.Add(new Student(1, "Mahmoud"));
        studentStore.Add(new Student(2, "Ahmed"));
        studentStore.Add(new Student(3, "Ali"));
        studentStore.Add(new Student(4, "Omar"));
        studentStore.Add(new Student(5, "Youssef"));

        Store<Course> courseStore = new();

        courseStore.Add(new Course(1, "C# Basics", 1500m));
        courseStore.Add(new Course(2, "SQL", 1200m));
        courseStore.Add(new Course(3, "ASP.NET Core", 2000m));

        Console.WriteLine("Student by ID:");

        Student? student = studentStore.GetById(1);

        if (student is not null)
        {
            Console.WriteLine($"{student.Id} - {student.Name}");
        }

        Console.WriteLine();

        Console.WriteLine("Course by ID:");

        Course? course = courseStore.GetById(2);

        if (course is not null)
        {
            Console.WriteLine(
                $"{course.Id} - {course.Title} - {course.Price}");
        }

        Console.WriteLine();

        Console.WriteLine("Duplicate ID:");

        try
        {
            studentStore.Add(new Student(1, "Another Student"));
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();

        Console.WriteLine("Page 2 (size 2):");

        foreach (Student item in studentStore.GetAll().Values.Page(2, 2))
        {
            Console.WriteLine($"{item.Id} - {item.Name}");
        }

        Console.WriteLine();

        Console.WriteLine("Find course in a plain List:");

        List<Course> courses = new()
        {
            new Course(10, "OOP", 1000m),
            new Course(11, "Entity Framework Core", 1800m),
            new Course(12, "Web API", 1600m)
        };

        Course? foundCourse = courses.FindById(11);

        if (foundCourse is not null)
        {
            Console.WriteLine(
                $"{foundCourse.Id} - {foundCourse.Title}");
        }

        Console.WriteLine();

        Console.WriteLine("Convert courses to a dictionary:");

        IReadOnlyDictionary<int, Course> courseDictionary =
            courses.ToIdDictionary();

        Console.WriteLine(courseDictionary[12].Title);

        // Store<string> invalidStore = new(); // must NOT compile
    }
}
