// Ignore Spelling: Dariusz Labaj

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DariuszLabaj.MaterialIo461.Converters
{
    public class SizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double actualWidth)
            {
                var strokeThickness = actualWidth * 0.1;
                var pathWidth = actualWidth - strokeThickness;
                return new Size(pathWidth / 2, pathWidth / 2);
            }
            return new Size(0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
