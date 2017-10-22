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
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Page
    {
        public Results(Dictionary<string, List<PatternShapeModel>> patternShapes)
        {
            InitializeComponent();
            ShowCalculations(patternShapes);
        }

        private void ShowCalculations(Dictionary<string, List<PatternShapeModel>> patternShapes)
        {
            List<PatternShapeModel> Z = patternShapes["Z"];
            List<PatternShapeModel> X = patternShapes["X"];
            ConvertedScoreTable scoreTable = new ConvertedScoreTable();

            double[] idealJDQA = calculateIdealJDQA(Z);
            IdealJDQAText.Content = string.Format("Ideal Pattern Shape: [{0},{1},{2},{3}]", idealJDQA[0], idealJDQA[1], idealJDQA[2], idealJDQA[3]);

            List<double> zRValueList = new List<double>();
            List<double> xRValueList = new List<double>();

            // double z1_r = calculateR(sliceCQ(Z[0].PS), idealJDQA);
            // double z2_r = calculateR(sliceCQ(Z[1].PS), idealJDQA);
            // double z3_r = calculateR(sliceCQ(Z[2].PS), idealJDQA);
            //
            // double x1_r = calculateR(sliceCQ(X[0].PS), idealJDQA);
            // double x2_r = calculateR(sliceCQ(X[1].PS), idealJDQA);
            // double x3_r = calculateR(sliceCQ(X[2].PS), idealJDQA);

            for (int i = 0; i < Z.Count(); i++) {
                double r = calculateR(sliceCQ(Z[i].PS), idealJDQA);
                zRValueList.Add(r);
                int modifiedR = (int)Math.Round(r * 100, MidpointRounding.AwayFromZero);
                double convertedScore = scoreTable.ConversionRows[modifiedR].Score;
                Label zLabel = new Label();
                zLabel.Content = string.Format("z{0} R Value: {1} Converted Score: {2}",i+1, Math.Round(r,2), convertedScore);

                ZResults.Children.Add(zLabel);
                
            }

            for (int i = 0; i < X.Count(); i++)
            {
                double r = calculateR(sliceCQ(X[i].PS), idealJDQA);
                xRValueList.Add(r);
                Label xLabel = new Label();
                xLabel.Content = String.Format("x{0} R Value: {1}", i + 1, Math.Round(r,2));

                XResults.Children.Add(xLabel);

            }



        }

        private double[] calculateIdealJDQA(List<PatternShapeModel> Z)
        {
            double[]ideal_jdqa;
            ideal_jdqa = new double[4];

            ideal_jdqa[0] = (Z.Sum(z=> sliceCQ(z.PS)[0])) / Z.Count;
            ideal_jdqa[1] = (Z.Sum(z => sliceCQ(z.PS)[1])) / Z.Count;
            ideal_jdqa[2] = (Z.Sum(z => sliceCQ(z.PS)[2])) / Z.Count;
            ideal_jdqa[3] = (Z.Sum(z => sliceCQ(z.PS)[3])) / Z.Count;

            return ideal_jdqa;
        }

        private double calculateR(double[] subject, double[] ideal) {

            double[,] multiplesAndSquares = getMultiplesAndSquares(subject, ideal);
            double x_sum = subject[0] + subject[1] + subject[2]+subject[3];
            double y_sum = ideal[0] + ideal[1] + ideal[2]+ideal[3];
            double xy_sum = multiplesAndSquares[0,0] + multiplesAndSquares[1,0] + multiplesAndSquares[2,0]+ multiplesAndSquares[3,0];
            double x2_sum = multiplesAndSquares[0,1] + multiplesAndSquares[1,1] + multiplesAndSquares[2,1]+multiplesAndSquares[3,1];
            double y2_sum = multiplesAndSquares[0,2] + multiplesAndSquares[1,2] + multiplesAndSquares[2,2]+multiplesAndSquares[3,2];

            double rNumerator = (4*xy_sum)-((x_sum)*(y_sum));

            double rDenominator = Math.Sqrt((4 * x2_sum - (x_sum * x_sum)) * (4 * y2_sum - (y_sum * y_sum)));

            if (rDenominator == 0)
            {
                return 0;
            }
            else
            {
                double r = rNumerator / rDenominator;
                return r;
            }
        }

        private double[,] getMultiplesAndSquares(double[] subject, double[] ideal)
        {
            double[,] multiplesAndSquares = new double[4, 3];

            multiplesAndSquares[0,0] = subject[0] * ideal[0];
            multiplesAndSquares[0,1] = subject[0] * subject[0];
            multiplesAndSquares[0,2] = ideal[0] * ideal[0];

            multiplesAndSquares[1,0] = subject[1] * ideal[1];
            multiplesAndSquares[1,1] = subject[1] * subject[1];
            multiplesAndSquares[1,2] = ideal[1] * ideal[1];

            multiplesAndSquares[2,0] = subject[2] * ideal[2];
            multiplesAndSquares[2,1] = subject[2] * subject[2];
            multiplesAndSquares[2,2] = ideal[2] * ideal[2];

            multiplesAndSquares[3, 0] = subject[3] * ideal[3];
            multiplesAndSquares[3, 1] = subject[3] * subject[3];
            multiplesAndSquares[3, 2] = ideal[3] * ideal[3];

            return multiplesAndSquares;
        }
        private double[] sliceCQ(int cq) {

            if (cq.ToString().Length != 4)
            {
                return new double[] { };
            }
            else {
                string cqString = cq.ToString();
                return new double[] { double.Parse(cqString.Substring(0,1)), double.Parse(cqString.Substring(1,1)), double.Parse(cqString.Substring(2,1)), double.Parse(cqString.Substring(3,1))};
            }
        }
    }
}
