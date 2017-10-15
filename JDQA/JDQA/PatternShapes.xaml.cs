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
            _nextDictionary.Add(z3_8, x1_1);

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
        List<TextBox> z1TextBoxes, z2TextBoxes, z3TextBoxes, x1TextBoxes, x2TextBoxes, x3Textboxes;
        List<List<TextBox>> zTextBoxLists, xTextBoxLists;

            shapeDictionary = new Dictionary<string, Dictionary<int, Dictionary<int, int>>>();

            zTextBoxLists = new List<List<TextBox>>() {
                z1.Children.OfType<TextBox>().ToList(),
                z2.Children.OfType<TextBox>().ToList(),
                z3.Children.OfType<TextBox>().ToList()
            };

            xTextBoxLists = new List<List<TextBox>>() {

                x1.Children.OfType<TextBox>().ToList(),
                x2.Children.OfType<TextBox>().ToList(),
                x3.Children.OfType<TextBox>().ToList(),
            };

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

        private List<PatternShapeModel> getPatternShapeModels() {

            List<PatternShapeModel> patternshapeList = new List<PatternShapeModel>();


            return patternshapeList;
        }

        private void calculateCorrelation(object sender, RoutedEventArgs e)
        {
            Dictionary<string, Dictionary<int, Dictionary<int, int>>> shapeDictionary =  createShapeDictionary();
        }

    }
}
