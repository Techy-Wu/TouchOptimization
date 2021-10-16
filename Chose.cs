using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//for time
using System.Threading;

namespace Touch_Slides_Optimization
{
    public partial class Chose : Form
    {
        int t = 20;

        public Chose()
        {
            InitializeComponent();
        }

        void chose(int a)
        {
            GlobalClass.chosed = true;
            label6.Visible = false;
            timer1.Stop();

            switch(a)
            {
                case 1:
                    GlobalClass.active = true;
                    break;

                case 2:
                    GlobalClass.active = false;
                    break;
            }

            this.Close();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            chose(1);
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            chose(2);
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            chose(1);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            chose(2);
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {
            chose(1);
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {
            chose(2);
        }

        private void Chose_Load(object sender, EventArgs e)
        {
            GlobalClass.active = false;
            label6.Text = t.ToString() + "s";
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            t--;
            label6.Text = t.ToString() + "s";

            if (t == 0 && label6.Visible == true)
                chose(2);
        }

        private void Chose_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label6.Visible = false;
        }
    }
}
