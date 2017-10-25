using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDQA.Classes
{
    public class DistributionRow {
        private double _pointOne;
        private double _pointZeroFive;
        private double _pointZeroOne;
        private double _pointZeroZeroOne;

        public DistributionRow(double pointOne, double pointZeroFive, double pointZeroOne, double pointZeroZeroOne) {

            _pointOne = pointOne;
            _pointZeroFive = pointZeroFive;
            _pointZeroOne = pointZeroOne;
            _pointZeroZeroOne = pointZeroOne;


        }

        public double PointOne { get { return _pointOne; } }
        public double PointZeroFive { get { return _pointZeroFive; } }
        public double PointZeroOne { get { return _pointZeroOne; } }
        public double PointZeroZeroOne { get { return _pointZeroZeroOne; } }

    }

    public class DistributionTable {
        private Dictionary<int, DistributionRow> _distributionRows;

        public DistributionTable() {
            initializeDistributionRows();
        }

        public void initializeDistributionRows() {
            _distributionRows.Add(1, new DistributionRow(6.314,12.706,63.657,636.619));
            _distributionRows.Add(2, new DistributionRow(2.920,4.303,9.935,31.598));
            _distributionRows.Add(3, new DistributionRow(2.353, 4.303, 9.925, 31.598));
            _distributionRows.Add(4, new DistributionRow(2.132,2.776,4.604,8.610));
            _distributionRows.Add(5, new DistributionRow(2.015,2.571,4.032,6.859));

            _distributionRows.Add(6, new DistributionRow(1.943,2.447,3.707,5.959));
            _distributionRows.Add(7, new DistributionRow(1.895, 2.365, 3.499, 5.405));
            _distributionRows.Add(8, new DistributionRow(1.860, 2.306, 3.355, 5.041));
            _distributionRows.Add(9, new DistributionRow(1.833,2.262,3.250,4.781));
            _distributionRows.Add(10, new DistributionRow(1.812,2.228,3.169,4.587));

            _distributionRows.Add(11, new DistributionRow(1.796, 2.201, 3.106, 4.437));

            


        }



    }
}
