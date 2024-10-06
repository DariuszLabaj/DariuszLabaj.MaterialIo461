// Ignore Spelling: Labaj Dariusz

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace DariuszLabaj.MaterialIo461.Converters
{
    public class ScaleConverter : MarkupExtension, IValueConverter
    {
        private readonly double _scale;
        public ScaleConverter(double scale)
        {
            _scale = scale;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return DependencyProperty.UnsetValue;
            if (double.TryParse(value.ToString(), out double inputValue))
            {
                return inputValue * _scale;
            }
            return DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return DependencyProperty.UnsetValue;
            if (double.TryParse(value.ToString(), out double inputValuie))
            {
                return inputValuie / _scale;
            }
            return DependencyProperty.UnsetValue;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
