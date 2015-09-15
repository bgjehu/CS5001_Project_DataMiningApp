using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS5001_Data_Mining_Project
{
    public partial class AprioriFRM : Form
    {
        //variables
        string filePath;

        public AprioriFRM()
        {
            InitializeComponent();
        }

        /*  
         *  ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
         *  ┃    Browse Button Click Event Handler   ┃
         *  ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛
         */
        private void browseBTN_Click(object sender, EventArgs e)
        {
            //if file is selected
            if (fileOFD.ShowDialog() == DialogResult.OK)
            {
                //store input file path
                filePath = fileOFD.FileName;

                //detect file extension
                if (filePath.Substring(filePath.Length - 4) == "arff")
                {
                    //the extension is arff
                    //reflect path onto the textBox
                    fileTB.Text = filePath;

                    //enable submit button
                    submitBTN.Enabled = true;
                }
                else
                {
                    //the extension is not arff
                    //show error message
                    MessageBox.Show("Input has to be arff file!");
                    //reset filePath
                    filePath = "";
                }
            }
        }
    }
}
