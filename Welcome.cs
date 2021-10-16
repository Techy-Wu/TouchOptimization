using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Touch_Slides_Optimization
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            label2.Text = "v" + GlobalClass.version;

            if (GlobalClass.active == true)
                button2.Text = "暂停服务";
            else
                button2.Text = "激活服务";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(GlobalClass.active == true)
            {
                GlobalClass.active = false;
                button2.Text = "激活服务";
            }
            else
            {
                GlobalClass.active = true;
                button2.Text = "暂停服务";
            }
            GlobalClass.chosed = true;
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            Form abbox = new AboutBox1();
            abbox.Show();
        }
    }
}
