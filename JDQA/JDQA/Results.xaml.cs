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

            int[] idealJDQA = PatternShapeFunctions.calculateIdealJDQA(Z);
            IdealJDQAText.Content = string.Format("Job Demands Quotient: {0}{1}{2}{3}", idealJDQA[0], idealJDQA[1], idealJDQA[2], idealJDQA[3]);

            List<ConvertedScoreRow> zConvertedScores = new List<ConvertedScoreRow>();
            List<ConvertedScoreRow> xConvertedScores = new List<ConvertedScoreRow>();

            for (int i = 0; i < Z.Count(); i++) {
                double r = calculateR(PatternShapeFunctions.sliceCQ(Z[i].PS), idealJDQA);
                int modifiedR = (int)Math.Round(r * 100, MidpointRounding.AwayFromZero);
                ConvertedScoreRow zScoreRow = scoreTable.ConversionRows[modifiedR];
                zConvertedScores.Add(zScoreRow);
                double convertedScore = zScoreRow.Score;
                Label zLabel = new Label();
                zLabel.Content = string.Format("z{0} R Value: {1} Converted Score: {2}",i+1, Math.Round(r,2), convertedScore);

        //        ZResults.Children.Add(zLabel);
                
            }

            for (int i = 0; i < X.Count(); i++)
            {
                double r = calculateR(PatternShapeFunctions.sliceCQ(X[i].PS), idealJDQA);
                int modifiedR = (int)Math.Round(r * 100, MidpointRounding.AwayFromZero);
                ConvertedScoreRow xScoreRow = scoreTable.ConversionRows[modifiedR];
                xConvertedScores.Add(xScoreRow);
                double convertedScore = xScoreRow.Score;
                Label xLabel = new Label();
                xLabel.Content = String.Format("x{0} R Value: {1} Converted Score: {2}", i + 1, Math.Round(r,2), convertedScore);

       //         XResults.Children.Add(xLabel);

            }

            double c = zConvertedScores.Sum(z => z.Score);

            Label cLabel = new Label();
            cLabel.Content = String.Format("c value: {0}", c);
      //      CalculatedValues.Children.Add(cLabel);

            double x1 = c / zConvertedScores.Count();
            Label x1Label = new Label();
            x1Label.Content = String.Format("x1 value: {0}", Math.Round(x1,2,MidpointRounding.AwayFromZero));
     //       CalculatedValues.Children.Add(x1Label);


            double d = xConvertedScores.Sum(x => x.Score);
            Label dLabel = new Label();
            dLabel.Content = String.Format("d value: {0}",d);
     //       CalculatedValues.Children.Add(dLabel);

            double x2 = d/xConvertedScores.Count();

            Label x2Label = new Label();
            x2Label.Content = String.Format("x2 value: {0}", Math.Round(x2,2,MidpointRounding.AwayFromZero));
     //       CalculatedValues.Children.Add(x2Label);

            double a = zConvertedScores.Sum(z=>z.Score*z.Score);

            Label aLabel = new Label();
            aLabel.Content = String.Format("a value: {0}",a);
       //     CalculatedValues.Children.Add(aLabel);

            double b = xConvertedScores.Sum(x => x.Score * x.Score);

            Label bLabel = new Label();
            bLabel.Content = String.Format("b value: {0}", b);
       //     CalculatedValues.Children.Add(bLabel);

            double n1 = zConvertedScores.Count();
            Label n1Label = new Label();
            n1Label.Content = String.Format("n1 value: {0}", n1);
         //   CalculatedValues.Children.Add(n1Label);

            double n2 = xConvertedScores.Count();
            Label n2Label = new Label();
            n2Label.Content = String.Format("n2 value: {0}", n2);
         //   CalculatedValues.Children.Add(n2Label);

            double S = (a - ((c * c) / n1)) + (b - ((d * d) / n2));
            Label sLabel = new Label();
            sLabel.Content = String.Format("S value: {0}", Math.Round(S,2,MidpointRounding.AwayFromZero));
         //   CalculatedValues.Children.Add(sLabel);

            double R = Math.Sqrt((S / ((n1 + n2) - 2)) * ((1 / n1) + (1 / n2)));
            Label rLabel = new Label();
            rLabel.Content = String.Format(@"

Regarding individuals being considered for this position, any ITS Self Concept Pattern Shape with a compatibility (COM) of between
.70 and 1.00 would be an excellent match from a behavioral stand point.  From .40 to .69 would be considered a good match.
.10 to .39 a fair match and from -  (minus) 1.00 to + .09 a poor match.", R);

            double T = (x1 - x2) / R;
            Label tLabel = new Label();
            tLabel.Content = String.Format("\r\n T value: {0}", Math.Round(T,2,MidpointRounding.AwayFromZero));
 //           CalculatedValues.Children.Add(tLabel);

            int df = (int)(n1 + n2 - 2);
            Label dfLabel = new Label();
            dfLabel.Content = String.Format("\r\n df value: {0}", df);
 //           CalculatedValues.Children.Add(dfLabel);

            Label distributionLabel = new Label();
            DistributionTable dTable = new DistributionTable();
            DistributionRow dr = dTable._distributionRows.ContainsKey(df) ? dTable._distributionRows[df] : dTable._distributionRows[0];

            string significanceStatement = getSignificanceStatement(dr, T);

            Label significanceLabel = new Label();
            significanceLabel.Content = significanceStatement;
            CalculatedValues.Children.Add(significanceLabel);

            CalculatedValues.Children.Add(rLabel);

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


        private string getSignificanceStatement(DistributionRow dr, double tVal) {

            if (tVal > dr.PointZeroZeroOne)
            {
                return DistributionTable.PointZeroZeroOneStatement;
            }
            else if (tVal > dr.PointZeroOne)
            {
                return DistributionTable.PointZeroOneStatement;
            }
            else if (tVal > dr.PointZeroFive)
            {
                return DistributionTable.PointZeroFiveStatement;
            }
            else if (tVal > dr.PointOne)
            {
                return DistributionTable.PointOneStatement;
            }
            else {
                return DistributionTable.NoSignificanceStatement;
            }

        }
    }
}
