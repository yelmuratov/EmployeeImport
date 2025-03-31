using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

public class CustomDateTimeConverter : DateTimeConverter
{
    private readonly string[] formats = new[] { "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "yyyy-MM-dd" };

    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (DateTime.TryParseExact(text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
        {
            return result;
        }

        return base.ConvertFromString(text, row, memberMapData);
    }
}
