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

namespace JDQA
{
    /// <summary>
    /// Interaction logic for JDQAHome.xaml
    /// </summary>
    public partial class JDQAHome : Page
    {
        string radioButtonChecked;
        public JDQAHome()
        { 
            InitializeComponent();
            radioButtonChecked = "";
        }

        private void Enter_Pattern_Shape(object sender, RoutedEventArgs e) {
            PatternShapes patternShapeEntryPage = new PatternShapes();

            this.NavigationService.Navigate(patternShapeEntryPage);
        }

        private void setRadioButtonChecked(object sender, RoutedEventArgs e) {
            RadioButton heldPosition = sender as RadioButton;
            if (heldPosition == null) {
                return;
            }

            radioButtonChecked = heldPosition.Content.ToString();
        }

    }
}
