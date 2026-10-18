
Console.WriteLine("=== Egyptian Phone Validation ===");

TestPhone("01012345678", true);
TestPhone("+201512345678", true);
TestPhone("01312345678", false);
TestPhone("0101234567", false);
TestPhone("0101234567a", false);
TestPhone(null, false);
TestPhone("", false);
TestPhone("   ", false);

Console.WriteLine();
Console.WriteLine("=== Egyptian National ID Validation ===");

TestNationalId("29901011234567", true);
TestNationalId("19901011234567", false);
TestNationalId("2990101123456", false);
TestNationalId(null, false);
TestNationalId("", false);
TestNationalId("   ", false);

static void TestPhone(string? input, bool expected)
{
    bool actual = input.IsValidEgyptianPhone();

    Console.WriteLine(
        $"Input: {input ?? "null"}, Expected: {expected}, Actual: {actual}, {(actual == expected ? "PASS" : "FAIL")}");
}

static void TestNationalId(string? input, bool expected)
{
    bool actual = input.IsValidEgyptianNationalId();

    Console.WriteLine(
        $"Input: {input ?? "null"}, Expected: {expected}, Actual: {actual}, {(actual == expected ? "PASS" : "FAIL")}");
}
