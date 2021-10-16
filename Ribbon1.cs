using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace Touch_Slides_Optimization
{
    partial class Ribbon1
    {
        public void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            state_timer.Start();

            button3.Label = " { } ";
        }

        private void Button1_Click(object sender, RibbonControlEventArgs e)
        {
            Form wlc = new Welcome();
            wlc.Show();

            wlc.FormClosing += Wlc_FormClosing;
        }

        private void Wlc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GlobalClass.active == false)
                button2.Label = "禁用";
            else
                button2.Label = "启用";
            return;
        }

        private void Button2_Click(object sender, RibbonControlEventArgs e)
        {
            if (GlobalClass.active == true)
            {
                button2.Label = "禁用";
                if(GlobalClass.tmode == true)
                {
                    GlobalClass.tmode = false;
                    button3.Label = "Normal";
                }
            }
            else
            {
                button2.Label = "启用";
            }
            GlobalClass.active = !GlobalClass.active;
            GlobalClass.chosed = true;
            return;
        }

        private void Button3_Click(object sender, RibbonControlEventArgs e)
        {
            if (GlobalClass.tmode == true)
            {
                button3.Label = "Normal";
            } 
            else
            {
                button3.Label = "Testing";
                if (GlobalClass.active == false)
                {
                    GlobalClass.active = true;
                    button2.Label = "启用";
                }
            }
            GlobalClass.tmode = !GlobalClass.tmode;
            return;
        }

        private void State_timer_Tick(object sender, EventArgs e)
        {
            if (GlobalClass.active == false)
                button2.Label = "禁用";
            else
                button2.Label = "启用";
        }
    }
}
