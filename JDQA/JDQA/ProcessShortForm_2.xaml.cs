using JDQA.Classes;
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
    /// Interaction logic for ProcessShortForm_2.xaml
    /// </summary>
    public partial class ProcessShortForm_2 : Page
    {
        List<Phase1Selections> Selections;
        public ProcessShortForm_2(List<CheckBox> checkboxList, List<Phase1Selections> selections)
        {
            Selections = selections;
            InitializeComponent();
            addSelectedOptions(checkboxList);
        }

        private void addSelectedOptions(List<CheckBox> checkboxList) {

            for (int i = 0; i < checkboxList.Count(); i++) {
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
                else {
                    curRow = checkRow1;
                }

                Label label = new Label();
                label.Content = checkboxList[i].Name.Split('_')[1];
                curRow.Children.Add(label);
                curRow.Children.Add(checkboxList[i]);
                ShortFormGrid.RegisterName(checkboxList[i].Name, checkboxList[i]);

            }
        }

        private void goToNexStep(object sender, RoutedEventArgs e)
        {
            List<CheckBox> allCheckboxes = new List<CheckBox>();

            allCheckboxes = checkRow1.Children.OfType<CheckBox>().ToList();

            allCheckboxes = allCheckboxes.Concat(checkRow2.Children.OfType<CheckBox>().ToList()).ToList();
            allCheckboxes = allCheckboxes.Concat(checkRow3.Children.OfType<CheckBox>().ToList()).ToList();
            allCheckboxes = allCheckboxes.Concat(checkRow4.Children.OfType<CheckBox>().ToList()).ToList();
            allCheckboxes = allCheckboxes.Concat(checkRow5.Children.OfType<CheckBox>().ToList()).ToList();
            allCheckboxes = allCheckboxes.Concat(checkRow6.Children.OfType<CheckBox>().ToList()).ToList();

            List<CheckBox> selectedBoxes = new List<CheckBox>();
            foreach (CheckBox checkbox in allCheckboxes)
            {

                StackPanel parent = (StackPanel)checkbox.Parent;
                parent.UnregisterName(checkbox.Name);
                parent.Children.Remove(checkbox);
                if (checkbox.IsChecked.GetValueOrDefault())
                {
                    checkbox.IsChecked = false;
                    selectedBoxes.Add(checkbox);
                }
            }

            ProcessShortForm_3 proc3 = new ProcessShortForm_3(selectedBoxes, Selections);
            NavigationService.Navigate(proc3);
        }
    }
}
