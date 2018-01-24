using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDQA.Classes
{
    public static class QuestionShapeValues
    {
          public static List<int> shapeValues = new List<int> { 5951, 1559, 1595, 9236,9515,9452,5339,1784,1298,9551,4934,1379,5195,4259,3269,6851,2279,9713,5933,9155,1658,1397,2954,1685,3188,5393,9713,5924,9515,5861,7913,9551,7166,4934,8813,3197,5159,3395,5951,4493,9731,1487,
                                                    3494,9731,4295,7913,9461,1568,9731,1289,8741,3269,6815,1379,1676};

          public static int getQuestionValue(int questionNumber) {

            return shapeValues[questionNumber-1];
        }

    }
}
