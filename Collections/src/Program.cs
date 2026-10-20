using CollectionsApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var phoneTests = new (string? Input, bool Expected)[]
        {
            ("01012345678", true),
            ("+201512345678", true),
            ("01312345678", false),
            ("0101234567", false),
            ("0101234567a", false),
            (null, false),
            ("", false),
            ("   ", false)
        };

        Console.WriteLine("Egyptian Phone Validation:");
        Console.WriteLine();

        foreach (var test in phoneTests)
        {
            bool result = test.Input.IsValidEgyptianPhone();

            Console.WriteLine(
                $"Input: {test.Input ?? "null"} | " +
                $"Expected: {test.Expected} | " +
                $"Actual: {result} | " +
                $"Passed: {result == test.Expected}");
        }

        var nationalIdTests = new (string? Input, bool Expected)[]
        {
        ("29901011234567", true),
        ("19901011234567", false),
        ("2990101123456", false),
        (null, false),
        ("", false),
        ("   ", false)
        };

        Console.WriteLine();
        Console.WriteLine("Egyptian National ID Validation:");
        Console.WriteLine();

        foreach (var test in nationalIdTests)
        {
            bool result = test.Input.IsValidEgyptianNationalId();

            Console.WriteLine(
                $"Input: {test.Input ?? "null"} | " +
                $"Expected: {test.Expected} | " +
                $"Actual: {result} | " +
                $"Passed: {result == test.Expected}");
        }
    }


}
