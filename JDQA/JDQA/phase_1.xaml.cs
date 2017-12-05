using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JDQA
{
    /// <summary>
    /// Interaction logic for phase_1.xaml
    /// </summary>
    public partial class Phase_1 : Page
    {
        public Phase_1()
        {
            InitializeComponent();
        }

        private void downloadShortForm(object sender, RoutedEventArgs e) {
            try 
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "phase1_shortform.pdf";
                sfd.ShowDialog();

                savedAs.Content = "Saved As: " + sfd.FileName;
                Document doc = new Document(PageSize.LETTER);

                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                Font times = new Font(bfTimes, 12);

                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                doc.Open();
        
            //write file
            doc.Add(new Paragraph("Position Being Rated: __________________",times));
            doc.Add(new Paragraph("Your Name: __________________", times));
            doc.Add(new Paragraph("Your Title: __________________", times));
            doc.Add(new Paragraph("Today's Date: __________________", times));

                doc.Add(new Paragraph("Are you currently in this position? Yes___ No___", times));
                doc.Add(new Paragraph("Have you ever been in this position? Yes___ No___", times));
                doc.Add(new Paragraph("If No, do you manage this position? Yes___ No___", times));
            

            string formBody = "\r\n Instructions: (1) Place an <X> beside each statement that you feel is important " +
                "in describing the above position.  (2) Then go back and circle the ten X's which you feel are the most important aspects of the " +
                "above position. (3) Finally,  DARKEN THE CIRCLE OF THE SINGLE MOST IMPORTANT one. Note: Every word in the statement must match the job requirements \r\n\r\n ";
            List options = new List(List.UNORDERED);
                options.SetListSymbol("____ ");
            options.Add(new ListItem("1. Being good at meeting new people quite often.\r\n",times));
            options.Add(new ListItem("2. Sticking to established policies and procedures.\r\n",times));
            options.Add(new ListItem("3. Being cooperative with other people.\r\n",times));
                options.Add(new ListItem("4. Being highly logical and analytical.\r\n"));
            options.Add(new ListItem("5. Working quickly on a variety of different tasks.\r\n",times));
            options.Add(new ListItem("6. Being demanding of other people.\r\n",times));
            options.Add(new ListItem("7. Assembling Equipment.\r\n",times));
            options.Add(new ListItem("8. Calling on present customers on a regular, routine basis and obtaining repeat sales.\r\n",times));
            options.Add(new ListItem("9. Following orders precisely.\r\n",times));
            options.Add(new ListItem("10. Readily taking responsibility for making major decisions on a corporate level.\r\n",times));
            options.Add(new ListItem("11. Being able to verbally illustrate points effectively, to be a good speaker.\r\n",times));
            options.Add(new ListItem("12. Sitting or standing in one spot for most of the day.\r\n",times));
            options.Add(new ListItem("13. Working with practically no contact with other people.\r\n",times));
            options.Add(new ListItem("14. Inspecting the quality of work being performed by others.\r\n",times));
            options.Add(new ListItem("15. Working from a manual, formula, standard or precise instructions.\r\n",times));
            options.Add(new ListItem("16. Socializing and talking with others easily.\r\n",times));
            options.Add(new ListItem("17. Operating machinery in a careful manner.\r\n",times));
            options.Add(new ListItem("18. Taking the initiative by seeking out potential customers and opening new accounts by making original          sales.\r\n",times));
            options.Add(new ListItem("19. Entertaining others.\r\n",times));
            options.Add(new ListItem("20. Designing, creating, inventing or originating new products, ideas, or theories.\r\n",times));
            options.Add(new ListItem("21. Being able to locate source data from reference materials.\r\n",times));
            options.Add(new ListItem("22. Selling products to customers over the counter.\r\n",times));
            options.Add(new ListItem("23. Being happy and likeable at all times to almost everyone.\r\n",times));
            options.Add(new ListItem("24. Being very considerate in taking care of other people's needs and/or providing personal service to others.\r\n",times));
            options.Add(new ListItem("25. Concentrating on a limited area or on a few items for long periods of time.\r\n",times));
            options.Add(new ListItem("26. Teaching Others. \r\n",times));
            options.Add(new ListItem("27. Extensive traveling.\r\n",times));
            options.Add(new ListItem("28. Making large numbers of personal contacts daily.\r\n",times));
            options.Add(new ListItem("29. Being restless and having a high degree of nervous energy and drive, always being on the go.\r\n",times));
            options.Add(new ListItem("30. A good personal appearance at all times.\r\n",times));
            options.Add(new ListItem("31. Exercising good critical judgement.\r\n",times));
            options.Add(new ListItem("32. Getting things done promptly.\r\n",times));
            options.Add(new ListItem("33. Being watchful, carefully checking out details.\r\n",times));
            options.Add(new ListItem("34. Being able to break up tense moments with humor or amusing comments.\r\n",times));
            options.Add(new ListItem("35. The ability to communicate well, to get important points across.\r\n",times));
            options.Add(new ListItem("36. Selling products to customers who visit stores or showrooms.\r\n",times));
            options.Add(new ListItem("37. Being more effective in dealing with people by phone or letter than in person.\r\n",times));
            options.Add(new ListItem("38. Keeping an orderly account of specific items and/or amounts.\r\n",times));
            options.Add(new ListItem("39. Making presentations or giving speeches to both large and small groups of people.\r\n",times));
            options.Add(new ListItem("40. Working in a small group of people.\r\n",times));
            options.Add(new ListItem("41. The ability to say no with confidence. \r\n",times));
            options.Add(new ListItem("42. Checking and double checking own work.\r\n",times));
            options.Add(new ListItem("43. An above average level of honesty, confidence and integrity in situations involving the handling of              money, valuable materials or information of a private, secret, or confidential nature.\r\n",times));
            options.Add(new ListItem("44. Being self-assured and confident when dealing with others.\r\n",times));
            options.Add(new ListItem("45. Being calm and controlled when performing tasks.\r\n",times));
            options.Add(new ListItem("46. The ability to sell intangibles.\r\n",times));
            options.Add(new ListItem("47. Solving problems through original research and/or through investigation of previous work.\r\n",times));
            options.Add(new ListItem("48. Referring all questionable matters to supervisor.  To go by the book.\r\n",times));
            options.Add(new ListItem("49. A highly persuasive talker.\r\n",times));
            options.Add(new ListItem("50. Doing the same thing over and over.\r\n",times));
            options.Add(new ListItem("51. Leading meetings in which reliance upon memory and great verbal agility is required.\r\n",times));
            options.Add(new ListItem("52. A very high degree of precision on detailed work.\r\n",times));
            options.Add(new ListItem("53. Little need for accuracy. All work is checked by others.\r\n",times));
            options.Add(new ListItem("54. Performing manual labor tasks of a fairly simple nature.\r\n",times));
            options.Add(new ListItem("55. Being kind and sympathetic to others.\r\n",times));
            doc.Add(new iTextSharp.text.Paragraph(formBody,times));
            doc.Add(options);
            doc.Close();
            }
            catch (System.IO.IOException exception)
            {
                MessageBox.Show("That File is Currently In Use.  Please Choose another filename or close the file");
                downloadShortForm(sender, e);
            }

        }

        private void processShortForms(object sender, RoutedEventArgs e) {
            ProcessShortForm processShortForm = new ProcessShortForm(new List<Classes.Phase1Selections>() { });

            NavigationService.Navigate(processShortForm);
        }
    }


}
