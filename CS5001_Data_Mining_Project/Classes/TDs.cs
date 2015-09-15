using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CS5001_Data_Mining_Project.Classes
{
    public static class TDs
    {
        public static void Test_Arff_CountFrequency()
        {
            string tmp = "";
            MessageBox.Show("Use Weather Nominal.arff");
            using (OpenFileDialog newOFD=new OpenFileDialog())
            {
                if (newOFD.ShowDialog() == DialogResult.OK)
                {
                    tmp = newOFD.FileName;
                }
            }
            Arff tmp2 = new Arff(File.ReadAllText(tmp));

            Condition c1 = new Condition("outlook", "overcast");
            //Condition c2 = new Condition("temperature", "hot");
            //Condition c3 = new Condition("humidity", "high");
            List<Condition> c = new List<Condition>(); c.Add(c1); 
            //c.Add(c2); 
            //c.Add(c3);
            
            int count=tmp2.CountFrequency(new Item(c, 0));

            MessageBox.Show(string.Format("{0} appears {1} times",
                c1.ToString(), count));
        }
        public static void Test_ItemSet_ItemSetConstructor()
        {
            string tmp = "";
            using (OpenFileDialog newOFD = new OpenFileDialog())
            {
                if (newOFD.ShowDialog() == DialogResult.OK)
                {
                    tmp = newOFD.FileName;
                }
            }
            Arff tmp2 = new Arff(File.ReadAllText(tmp));
            ItemSet tmp3 = new ItemSet(tmp2);
        }
        public static void Test_ItemSet_MeetMinimumCoverage()
        {
            string tmp = "";
            using (OpenFileDialog newOFD = new OpenFileDialog())
            {
                if (newOFD.ShowDialog() == DialogResult.OK)
                {
                    tmp = newOFD.FileName;
                }
            }
            Arff tmp2 = new Arff(File.ReadAllText(tmp));
            ItemSet tmp3 = new ItemSet(tmp2);
            tmp3.MeetMinimumCoverage(6);
            tmp3.OrderByFrequencyDescending();
        }
        public static void Test_FPTree_Constructor()
        {
            string path = "";
            using (OpenFileDialog newOFD = new OpenFileDialog())
            {
                if (newOFD.ShowDialog() == DialogResult.OK)
                {
                    path = newOFD.FileName;
                }
            }
            Arff source = new Arff(File.ReadAllText(path));
            FPTree FPTree = new FPTree(source, 6, 0, 0, 0);
        }
    }
}
