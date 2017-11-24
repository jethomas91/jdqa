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
    /// Interaction logic for ProcessShortForm.xaml
    /// </summary>
    public partial class ProcessShortForm : Page
    {
        public ProcessShortForm()
        {
            InitializeComponent();
            populateGrid();
        }


        private void populateGrid() {
            for (int i = 1; i < 11; i++) {
                CheckBox checkbox = new CheckBox();
                Label label = new Label();
                checkbox.Name = "checkBox_" + i;
                checkbox.Margin = new Thickness(0, 5, 0, 0);
                label.Name = "checkboxLabel_" + i;
                label.Content = "Checkbox Label " + i;
                label.Content = i;
                checkRow1.Children.Add(label);
                checkRow1.Children.Add(checkbox);
                ShortFormGrid.RegisterName(checkbox.Name, checkbox);
            }

            for (int i = 11; i < 21; i++)
            {
                CheckBox checkbox = new CheckBox();
                Label label = new Label();
                checkbox.Name = "checkBox_" + i;
                checkbox.Margin = new Thickness(0, 5, 0, 0);
                label.Name = "checkboxLabel_" + i;
                label.Content = "Checkbox Label " + i;
                label.Content = i;
                checkRow2.Children.Add(label);
                checkRow2.Children.Add(checkbox);
                ShortFormGrid.RegisterName(checkbox.Name, checkbox);
            }

            for (int i = 21; i < 31; i++)
            {
                CheckBox checkbox = new CheckBox();
                Label label = new Label();
                checkbox.Name = "checkBox_" + i;
                checkbox.Margin = new Thickness(0, 5, 0, 0);
                label.Name = "checkboxLabel_" + i;
                label.Content = "Checkbox Label " + i;
                label.Content = i;
                checkRow3.Children.Add(label);
                checkRow3.Children.Add(checkbox);
                ShortFormGrid.RegisterName(checkbox.Name, checkbox);
            }
            for (int i = 31; i < 41; i++)
            {
                CheckBox checkbox = new CheckBox();
                Label label = new Label();
                checkbox.Name = "checkBox_" + i;
                checkbox.Margin = new Thickness(0, 5, 0, 0);
                label.Name = "checkboxLabel_" + i;
                label.Content = "Checkbox Label " + i;
                label.Content = i;
                checkRow4.Children.Add(label);
                checkRow4.Children.Add(checkbox);
                ShortFormGrid.RegisterName(checkbox.Name, checkbox);
            }
            for (int i = 41; i < 51; i++)
            {
                CheckBox checkbox = new CheckBox();
                Label label = new Label();
                checkbox.Name = "checkBox_" + i;
                checkbox.Margin = new Thickness(0, 5, 0, 0);
                label.Name = "checkboxLabel_" + i;
                label.Content = "Checkbox Label " + i;
                label.Content = i;
                checkRow5.Children.Add(label);
                checkRow5.Children.Add(checkbox);
                ShortFormGrid.RegisterName(checkbox.Name, checkbox);
            }
            for (int i = 51; i < 56; i++)
            {
                CheckBox checkbox = new CheckBox();
                Label label = new Label();
                checkbox.Name = "checkBox_" + i;
                checkbox.Margin = new Thickness(0, 5, 0, 0);
                label.Name = "checkboxLabel_" + i;
                label.Content = "Checkbox Label " + i;
                label.Content = i;
                checkRow6.Children.Add(label);
                checkRow6.Children.Add(checkbox);
                ShortFormGrid.RegisterName(checkbox.Name, checkbox);
            }

        }

        private void goToNexStep (object sender, RoutedEventArgs e){
            List<CheckBox> allCheckboxes = new List<CheckBox>();

            allCheckboxes = checkRow1.Children.OfType<CheckBox>().ToList();

            allCheckboxes = allCheckboxes.Concat(checkRow2.Children.OfType<CheckBox>().ToList()).ToList();
            allCheckboxes = allCheckboxes.Concat(checkRow3.Children.OfType<CheckBox>().ToList()).ToList();
            allCheckboxes = allCheckboxes.Concat(checkRow4.Children.OfType<CheckBox>().ToList()).ToList();
            allCheckboxes = allCheckboxes.Concat(checkRow5.Children.OfType<CheckBox>().ToList()).ToList();
            allCheckboxes = allCheckboxes.Concat(checkRow6.Children.OfType<CheckBox>().ToList()).ToList();

            List<CheckBox> selectedBoxes = new List<CheckBox>();
            foreach (CheckBox checkbox in allCheckboxes) {
                
                StackPanel parent = (StackPanel)checkbox.Parent;
                parent.UnregisterName(checkbox.Name);
                parent.Children.Remove(checkbox);
                if (checkbox.IsChecked.GetValueOrDefault()) {
                    checkbox.IsChecked = false;
                    selectedBoxes.Add(checkbox);
                }
            }

            ProcessShortForm_2 proc2 = new ProcessShortForm_2(selectedBoxes);
            NavigationService.Navigate(proc2);
    }

    }
}
