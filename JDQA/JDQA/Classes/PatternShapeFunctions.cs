using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JDQA.Classes
{
    public static class PatternShapeFunctions
    {
        public static double[] sliceCQ(int cq)
        {

            if (cq.ToString().Length != 4)
            {
                return new double[] { };
            }
            else
            {
                string cqString = cq.ToString();
                return new double[] { double.Parse(cqString.Substring(0, 1)), double.Parse(cqString.Substring(1, 1)), double.Parse(cqString.Substring(2, 1)), double.Parse(cqString.Substring(3, 1)) };
            }
        }

        public static int[] calculateIdealJDQA(List<PatternShapeModel> Z)
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
                    if (incrVal == -1 && ideal_jdqa[randomIndex] == 1) { }
                    else
                    {
                        ideal_jdqa[randomIndex] = ideal_jdqa[randomIndex] + incrVal;
                    }
                }

                iterations++;
            }
            int j = iterations;
            return ideal_jdqa;
        }
    }
}
