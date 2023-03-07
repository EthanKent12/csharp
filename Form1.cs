using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign5
{
    public partial class Form1 : Form
    {
        private string[] areaCode = {"236", "250", "778", "507", "780", "805", "403",
                                     "587", "825", "306", "639", "204", "432", "807",
                                     "249", "705", "226", "519", "548", "709"};
        private double[] rate = { .05, .05, .05, .03, .03, .03, .04, .06, .06, .06,
                                  .08, .08, .08, .09, .09, .09, .10, .10, .12, .14};

        private int[] minTime = { 3, 3, 3, 0, 0, 0, 5, 5, 5, 2,
                                  2, 2, 4, 4, 4, 6, 6, 6, 8, 9};

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Shutdown the painting of the comboBox as items are added.
            comboBox1.BeginUpdate();


            //load comboBox with the area codes
            //use the method comboBox1.Items.Add("403");
            string[] areaCodes = { "403", "587", "825", "780" };
            foreach (string code in areaCodes)
            {
                comboBox1.Items.Add(code);
            }

            // Allow the comboBox to repaint and display the new items.
            comboBox1.EndUpdate();
        }


        // comboBox was changed - calculate the charges for the phone call
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            label3.Text = rate[index].ToString("C");
            label4.Text = minTime[index].ToString() + " min";
            string Duration = (string)lengthBox.Text;
            int duration = int.Parse(Duration);
            double chargeRate = rate[index];
            double minDuration = minTime[index];
            double totalCharge;

            if (duration <= minDuration)
            {
                totalCharge = chargeRate * duration;
            }
            else
            {
                totalCharge = chargeRate * (duration - minDuration) + chargeRate * minDuration;
            }

            label5.Text = totalCharge.ToString("C");
        }

        private void lengthBox_TextChanged(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(sender, e);
        }
    }
}
