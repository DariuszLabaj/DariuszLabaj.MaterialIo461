using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DariuszLabaj.MaterialIo461.Converters
{
    public class InvertNumericValue : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double numericValue)
            {
                return -numericValue;
            }
            else if (value is int intValue)
            {
                return -intValue;
            }
            else if (value is float floatValue)
            {
                return -floatValue;
            }
            else if (value is decimal decimalValue)
            {
                return -decimalValue;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
