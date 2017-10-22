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
    /// Interaction logic for PatternShapes.xaml
    /// </summary>
    public partial class PatternShapes : Page
    {
        private Dictionary<TextBox, TextBox> _nextDictionary;

        public PatternShapes()
        {
            InitializeComponent();
            InitializeNextDictionary();

        }

        private void InitializeNextDictionary() {
            _nextDictionary = new Dictionary<TextBox, TextBox>();

            _nextDictionary.Add(z1_1,z1_2);
            _nextDictionary.Add(z1_2, z1_3);
            _nextDictionary.Add(z1_3, z1_4);
            _nextDictionary.Add(z1_4, z1_5);
            _nextDictionary.Add(z1_5, z1_6);
            _nextDictionary.Add(z1_6, z1_7);
            _nextDictionary.Add(z1_7, z1_8);
            _nextDictionary.Add(z1_8, z2_1);

            _nextDictionary.Add(z2_1, z2_2);
            _nextDictionary.Add(z2_2, z2_3);
            _nextDictionary.Add(z2_3, z2_4);
            _nextDictionary.Add(z2_4, z2_5);
            _nextDictionary.Add(z2_5, z2_6);
            _nextDictionary.Add(z2_6, z2_7);
            _nextDictionary.Add(z2_7, z2_8);
            _nextDictionary.Add(z2_8, z3_1);

            _nextDictionary.Add(z3_1, z3_2);
            _nextDictionary.Add(z3_2, z3_3);
            _nextDictionary.Add(z3_3, z3_4);
            _nextDictionary.Add(z3_4, z3_5);
            _nextDictionary.Add(z3_5, z3_6);
            _nextDictionary.Add(z3_6, z3_7);
            _nextDictionary.Add(z3_7, z3_8);

            _nextDictionary.Add(x1_1, x1_2);
            _nextDictionary.Add(x1_2, x1_3);
            _nextDictionary.Add(x1_3, x1_4);
            _nextDictionary.Add(x1_4, x1_5);
            _nextDictionary.Add(x1_5, x1_6);
            _nextDictionary.Add(x1_6, x1_7);
            _nextDictionary.Add(x1_7, x1_8);
            _nextDictionary.Add(x1_8, x2_1);

            _nextDictionary.Add(x2_1, x2_2);
            _nextDictionary.Add(x2_2, x2_3);
            _nextDictionary.Add(x2_3, x2_4);
            _nextDictionary.Add(x2_4, x2_5);
            _nextDictionary.Add(x2_5, x2_6);
            _nextDictionary.Add(x2_6, x2_7);
            _nextDictionary.Add(x2_7, x2_8);
            _nextDictionary.Add(x2_8, x3_1);

            _nextDictionary.Add(x3_1, x3_2);
            _nextDictionary.Add(x3_2, x3_3);
            _nextDictionary.Add(x3_3, x3_4);
            _nextDictionary.Add(x3_4, x3_5);
            _nextDictionary.Add(x3_5, x3_6);
            _nextDictionary.Add(x3_6, x3_7);
            _nextDictionary.Add(x3_7, x3_8);
        }

        private Dictionary<string, Dictionary<int, Dictionary<int, int>>> createShapeDictionary() {
        Dictionary<string, Dictionary<int, Dictionary<int, int>>> shapeDictionary;
        List<List<TextBox>> zTextBoxLists, xTextBoxLists;

            shapeDictionary = new Dictionary<string, Dictionary<int, Dictionary<int, int>>>();
            IEnumerable<StackPanel> zStackList = ZStack.Children.OfType<StackPanel>();
            IEnumerable<StackPanel> xStackList = XStack.Children.OfType<StackPanel>();

            zTextBoxLists = new List<List<TextBox>>() {};
            xTextBoxLists = new List<List<TextBox>>() {};

            foreach (StackPanel zStack in zStackList) {
                zTextBoxLists.Add(zStack.Children.OfType<TextBox>().ToList());
            }
            foreach (StackPanel xStack in xStackList)
            {
                xTextBoxLists.Add(xStack.Children.OfType<TextBox>().ToList());
            }

            shapeDictionary.Add("Z", new Dictionary<int, Dictionary<int, int>>());
            shapeDictionary.Add("X", new Dictionary<int, Dictionary<int, int>>());


            for (int i = 0; i < zTextBoxLists.Count; i++)
            {
                int zKey = i + 1;
                shapeDictionary["Z"].Add(zKey, new Dictionary<int, int>());
                List<TextBox> zTextBoxList = zTextBoxLists[i];

                for (int j = 0; j < zTextBoxList.Count; j++)
                {
                    TextBox textbox = zTextBoxList[j];
                    int outParseVal;
                    if (int.TryParse(textbox.Text, out outParseVal))
                    {
                        shapeDictionary["Z"][zKey].Add(j + 1, outParseVal);
                    }
                    else
                    {
                        MessageBox.Show(String.Format("Incorrect Input in Z group, Entry {0}, Field {1}", zKey, j + 1));
                        return null;
                    }

                }
            }

                for (int i = 0; i < xTextBoxLists.Count; i++)
                {
                    int xKey = i + 1;
                    shapeDictionary["X"].Add(xKey, new Dictionary<int, int>());
                    List<TextBox> xTextBoxList = xTextBoxLists[i];

                    for (int j = 0; j < xTextBoxList.Count; j++)
                    {
                        TextBox textbox = xTextBoxList[j];
                        int outParseVal;
                        if (int.TryParse(textbox.Text, out outParseVal))
                        {
                            shapeDictionary["X"][xKey].Add(j + 1, outParseVal);
                        }
                        else
                        {
                            MessageBox.Show(String.Format("Incorrect Input in X group, Entry {0}, Field {1}", xKey, j + 1));
                            return null;
                        }

                    }
                }

            return shapeDictionary;
        }

        private void moveIfMaxLength(object sender, RoutedEventArgs e) {
            TextBox shapeField = sender as TextBox;
            if (shapeField.Text.Length >= shapeField.MaxLength)
            {
                if (_nextDictionary.ContainsKey(shapeField))
                {
                    _nextDictionary[shapeField].Focus();
                }
            }

        }


        private void calculateCorrelation(object sender, RoutedEventArgs e)
        {
            Dictionary<string, Dictionary<int, Dictionary<int, int>>> shapeDictionary =  createShapeDictionary();

            if (shapeDictionary != null)
            {
                Results results = new Results(PatternShapeModel.getPatternShapeModels(shapeDictionary));

                NavigationService.Navigate(results);
            }
            
        }

        private void addPattern(object sender, RoutedEventArgs e)
        {
            Button curButton = sender as Button;
            StackPanel groupStack = (StackPanel)this.FindName(curButton.Name == "addZGroup" ? "ZStack" : "XStack");

            Dictionary<string, StackPanel> groupsDictionary = new Dictionary<string, StackPanel>();
            List<StackPanel> patternShapeInputs = patternShapeParentGrid.Children.OfType<StackPanel>().ToList();

            string groupPrefix = curButton.Name == "addZGroup" ? "z" : "x";


            StackPanel iteratedPanel = (StackPanel)this.FindName(groupPrefix+"1");
            int groupIndexCounter = 1;

            while (iteratedPanel != null) {

                iteratedPanel = (StackPanel)this.FindName(groupPrefix+""+groupIndexCounter);
                groupIndexCounter = iteratedPanel == null ? groupIndexCounter: groupIndexCounter+1;
            }

            StackPanel newShape = new StackPanel();
            NameScope.SetNameScope(newShape, new NameScope());

            newShape.Name = groupPrefix + "" + groupIndexCounter;
            newShape.Orientation = Orientation.Horizontal;
            Thickness newMargin = newShape.Margin;
            newMargin.Left = 0;
            newMargin.Top = 0;
            newMargin.Bottom = 0;
            newMargin.Right = 0;

            newShape.Margin = newMargin;
            TextBox[] shapeTextBoxes = new TextBox[8];
            Label[] shapeDelimiters = new Label[7];

            shapeDelimiters[0] = new Label();
            shapeDelimiters[0].Content = "-";

            shapeDelimiters[1] = new Label();
            shapeDelimiters[1].Content = "-";

            shapeDelimiters[2] = new Label();
            shapeDelimiters[2].Content = ".";

            shapeDelimiters[3] = new Label();
            shapeDelimiters[3].Content = "-";

            shapeDelimiters[4] = new Label();
            shapeDelimiters[4].Content = ".";

            shapeDelimiters[5] = new Label();
            shapeDelimiters[5].Content = "-";

            shapeDelimiters[6] = new Label();
            shapeDelimiters[6].Content = ".";

            for (int i = 0; i <= 7; i++) {
                shapeTextBoxes[i] = new TextBox();
                shapeTextBoxes[i].Name = String.Format("{0}_{1}", newShape.Name, i + 1);
                shapeTextBoxes[i].KeyDown += moveIfMaxLength;                
                    }

            shapeTextBoxes[0].Width = 50;
            shapeTextBoxes[0].MaxLength = 4;

            shapeTextBoxes[1].Width = 25;
            shapeTextBoxes[1].MaxLength = 2;

            shapeTextBoxes[2].Width = 15;
            shapeTextBoxes[2].MaxLength = 1;

            shapeTextBoxes[3].Width = 20;
            shapeTextBoxes[3].MaxLength = 2;

            shapeTextBoxes[4].Width = 15;
            shapeTextBoxes[4].MaxLength = 1;

            shapeTextBoxes[5].Width = 20;
            shapeTextBoxes[5].MaxLength = 2;

            shapeTextBoxes[6].Width = 15;
            shapeTextBoxes[6].MaxLength = 1;

            shapeTextBoxes[7].Width = 20;
            shapeTextBoxes[7].MaxLength = 2;

            TextBox lastTextboxInGroup = (TextBox)groupStack.FindName(String.Format("{0}{1}_{2}", groupPrefix, groupIndexCounter - 1,8));

            for (int i = 0; i <= 7; i++)
            {
                groupStack.RegisterName(shapeTextBoxes[i].Name, shapeTextBoxes[i]);
                newShape.Children.Add(shapeTextBoxes[i]);
                if (i == 0)
                {
                    _nextDictionary[lastTextboxInGroup] = shapeTextBoxes[i];
                }
                else {
                    _nextDictionary.Add(shapeTextBoxes[i - 1], shapeTextBoxes[i]);
                }
                if (i < shapeDelimiters.Count()) {
                    newShape.Children.Add(shapeDelimiters[i]);
                }
            }

            groupStack.RegisterName(newShape.Name, newShape);
            groupStack.Children.Add(newShape);
        }

    }
}
