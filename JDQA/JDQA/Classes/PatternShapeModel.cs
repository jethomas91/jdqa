using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDQA.Classes
{
    public class PatternShapeModel
    {
        private int _cq;
        private decimal _atc;
        private decimal _mr;
        private decimal _sr;

        public PatternShapeModel(int cq, decimal atc, decimal mr, decimal sr) {
            _cq = cq;
            _atc = atc;
            _mr = mr;
            _sr = sr;  
        }

        public int CQ{ get{ return _cq;}}

        public decimal ATC { get { return _atc; } }

        public decimal MR { get { return _mr;} }

        public decimal SR { get { return SR; } }
    }
}
