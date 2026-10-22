
using System.Text.RegularExpressions;

public static class StringValidationExtensions
{
    public static bool IsValidEgyptianPhone(this string? phone)
    {
        return phone != null &&
               Regex.IsMatch(
                   phone,
                   @"^(?:01[0125]\d{8}|\+20(?:10|11|12|15)\d{8})$");
    }

    public static bool IsValidEgyptianNationalId(this string? nationalId)
    {
        return nationalId != null &&
               Regex.IsMatch(nationalId, @"^[23]\d{13}$");
    }
}
