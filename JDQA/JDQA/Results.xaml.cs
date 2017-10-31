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

            int[] idealJDQA = calculateIdealJDQA(Z);
            IdealJDQAText.Content = string.Format("Ideal Pattern Shape: [{0},{1},{2},{3}]", idealJDQA[0], idealJDQA[1], idealJDQA[2], idealJDQA[3]);

            List<ConvertedScoreRow> zConvertedScores = new List<ConvertedScoreRow>();
            List<ConvertedScoreRow> xConvertedScores = new List<ConvertedScoreRow>();

            for (int i = 0; i < Z.Count(); i++) {
                double r = calculateR(sliceCQ(Z[i].PS), idealJDQA);
                int modifiedR = (int)Math.Round(r * 100, MidpointRounding.AwayFromZero);
                ConvertedScoreRow zScoreRow = scoreTable.ConversionRows[modifiedR];
                zConvertedScores.Add(zScoreRow);
                double convertedScore = zScoreRow.Score;
                Label zLabel = new Label();
                zLabel.Content = string.Format("z{0} R Value: {1} Converted Score: {2}",i+1, Math.Round(r,2), convertedScore);

                ZResults.Children.Add(zLabel);
                
            }

            for (int i = 0; i < X.Count(); i++)
            {
                double r = calculateR(sliceCQ(X[i].PS), idealJDQA);
                int modifiedR = (int)Math.Round(r * 100, MidpointRounding.AwayFromZero);
                ConvertedScoreRow xScoreRow = scoreTable.ConversionRows[modifiedR];
                xConvertedScores.Add(xScoreRow);
                double convertedScore = xScoreRow.Score;
                Label xLabel = new Label();
                xLabel.Content = String.Format("x{0} R Value: {1} Converted Score: {2}", i + 1, Math.Round(r,2), convertedScore);

                XResults.Children.Add(xLabel);

            }

            double c = zConvertedScores.Sum(z => z.Score);

            Label cLabel = new Label();
            cLabel.Content = String.Format("c value: {0}", c);
            CalculatedValues.Children.Add(cLabel);

            double x1 = c / zConvertedScores.Count();
            Label x1Label = new Label();
            x1Label.Content = String.Format("x1 value: {0}", Math.Round(x1,2,MidpointRounding.AwayFromZero));
            CalculatedValues.Children.Add(x1Label);


            double d = xConvertedScores.Sum(x => x.Score);
            Label dLabel = new Label();
            dLabel.Content = String.Format("d value: {0}",d);
            CalculatedValues.Children.Add(dLabel);

            double x2 = d/xConvertedScores.Count();

            Label x2Label = new Label();
            x2Label.Content = String.Format("x2 value: {0}", Math.Round(x2,2,MidpointRounding.AwayFromZero));
            CalculatedValues.Children.Add(x2Label);

            double a = zConvertedScores.Sum(z=>z.Score*z.Score);

            Label aLabel = new Label();
            aLabel.Content = String.Format("a value: {0}",a);
            CalculatedValues.Children.Add(aLabel);

            double b = xConvertedScores.Sum(x => x.Score * x.Score);

            Label bLabel = new Label();
            bLabel.Content = String.Format("b value: {0}", b);
            CalculatedValues.Children.Add(bLabel);

            double n1 = zConvertedScores.Count();
            Label n1Label = new Label();
            n1Label.Content = String.Format("n1 value: {0}", n1);
            CalculatedValues.Children.Add(n1Label);

            double n2 = xConvertedScores.Count();
            Label n2Label = new Label();
            n2Label.Content = String.Format("n2 value: {0}", n2);
            CalculatedValues.Children.Add(n2Label);

            double S = (a - ((c * c) / n1)) + (b - ((d * d) / n2));
            Label sLabel = new Label();
            sLabel.Content = String.Format("S value: {0}", Math.Round(S,2,MidpointRounding.AwayFromZero));
            CalculatedValues.Children.Add(sLabel);

            double R = Math.Sqrt((S / ((n1 + n2) - 2)) * ((1 / n1) + (1 / n2)));
            Label rLabel = new Label();
            rLabel.Content = String.Format("R value: {0}", Math.Round(R,2,MidpointRounding.AwayFromZero));
            CalculatedValues.Children.Add(rLabel);

            double T = (x1 - x2) / R;
            Label tLabel = new Label();
            tLabel.Content = String.Format("T value: {0}", Math.Round(T,2,MidpointRounding.AwayFromZero));
            CalculatedValues.Children.Add(tLabel);

            double df = n1 + n2 - 2;
            Label dfLabel = new Label();
            dfLabel.Content = String.Format("df value: {0}", Math.Round(df,2,MidpointRounding.AwayFromZero));
            CalculatedValues.Children.Add(dfLabel);

           

        }

        private int[] calculateIdealJDQA(List<PatternShapeModel> Z)
        {
            int[] ideal_jdqa;
            ideal_jdqa = new int[4];

            ideal_jdqa[0] = (int)Math.Round((Z.Sum(z => sliceCQ(z.PS)[0])) / Z.Count, MidpointRounding.AwayFromZero);
            ideal_jdqa[1] = (int)Math.Round((Z.Sum(z => sliceCQ(z.PS)[1])) / Z.Count, MidpointRounding.AwayFromZero);
            ideal_jdqa[2] = (int)Math.Round((Z.Sum(z => sliceCQ(z.PS)[2])) / Z.Count, MidpointRounding.AwayFromZero);
            ideal_jdqa[3] = (int)Math.Round((Z.Sum(z => sliceCQ(z.PS)[3])) / Z.Count, MidpointRounding.AwayFromZero);

            int maxDiff = 0;
            int maxIndex = 0;
            bool altered = false;

            for (int i = 0; i < ideal_jdqa.Count(); i++)
            {
                if (Math.Abs(5 - ideal_jdqa[i]) > maxDiff && ideal_jdqa[i] != 5)
                {
                    altered = true;
                    maxDiff = Math.Abs(5 - ideal_jdqa[i]);
                    maxIndex = i;
                }
            }

            //for all 5s case
            if (altered)
            {
                ideal_jdqa[maxIndex] = ideal_jdqa[maxIndex] < 5 ? 1 : 9;
            }
            //force 20
            int iterations = 0;
            while (ideal_jdqa.Sum() != 20 && iterations < 10)
            {
                Random random = new Random();

                int randomIndex = random.Next(0, 4);
                while (randomIndex == maxIndex)
                {
                    randomIndex = random.Next(0, 4);
                }

                int incrVal = ideal_jdqa.Sum() > 20 ? -1 : 1;

                if (ideal_jdqa[randomIndex] != 5)
                {
                    ideal_jdqa[randomIndex] = ideal_jdqa[randomIndex] + incrVal;
                }

                iterations++;
            }
            int j = iterations;
            return ideal_jdqa;
        }

        private double calculateR(double[] subject, int[] ideal) {

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

        private double[,] getMultiplesAndSquares(double[] subject, int[] ideal)
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
