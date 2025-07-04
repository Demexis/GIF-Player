using System.Globalization;
using System.Windows.Data;

namespace GifPlayer;

public sealed class StringToDoubleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value?.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (double.TryParse(value?.ToString(), out double result))
        {
            return result;
        }

        return 0.0; // ??? or DependencyProperty.UnsetValue; ???
    }
}