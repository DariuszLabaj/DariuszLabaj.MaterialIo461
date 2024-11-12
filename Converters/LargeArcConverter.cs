// Ignore Spelling: Dariusz Labaj

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DariuszLabaj.MaterialIo461.Converters
{
    public class LargeArcConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 3 ||
                values[0] == null ||
                values[1] == null ||
                values[2] == null)
            {
                return false;
            }
            try
            {
                double value = System.Convert.ToDouble(values[0]);
                double minimum = System.Convert.ToDouble(values[1]);
                double maximum = System.Convert.ToDouble(values[2]);
                //double scaleX = System.Convert.ToDouble(values[3]);
                double normalizaedValue = (value - minimum) / (maximum - minimum);
                var val = normalizaedValue > 0.5;
                Debug.WriteLine(val);
                return val;
            }
            catch
            {
                return false;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
