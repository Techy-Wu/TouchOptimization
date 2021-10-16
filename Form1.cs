using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;
//for time
using System.Threading;
//for control
using OFFICECORE = Microsoft.Office.Core;
using System.Windows;

namespace Touch_Slides_Optimization
{
    public partial class Form1 : Form
    {
        //click timer
        long a, b;
        //RightMenu
        bool Rmemuing = false;
        //chosing
        bool Chosing = false;

        //<sendmessage>
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int Iparam);
        //</sendmessage>

        //<findwindow>
        //[DllImport("user32.dll", EntryPoint = "FindWindow")]
        //private static extern IntPtr FindWindow(string IpClassName, string IpWindowsName);
        //</findwindow>

        //<GetForegroundWindow>
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        //</GetForegroundWindow>

        //<WindowFormPoint>
        [DllImport("user32.dll", EntryPoint = "WindowFromPoint")]//指定坐标处窗体句柄
        public static extern IntPtr WindowFromPoint(int xPoint, int yPoint);
        //</WindowFormPoint>

        //<SetWindowPos>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        //<\SetWindowPos>

        //<SetFocus>
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetFocus(IntPtr hWnd);
        //</SetFocus>

        //<Keybd>
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(
            byte bVk,    //虚拟键值
            byte bScan,// 一般为0
            int dwFlags,  //这里是整数类型  0 为按下，2为释放
            int dwExtraInfo  //这里是整数类型 一般情况下设成为 0
        );
        //</Keybd>

        //<MouseSimulator>
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        //移动鼠标 
        const int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        //</MouseSimulator>

        int down_ms, down_s, up_ms, up_s;
        Form chs = new Chose();

        public Form1()
        {
            InitializeComponent();
        }

        int toIparam(int x, int y)
        {
            return x + (y << 16);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //choosing -> 用form1拦截一切操作
            if (Chosing == true)
                return;

            /* 以往版本代码
            if (e.Button == MouseButtons.Left)
                runit(2);
            else if (e.Button == MouseButtons.Right)
                runit(1);
            */

            if (e.Button == MouseButtons.Left)
            {
                //Rmenuing -> 以当前操作关闭右键菜单
                if(Rmemuing == true)
                {
                    Rmemuing = false;
                    this.contextMenuStrip1.Close();
                    refresh_Z();
                    return;
                }
                
                switch (GlobalClass.straight_back)
                {
                    case true:
                        SetFocus(GlobalClass.slide_show_window);
                        keybd_event((byte)Keys.Up, 0, 0, 0);
                        keybd_event((byte)Keys.Up, 0, 2, 0);
                        break;

                    case false:
                        SetFocus(GlobalClass.slide_show_window);
                        keybd_event((byte)Keys.Down, 0, 0, 0);
                        keybd_event((byte)Keys.Down, 0, 2, 0);
                        break;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                Rmemuing = true;
            }
        }

        private void Form1_GotFocus(object sender, EventArgs e)
        {
            timer_detector.Stop();
            refresh_Z();
        }

        private void Form1_LostFocus(object sender, EventArgs e)
        {
            if (GlobalClass.active == false)
                return;

            timer_detector.Start();
            timer_detector.Enabled = true;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (GlobalClass.tmode == true || GlobalClass.straight_back == true)
                this.Opacity = 0.40;
            else
                this.Opacity = 0.01;

            if(Rmemuing == false)
                SetFocus(GlobalClass.slide_show_window);

            if (GlobalClass.tmode == true)
                this.label1.Text = "Test Mode \n" + GlobalClass.version;
        }

        private void 上一张ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rmemuing = false;
            SetFocus(GlobalClass.slide_show_window);
            keybd_event((byte)Keys.Up, 0, 0, 0);
            keybd_event((byte)Keys.Up, 0, 2, 0);
            return;
        }

