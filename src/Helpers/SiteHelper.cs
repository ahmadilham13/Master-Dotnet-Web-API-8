using System.Drawing;
using System.Reflection;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using NetTopologySuite.IO;
using Coc.Configs;
using Coc.Enums;
using Coc.Constants;

namespace Coc.Helpers;

public static class SiteHelper
{
    public static readonly Guid SuperAdminRoleId = new("9648fc11-a4bf-40bb-84a2-2925ebaa630d");

    public static int ValidatePageSize(int pageSize)
    {
        List<int> validPageSizes = new List<int>() { 5, 10, 25, 50, 100, 200 };
        return validPageSizes.Contains(pageSize) ? pageSize : SiteConstant.DefaultPageSize;
    }

    public static string RandomString(int length)
    {
        Random random = new();

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static string RandomNumber(int length)
    {
        Random random = new();

        const string chars = "0123456789";
        return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static string RandomColorFromUuid(Guid id)
    {
        Color color = Color.FromArgb(id.GetHashCode());
        return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
    }

    public static string GetCurrentMethodName([CallerMemberName] string name = "")
    {
        return name;
    }

    /// <summary>
    /// Parses a comma-separated string of GUIDs into a list of valid GUIDs.
    /// </summary>
    /// <param name="commaSeparatedGuids">A string containing GUIDs separated by commas.</param>
    /// <returns>A list of valid GUIDs parsed from the input string.</returns>
    public static List<Guid> ParseGuids(string commaSeparatedGuids)
    {
        if (string.IsNullOrEmpty(commaSeparatedGuids))
        {
            return [];
        }

        // Split the input string by commas to get individual GUID strings
        // Then attempt to parse each GUID string; if parsing fails, use Guid.Empty
        // After that filter out any invalid GUIDs (Guid.Empty)
        // Finally convert the filtered GUIDs into a list
        return commaSeparatedGuids
            .Split(',')
            .Select(guidString => Guid.TryParse(guidString, out var guid) ? guid : Guid.Empty)
            .Where(guid => guid != Guid.Empty)
            .ToList();
    }

    public static string MaskEmail(string email)
    {
        int atIndex = email.IndexOf('@');

        string masked = new('*', atIndex - 1);

        return email[0] + masked + email[atIndex..];
    }

    public static string MaskString(string raw)
    {
        return raw[0] + new string('*', raw.Length - 1);
    }

    public static string TrimDecimal(decimal value)
    {
        return value % 1 == 0 ? value.ToString("0") : value.ToString("0.00");
    }

    public static string Capitalize(string sentence)
    {
        return sentence[0].ToString().ToUpper() + sentence[1..];
    }

    public static string ConvertToTitle(string propertyName)
    {
        if (string.IsNullOrEmpty(propertyName))
        {
            return propertyName;
        }

        // Define known abbreviations and initialisms
        var knownAbbreviations = new HashSet<string>
        {
            "ODF", "WL", "ES", "SEA-US" // Add more as needed
        };

        // Split the property name into words
        var words = Regex.Split(propertyName, @"(?<!^)(?=[A-Z])");

        // Join the words, checking for abbreviations
        for (int i = 0; i < words.Length; i++)
        {
            if (knownAbbreviations.Contains(words[i]))
            {
                // Merge back the abbreviation if it was split
                words[i] = string.Join("", words[i].ToCharArray());
            }
        }

        return string.Join(" ", words);
    }

    public static int GetWeekNumberOfMonth()
    {
        DateTime date = DateTime.UtcNow.Date;
        DateTime firstMonthDay = new(date.Year, date.Month, 1);
        DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);

        if (firstMonthMonday > date)
        {
            firstMonthDay = firstMonthDay.AddMonths(-1);
            firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
        }

        return (date - firstMonthMonday).Days / 7 + 1;
    }

    public static int ExtractBearerSerialNumber(string input)
    {
        string pattern = @"_(\d+)$";
        Match match = Regex.Match(input, pattern);
        if (match.Success)
        {
            return int.Parse(match.Groups[1].Value);
        }
        else
        {
            return 0;
        }
    }

    public static bool CheckIsValidIPAddress(string input)
    {
        IPAddress address;
        if (IPAddress.TryParse(input, out address))
        {
            if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                string ipAddress = address.ToString();
                return ipAddress == input;
            }
            else {
                return false;
            }
        }
        return false;
    }

    public static string GenerateSlug(string phrase)
    {
        string str = phrase.ToLower();
        str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // Remove invalid chars
        str = Regex.Replace(str, @"\s+", " ").Trim();  // Convert multiple spaces into one space
        str = Regex.Replace(str, @"\s", "-");          // Replace spaces with hyphens
        return str;
    }
}