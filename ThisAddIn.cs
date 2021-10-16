using System;
using System.Windows.Forms;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
//for form
using System.Drawing;
//for time
using System.Threading;
//for find
using System.Runtime.InteropServices;

namespace Touch_Slides_Optimization
{
    public partial class ThisAddIn
    {
        //<WindowFormPoint>
        [DllImport("user32.dll", EntryPoint = "WindowFromPoint")]//指定坐标处窗体句柄
        public static extern IntPtr WindowFromPoint(int xPoint, int yPoint);
        //</WindowFormPoint>

        //<GetForegroundWindow>
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        //</GetForegroundWindow>

        Form frm = new Form1();
        int m;

        public void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.SlideShowBegin += App_SlideShowBegin;
            this.Application.SlideShowEnd += Application_SlideShowEnd;

            frm.FormClosing += Frm_FormClosing;

            return;
        }

        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.Hide();
            return;
            throw new NotImplementedException();
        }

        private void App_SlideShowBegin(PowerPoint.SlideShowWindow Wn)
        {
            GlobalClass.slide_show_on = true;
            GlobalClass.straight_back = false;

            if (GlobalClass.active == false)
                return;

            GlobalClass.slide_show_window = WindowFromPoint(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
            //GlobalClass.slide_show_window = GetForegroundWindow();
            //for test
            if (GlobalClass.tmode == true)
                MessageBox.Show("Slide Show in " + WindowFromPoint(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 ).ToString());

            Size s = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            frm.Show();
            frm.Activate();
            frm.Size = s;
            frm.Top = 0;
            frm.Left = 0;

            Application.SlideShowNextClick += Application_SlideShowNextClick;

            return;
            throw new NotImplementedException();
        }

        private void Application_SlideShowNextClick(PowerPoint.SlideShowWindow Wn, PowerPoint.Effect nEffect)
        {
            if (GlobalClass.active == false)
            {
                frm.Hide();
                return;
            }

            GlobalClass.next_builing = true;

            int n = 0;
            m = 0;
            Application.SlideShowNextBuild += Application_SlideShowNextBuild;
            while(m == n)
            {
                Thread.Sleep(10);
                n++;
            }

            GlobalClass.next_builing = false;

            frm.Show();
            frm.Activate();
            frm.Focus();
            return;
            throw new NotImplementedException();
        }

        private void Application_SlideShowNextBuild(PowerPoint.SlideShowWindow Wn)
        {
            m++;
            return;
            throw new NotImplementedException();
        }

        private void Application_SlideShowEnd(PowerPoint.Presentation Pres)
        {
            GlobalClass.slide_show_on = false;
            frm.Hide();

            return;
            throw new NotImplementedException();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            frm.Close();
            return;
        }

        #region VSTO 生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
