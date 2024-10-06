// Ignore Spelling: Labaj Dariusz

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DariuszLabaj.MaterialIo461.CustomUserControl
{
    /// <summary>
    /// Interaction logic for SearchBox.xaml
    /// </summary>
    public partial class SearchBox : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(SearchBox), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty SearchPromptProperty = DependencyProperty.Register("SearchPrompt", typeof(string), typeof(SearchBox), new PropertyMetadata("Search"));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string SearchPrompt
        {
            get { return (string)GetValue(SearchPromptProperty); }
            set { SetValue(SearchPromptProperty, value); }
        }
        public SearchBox()
        {
            InitializeComponent();
        }
    }
}
