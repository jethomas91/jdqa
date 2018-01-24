using JDQA.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
        List<Phase1Selections> Selections;
        public ProcessShortForm_3(List<CheckBox> checkboxList, List<Phase1Selections> selections)
        {
            Selections = selections;
            InitializeComponent();
            addSelectedOptions(checkboxList, selections);
        }

        private void addSelectedOptions(List<CheckBox> checkboxList, List<Phase1Selections> selections)
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
                    Selections.Last().stage3 = int.Parse(checkbox.Name.Split('_')[1]);
                }
            }

            string nums = "";

            string questionValues = "";
            for (int i = 0; i < QuestionShapeValues.shapeValues.Count(); i++)
            {
                questionValues += (i + 1) + ":" + QuestionShapeValues.shapeValues[i] + ", ";
            }

            questionValues += "\r\n";

            int entryNum = 1;

            string diagText = "";
            foreach (Phase1Selections selection in  Selections) {
                diagText+="**************Entry Number "+entryNum+"******************\r\n\r\n";
                List<PatternShapeModel> patternShapes = new List<PatternShapeModel>() {};
                foreach (int stage2Val in selection.stage2) {
                    patternShapes.Add(new PatternShapeModel(QuestionShapeValues.getQuestionValue(stage2Val),0.0,0.0,0.0));
                }

                patternShapes.Add(new PatternShapeModel(QuestionShapeValues.getQuestionValue(selection.stage3), 0.0, 0.0, 0.0));
                patternShapes.Add(new PatternShapeModel(QuestionShapeValues.getQuestionValue(selection.stage3), 0.0, 0.0, 0.0));

                int[] idealjdqa = PatternShapeFunctions.calculateIdealJDQA(patternShapes);

                diagText += "JDQA's to be averaged (Last shape duplicated for darkened circle values):\r\n";
                diagText += String.Join("\r\n",patternShapes.Select(ps => ps.PS).ToList());
                diagText += "\r\nIdeal JDQA:"+string.Join("",idealjdqa)+"\r\n\r\n";


                entryNum++;

            }


            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "phase1Debug_"+Guid.NewGuid()+ ".txt";
                sfd.ShowDialog();

                if (sfd.FileName != "") {
                    using (StreamWriter writer = new StreamWriter(sfd.OpenFile())) {

                        writer.Write(diagText);
                    };
                }
            }
            catch (Exception ex) {

            }




        }

        private void addAnotherForm(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProcessShortForm(Selections));
        }

    }
}
