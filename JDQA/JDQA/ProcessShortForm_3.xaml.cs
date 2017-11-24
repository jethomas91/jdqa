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
    /// Interaction logic for ProcessShortForm_3.xaml
    /// </summary>
    public partial class ProcessShortForm_3 : Page
    {
        public ProcessShortForm_3(List<CheckBox> checkboxList)
        {
            InitializeComponent();
            addSelectedOptions(checkboxList);
        }

        private void addSelectedOptions(List<CheckBox> checkboxList)
        {

            for (int i = 0; i < checkboxList.Count(); i++)
            {
                StackPanel curRow;
                if (i > 50)
                {
                    curRow = checkRow6;
                }
                else if (i > 40)
                {
                    curRow = checkRow5;
                }
                else if (i > 30)
                {
                    curRow = checkRow4;
                }
                else if (i > 20)
                {
                    curRow = checkRow3;
                }
                else if (i > 10)
                {
                    curRow = checkRow2;
                }
                else
                {
                    curRow = checkRow1;
                }

                Label label = new Label();
                label.Content = checkboxList[i].Name.Split('_')[1];
                curRow.Children.Add(label);
                curRow.Children.Add(checkboxList[i]);
                ShortFormGrid.RegisterName(checkboxList[i].Name, checkboxList[i]);

            }
        }

        private void processFormResults(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Calculating..");
        }
    }
}
