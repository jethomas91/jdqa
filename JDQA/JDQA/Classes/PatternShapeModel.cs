using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JDQA.Classes
{
    public class PatternShapeModel
    {
        private int _ps;
        private double _atc;
        private double _mr;
        private double _sr;

        public PatternShapeModel(int cq, double atc, double mr, double sr) {
            _ps = cq;
            _atc = atc;
            _mr = mr;
            _sr = sr;  
        }

        public int PS{ get{ return _ps;}}

        public double ATC { get { return _atc; } }

        public double MR { get { return _mr;} }

        public double SR { get { return SR; } }

        public static  Dictionary<string,List<PatternShapeModel>> getPatternShapeModels(Dictionary<string, Dictionary<int, Dictionary<int, int>>> shapeDictionary)
        {
            Dictionary<string, List<PatternShapeModel>> ResultDictionary = new Dictionary<string, List<PatternShapeModel>>();

            List<PatternShapeModel> patternShapeList_Z = new List<PatternShapeModel>();
            List<PatternShapeModel> patternShapeList_X = new List<PatternShapeModel>();

            Dictionary<int, Dictionary<int, int>> Z = shapeDictionary["Z"];
            Dictionary<int, Dictionary<int, int>> X = shapeDictionary["X"];

            //for z loop only
            for (int i = 1; i <= Z.Count; i++)
            {
                int z_cq = Z[i][1];
                int z_atc = Z[i][2];
                double z_mr = double.Parse(Z[i][3].ToString() + "." + Z[i][4].ToString());
                double z_sr = double.Parse(Z[i][5].ToString() + "." + Z[i][6].ToString());
                double z_lasr = double.Parse(Z[i][7].ToString() + "." + Z[i][8].ToString());
                PatternShapeModel pShape = new PatternShapeModel(z_cq, z_atc, z_mr, z_sr);

                patternShapeList_Z.Add(pShape);
            }
            ResultDictionary.Add("Z", patternShapeList_Z);
             
            //for x loop only
            for (int i = 1; i <= X.Count; i++)
            {
                int x_cq = X[i][1];
                int x_atc = X[i][2];
                double x_mr = double.Parse(X[i][3].ToString() + "." + X[i][4].ToString());
                double x_sr = double.Parse(X[i][5].ToString() + "." + X[i][6].ToString());
                double x_lasr = double.Parse(X[i][7].ToString() + "." + X[i][8].ToString());
                PatternShapeModel pShape = new PatternShapeModel(x_cq, x_atc, x_mr, x_sr);

                patternShapeList_X.Add(pShape);
            }
            ResultDictionary.Add("X", patternShapeList_X);


            return ResultDictionary;
        }
    }
}
