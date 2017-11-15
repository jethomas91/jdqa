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
    /// Interaction logic for JDQASplash.xaml
    /// </summary>
    public partial class JDQASplash : Page
    {
        public JDQASplash()
        {
            InitializeComponent();
            enterButton.Focus();
        }

        private void enterApplication(object sender, RoutedEventArgs e)
        {
            PatternShapes patternshapes = new PatternShapes();

            NavigationService.Navigate(patternshapes);
        }

        private void enterPhase1(object sender, RoutedEventArgs e) {
            Phase_1 phase_1 = new Phase_1();

            NavigationService.Navigate(phase_1);
            
        }

        private void enterKeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Return) {
                PatternShapes patternshapes = new PatternShapes();

                NavigationService.Navigate(patternshapes);
            }
        }
    }
}