        private void 结束放映ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rmemuing = false;
            SetFocus(GlobalClass.slide_show_window);
            keybd_event((byte)Keys.Escape, 0, 0, 0);
            keybd_event((byte)Keys.Escape, 0, 2, 0);
            return;
        }

        private void 下一张ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rmemuing = false;
            SetFocus(GlobalClass.slide_show_window);
            keybd_event((byte)Keys.Down, 0, 0, 0);
            keybd_event((byte)Keys.Down, 0, 2, 0);
            return;
        }

        private void 连续回退ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rmemuing = false;
            GlobalClass.straight_back = !GlobalClass.straight_back;
            if (GlobalClass.straight_back == true)
            {
                this.Opacity = 0.40;
                this.连续回退ToolStripMenuItem.BackColor = Color.Gray;
                this.label1.Text = "连续回退模式，单击以回退幻灯片\n长按唤出放映菜单以退出连续回退模式";
            }
            else
            {
                this.Opacity = 0.01;
                this.连续回退ToolStripMenuItem.BackColor = Color.White;
                this.label1.Text = string.Empty;
            }
            this.TopMost = true;
            SetFocus(GlobalClass.slide_show_window);
        }

        private void 停用触控优化加载项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定停用 触控优化 加载项吗？\n 若嵌入的媒体无法播放请停用\n 停用后您将使用滑动手势翻页", "Touch Optimization_[提示]", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                GlobalClass.active = false;
                this.Hide();
            }
            else if (result == DialogResult.Cancel)
                GlobalClass.active = true;

            Rmemuing = false;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.TopMost = false;

            Chosing = true;
            chs.Show();

            chs.FormClosing += Chs_FormClosing;
        }

        private void Chs_FormClosing(object sender, FormClosingEventArgs e)
        {
            Chosing = false;

            this.TopMost = true;
            this.Hide();

            if (GlobalClass.active == true)
                this.Show();
            else
                this.Hide();

            SetFocus(GlobalClass.slide_show_window);
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            //while (this.Focused == false && chs.Focused == false)
            //    SetFocus(this.Handle);
        }

        void refresh_Z()
        {
            this.TopMost = true;
            SetFocus(GlobalClass.slide_show_window);
            SetWindowPos(GlobalClass.slide_show_window, 0, 0, 0, 0, 0, 1 | 2);
            SetWindowPos(this.Handle, -2, 0, 0, 0, 0, 1 | 2);
        }

        private void Timer_detector_Tick(object sender, EventArgs e)
        {
            if (GlobalClass.active == false || GlobalClass.slide_show_on == false)
                return;

            if (GetForegroundWindow()
                == GlobalClass.slide_show_window &&
                WindowFromPoint(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2)
                == GlobalClass.slide_show_window)
                refresh_Z();
        }

        private void State_timer_Tick(object sender, EventArgs e)
        {
            switch(GlobalClass.straight_back)
            {
                case true:
                    this.连续回退ToolStripMenuItem.BackColor = Color.Gray;
                    break;

                case false:
                    this.连续回退ToolStripMenuItem.BackColor = Color.White;
                    break;
            }
        }

        int String_to_Int(string temp)
        {
            int ans = 0;
            switch (temp.Length.ToString())
            {
                case "3":
                    for (int i = 0; i < 3; i++)
                    {
                        ans += temp[i] - '0';
                        ans *= 10;
                    }
                    ans /= 10;
                    break;

                case "2":
                    for (int i = 0; i < 2; i++)
                    {
                        ans += temp[i] - '0';
                        ans *= 10;
                    }
                    ans /= 10;
                    break;

                case "1":
                    ans += temp[0] - '0';
                    break;
            }
            return ans;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            //this.TopMost = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            label1.Text = string.Empty;
            this.连续回退ToolStripMenuItem.BackColor = Color.White;

            state_timer.Start();

            refresh_Z();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            return;
            /*
            if (e.Button == MouseButtons.Right)
                runit(1);
            else if (e.Button == MouseButtons.Left)
                runit(2);
            */

            /*
            //get down time
            down_ms = String_to_Int(DateTime.Now.Millisecond.ToString());
            down_s = String_to_Int(DateTime.Now.Second.ToString());
            */
        }

        /*
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //get up time
            up_ms = String_to_Int(DateTime.Now.Millisecond.ToString());
            up_s = String_to_Int(DateTime.Now.Second.ToString());

            //compare && process
            up_ms += (up_s < down_s ? 60 - down_s + up_s : up_s - down_s) * 1000;
            if((up_ms < down_ms? 1000 - down_ms + up_ms: up_ms - down_ms)>=1000)
            {
                //long press
                this.label1.Text = "Long Press";
                runit(1);
            }
            else
            {
                //short press
                this.label1.Text = "Short Press";
                runit(2);
            }
        }
        */

        void runit(int type)
        {
            //operate list
            const int WM_LBUTTONDOWN = 0x201;
            const int WM_LBUTTONUP = 0x202;
            const int WM_RBUTTONDOWN = 0x204;
            const int WM_RBUTTONUP = 0x205;

            int x = Control.MousePosition.X;
            int y = Control.MousePosition.Y;
            //for test
            if(GlobalClass.tmode == true)
                MessageBox.Show("x = " + x.ToString() + ", y = " + y.ToString());

            //search
            IntPtr maindHwnd;
            this.Hide();
            maindHwnd = WindowFromPoint(x, y);
            //for test
            if (GlobalClass.tmode == true)
                MessageBox.Show("Found in " + maindHwnd.ToString());

            //doit
            if (maindHwnd != IntPtr.Zero)
            {
                //found

                //give focus
                SetFocus(maindHwnd);

                //simulalte mouse
                mouse_event(MOUSEEVENTF_MOVE, 5, -5, 0, 0);
                Thread.Sleep(50);
                mouse_event(MOUSEEVENTF_MOVE, -5, 5, 0, 0);

                //deal
                switch (type)
                {
                case 1:
                    //long press
                    SendMessage(maindHwnd, WM_RBUTTONDOWN, 0, toIparam(x, y));
                    Thread.Sleep(50);
                    SendMessage(maindHwnd, WM_RBUTTONUP, 0, toIparam(x, y));

                    break;

                case 2:
                    //short press
                    SendMessage(maindHwnd, WM_LBUTTONDOWN, 0, toIparam(x, y));
                    Thread.Sleep(50);
                    SendMessage(maindHwnd, WM_LBUTTONUP, 0, toIparam(x, y));
                    break;
                }
                label1.Text = string.Empty;
            }
            else
            {
                //missed
                MessageBox.Show("Error, Touch Optimization cannot found PowerPoint programe.");
            }
        }
    }
}
