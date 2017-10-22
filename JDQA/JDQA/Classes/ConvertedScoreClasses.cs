using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDQA.Classes
{
    public class ConvertedScoreRow
    {
        public int Angle, Score;

        public ConvertedScoreRow(int angle, int score) {
            Angle = angle;
            Score = score;
        }
        public ConvertedScoreRow() {
        } 
    }

    public class ConvertedScoreTable {

        public Dictionary<int, ConvertedScoreRow> ConversionRows = new Dictionary<int, ConvertedScoreRow>();
        
        
        public ConvertedScoreTable() {
            initializeTable();
        }

        private void initializeTable() {
            for (int i = -100; i <= 100; i++) {
                ConversionRows.Add(i, null);
            }

            ConversionRows[-100] = new ConvertedScoreRow(180, 0);
            ConversionRows[-99] = new ConvertedScoreRow(172, 4);
            ConversionRows[-98] = new ConvertedScoreRow(169, 6);
            ConversionRows[-97] = new ConvertedScoreRow(166,8);
            ConversionRows[-96] = new ConvertedScoreRow(164,9);
            ConversionRows[-95] = new ConvertedScoreRow(162,10);

            ConversionRows[-94] = new ConvertedScoreRow(160,11);
            ConversionRows[-93] = new ConvertedScoreRow(158,12);
            ConversionRows[-92] = new ConvertedScoreRow(157,13);
            ConversionRows[-91] = new ConvertedScoreRow(156,14);
            ConversionRows[-90] = new ConvertedScoreRow(154,14);
            ConversionRows[-89] = new ConvertedScoreRow(153,15);
            ConversionRows[-88] = new ConvertedScoreRow(152,16);
            ConversionRows[-87] = new ConvertedScoreRow(150,16);
            ConversionRows[-86] = new ConvertedScoreRow(150,17);
            ConversionRows[-85] = new ConvertedScoreRow(148,17);
            ConversionRows[-84] = new ConvertedScoreRow(147,18);
            ConversionRows[-83] = new ConvertedScoreRow(146,19);
            ConversionRows[-82] = new ConvertedScoreRow(145,19);
            ConversionRows[-81] = new ConvertedScoreRow(144,20);
            ConversionRows[-80] = new ConvertedScoreRow(143,20);
            ConversionRows[-79] = new ConvertedScoreRow(142,21);
            ConversionRows[-78] = new ConvertedScoreRow(141,21);
            ConversionRows[-77] = new ConvertedScoreRow(140,22);
            ConversionRows[-76] = new ConvertedScoreRow(139,22);
            ConversionRows[-75] = new ConvertedScoreRow(139,23);
            ConversionRows[-74] = new ConvertedScoreRow(138,23);
            ConversionRows[-73] = new ConvertedScoreRow(137,24);
            ConversionRows[-72] = new ConvertedScoreRow(136,24);
            ConversionRows[-71] = new ConvertedScoreRow(135,25);
            ConversionRows[-70] = new ConvertedScoreRow(134,25);
            ConversionRows[-69] = new ConvertedScoreRow(134,25);
            ConversionRows[-68] = new ConvertedScoreRow(133,26);
            ConversionRows[-67] = new ConvertedScoreRow(132,26);

            ConversionRows[-66] = new ConvertedScoreRow(131,27);
            ConversionRows[-65] = new ConvertedScoreRow(131,27);
            ConversionRows[-64] = new ConvertedScoreRow(130,28);
            ConversionRows[-63] = new ConvertedScoreRow(129,28);
            ConversionRows[-62] = new ConvertedScoreRow(128,29);
            ConversionRows[-61] = new ConvertedScoreRow(128,29);
            ConversionRows[-60] = new ConvertedScoreRow(127,29);
            ConversionRows[-59] = new ConvertedScoreRow(126,30);
            ConversionRows[-58] = new ConvertedScoreRow(126,30);
            ConversionRows[-57] = new ConvertedScoreRow(125,31);
            ConversionRows[-56] = new ConvertedScoreRow(124,31);
            ConversionRows[-55] = new ConvertedScoreRow(123,31);
            ConversionRows[-54] = new ConvertedScoreRow(123,32);
            ConversionRows[-53] = new ConvertedScoreRow(122,32);
            ConversionRows[-52] = new ConvertedScoreRow(121,33);
            ConversionRows[-51] = new ConvertedScoreRow(121,33);
            ConversionRows[-50] = new ConvertedScoreRow(120,33);
            ConversionRows[-49] = new ConvertedScoreRow(119,34);
            ConversionRows[-48] = new ConvertedScoreRow(119,34);
            ConversionRows[-47] = new ConvertedScoreRow(118,34);
            ConversionRows[-46] = new ConvertedScoreRow(117,35);
            ConversionRows[-45] = new ConvertedScoreRow(117,35);
            ConversionRows[-44] = new ConvertedScoreRow(116,35);
            ConversionRows[-43] = new ConvertedScoreRow(115,36);
            ConversionRows[-42] = new ConvertedScoreRow(115,36);
            ConversionRows[-41] = new ConvertedScoreRow(114,36);
            ConversionRows[-40] = new ConvertedScoreRow(114,37);
            ConversionRows[-39] = new ConvertedScoreRow(113,37);
            ConversionRows[-38] = new ConvertedScoreRow(112,37);
            ConversionRows[-37] = new ConvertedScoreRow(112,38);
            ConversionRows[-36] = new ConvertedScoreRow(111,38);
            ConversionRows[-35] = new ConvertedScoreRow(110,38);
            ConversionRows[-34] = new ConvertedScoreRow(110,39);
            ConversionRows[-33] = new ConvertedScoreRow(109,39);

            ConversionRows[-32] = new ConvertedScoreRow(109,39);
            ConversionRows[-31] = new ConvertedScoreRow(108,40);
            ConversionRows[-30] = new ConvertedScoreRow(107,40);
            ConversionRows[-29] = new ConvertedScoreRow(107,40);
            ConversionRows[-28] = new ConvertedScoreRow(106,41);
            ConversionRows[-27] = new ConvertedScoreRow(106,41);
            ConversionRows[-26] = new ConvertedScoreRow(105,41);
            ConversionRows[-25] = new ConvertedScoreRow(104,41);
            ConversionRows[-24] = new ConvertedScoreRow(104,42);
            ConversionRows[-23] = new ConvertedScoreRow(103,42);
            ConversionRows[-22] = new ConvertedScoreRow(103,43);
            ConversionRows[-21] = new ConvertedScoreRow(102,43);
            ConversionRows[-20] = new ConvertedScoreRow(102,43);
            ConversionRows[-19] = new ConvertedScoreRow(101,44);
            ConversionRows[-18] = new ConvertedScoreRow(100,44);
            ConversionRows[-17] = new ConvertedScoreRow(100,44);

            ConversionRows[-16] = new ConvertedScoreRow(99,45);
            ConversionRows[-15] = new ConvertedScoreRow(99,45);
            ConversionRows[-14] = new ConvertedScoreRow(98,45);
            ConversionRows[-13] = new ConvertedScoreRow(97,46);
            ConversionRows[-12] = new ConvertedScoreRow(97,46);
            ConversionRows[-11] = new ConvertedScoreRow(96,46);
            ConversionRows[-10] = new ConvertedScoreRow(96,47);
            ConversionRows[-9] = new ConvertedScoreRow(95, 47);
            ConversionRows[-8] = new ConvertedScoreRow(95,47);
            ConversionRows[-7] = new ConvertedScoreRow(94,48);
            ConversionRows[-6] = new ConvertedScoreRow(93,48);
            ConversionRows[-5] = new ConvertedScoreRow(93,48);
            ConversionRows[-4] = new ConvertedScoreRow(92,49);
            ConversionRows[-3] = new ConvertedScoreRow(92,49);
            ConversionRows[-2] = new ConvertedScoreRow(91,49);
            ConversionRows[-1] = new ConvertedScoreRow(91,50);
            ConversionRows[0] = new ConvertedScoreRow(90,50);

            //Positives
            ConversionRows[1] = new ConvertedScoreRow(89, 50);
            ConversionRows[2] = new ConvertedScoreRow(89, 51);
            ConversionRows[3] = new ConvertedScoreRow(88, 51);
            ConversionRows[4] = new ConvertedScoreRow(88, 51);
            ConversionRows[5] = new ConvertedScoreRow(87, 52);
            ConversionRows[6] = new ConvertedScoreRow(87, 52);
            ConversionRows[7] = new ConvertedScoreRow(86, 52);
            ConversionRows[8] = new ConvertedScoreRow(85, 53);
            ConversionRows[9] = new ConvertedScoreRow(85, 53);
            ConversionRows[10] = new ConvertedScoreRow(84,53);
            ConversionRows[11] = new ConvertedScoreRow(84,54);
            ConversionRows[12] = new ConvertedScoreRow(83,54);
            ConversionRows[13] = new ConvertedScoreRow(83,54);
            ConversionRows[14] = new ConvertedScoreRow(82,55);
            ConversionRows[15] = new ConvertedScoreRow(81,55);
            ConversionRows[16] = new ConvertedScoreRow(81,55);
            ConversionRows[17] = new ConvertedScoreRow(80,56);
            ConversionRows[18] = new ConvertedScoreRow(80,56);
            ConversionRows[19] = new ConvertedScoreRow(79,56);
            ConversionRows[20] = new ConvertedScoreRow(78,57);
            ConversionRows[21] = new ConvertedScoreRow(78,57);
            ConversionRows[22] = new ConvertedScoreRow(77,57);
            ConversionRows[23] = new ConvertedScoreRow(77,58);
            ConversionRows[24] = new ConvertedScoreRow(76,58);
            ConversionRows[25] = new ConvertedScoreRow(76,58);
            ConversionRows[26] = new ConvertedScoreRow(75,59);
            ConversionRows[27] = new ConvertedScoreRow(74,59);
            ConversionRows[28] = new ConvertedScoreRow(74,59);
            ConversionRows[29] = new ConvertedScoreRow(73,60);
            ConversionRows[30] = new ConvertedScoreRow(73,60);
            ConversionRows[31] = new ConvertedScoreRow(72,60);
            ConversionRows[32] = new ConvertedScoreRow(71,61);

            ConversionRows[33] = new ConvertedScoreRow(71,61);
            ConversionRows[34] = new ConvertedScoreRow(70,61);
            ConversionRows[35] = new ConvertedScoreRow(60,62);
            ConversionRows[36] = new ConvertedScoreRow(69,62);
            ConversionRows[37] = new ConvertedScoreRow(68,62);
            ConversionRows[38] = new ConvertedScoreRow(68,63);
            ConversionRows[39] = new ConvertedScoreRow(67,63);
            ConversionRows[40] = new ConvertedScoreRow(66,63);
            ConversionRows[41] = new ConvertedScoreRow(66,64);
            ConversionRows[42] = new ConvertedScoreRow(65,64);
            ConversionRows[43] = new ConvertedScoreRow(65,64);
            ConversionRows[44] = new ConvertedScoreRow(64,65);
            ConversionRows[45] = new ConvertedScoreRow(63,65);
            ConversionRows[46] = new ConvertedScoreRow(63,65);
            ConversionRows[47] = new ConvertedScoreRow(62,66);
            ConversionRows[48] = new ConvertedScoreRow(61,66);
            ConversionRows[49] = new ConvertedScoreRow(61,66);
            ConversionRows[50] = new ConvertedScoreRow(50,67);
            ConversionRows[51] = new ConvertedScoreRow(59,67);
            ConversionRows[52] = new ConvertedScoreRow(59,67);
            ConversionRows[53] = new ConvertedScoreRow(58,68);
            ConversionRows[54] = new ConvertedScoreRow(57,68);
            ConversionRows[55] = new ConvertedScoreRow(57,69);
            ConversionRows[56] = new ConvertedScoreRow(56,69);
            ConversionRows[57] = new ConvertedScoreRow(55,69);
            ConversionRows[58] = new ConvertedScoreRow(55,70);
            ConversionRows[59] = new ConvertedScoreRow(54,70);
            ConversionRows[60] = new ConvertedScoreRow(53,71);
            ConversionRows[61] = new ConvertedScoreRow(52,71);
            ConversionRows[62] = new ConvertedScoreRow(52,71);
            ConversionRows[63] = new ConvertedScoreRow(51,72);
            ConversionRows[64] = new ConvertedScoreRow(50,72);
            ConversionRows[65] = new ConvertedScoreRow(49,73);
            ConversionRows[66] = new ConvertedScoreRow(49,73);

            ConversionRows[67] = new ConvertedScoreRow(48,7);
            ConversionRows[68] = new ConvertedScoreRow(47,7);
            ConversionRows[69] = new ConvertedScoreRow(46,7);
            ConversionRows[70] = new ConvertedScoreRow(46,7);
            ConversionRows[71] = new ConvertedScoreRow(45,7);
            ConversionRows[72] = new ConvertedScoreRow(44,7);
            ConversionRows[73] = new ConvertedScoreRow(43,7);
            ConversionRows[74] = new ConvertedScoreRow(42,7);
            ConversionRows[75] = new ConvertedScoreRow(41,7);
            ConversionRows[76] = new ConvertedScoreRow(41,7);
            ConversionRows[77] = new ConvertedScoreRow(40,7);
            ConversionRows[78] = new ConvertedScoreRow(39,7);
            ConversionRows[79] = new ConvertedScoreRow(38,7);
            ConversionRows[80] = new ConvertedScoreRow(37,8);
            ConversionRows[81] = new ConvertedScoreRow(36,8);
            ConversionRows[82] = new ConvertedScoreRow(35,8);
            ConversionRows[83] = new ConvertedScoreRow(34,8);
            ConversionRows[84] = new ConvertedScoreRow(33,8);
            ConversionRows[85] = new ConvertedScoreRow(32,8);
            ConversionRows[86] = new ConvertedScoreRow(31,8);
            ConversionRows[87] = new ConvertedScoreRow(30,8);
            ConversionRows[88] = new ConvertedScoreRow(28,8);
            ConversionRows[89] = new ConvertedScoreRow(27,8);
            ConversionRows[90] = new ConvertedScoreRow(26,8);
            ConversionRows[91] = new ConvertedScoreRow(25,8);
            ConversionRows[92] = new ConvertedScoreRow(23,8);
            ConversionRows[93] = new ConvertedScoreRow(22,8);
            ConversionRows[94] = new ConvertedScoreRow(20,8);
            ConversionRows[95] = new ConvertedScoreRow(18,9);
            ConversionRows[96] = new ConvertedScoreRow(16,9);
            ConversionRows[97] = new ConvertedScoreRow(14,9);
            ConversionRows[98] = new ConvertedScoreRow(11,9);
            ConversionRows[99] = new ConvertedScoreRow(8,9);
            ConversionRows[100] = new ConvertedScoreRow(0,100);
        }
    }
}
