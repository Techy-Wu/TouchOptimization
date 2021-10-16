namespace Touch_Slides_Optimization
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tab2 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.label4 = this.Factory.CreateRibbonLabel();
            this.label5 = this.Factory.CreateRibbonLabel();
            this.label6 = this.Factory.CreateRibbonLabel();
            this.button1 = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.button2 = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.button3 = this.Factory.CreateRibbonButton();
            this.state_timer = new System.Windows.Forms.Timer(this.components);
            this.tab2.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab2
            // 
            this.tab2.Groups.Add(this.group1);
            this.tab2.Groups.Add(this.group2);
            this.tab2.Groups.Add(this.group3);
            this.tab2.Label = "触控优化";
            this.tab2.Name = "tab2";
            // 
            // group1
            // 
            this.group1.Items.Add(this.label4);
            this.group1.Items.Add(this.label5);
            this.group1.Items.Add(this.label6);
            this.group1.Items.Add(this.button1);
            this.group1.Label = "关于此加载项";
            this.group1.Name = "group1";
            // 
            // label4
            // 
            this.label4.Label = "This AddIn help the users of the touchable divices to pagedown the slides with on" +
    "ly a touch.";
            this.label4.Name = "label4";
            // 
            // label5
            // 
            this.label5.Label = "(C)Techy Wu, All rights reserved.";
            this.label5.Name = "label5";
            this.label5.Tag = "";
            // 
            // label6
            // 
            this.label6.Label = "Techy_Wu@outlook.com";
            this.label6.Name = "label6";
            // 
            // button1
            // 
            this.button1.Label = "More Info";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button1_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.button2);
            this.group2.Label = "状态";
            this.group2.Name = "group2";
            // 
            // button2
            // 
            this.button2.Label = "Active State";
            this.button2.Name = "button2";
            this.button2.SuperTip = "Click to change the state";
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button2_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.button3);
            this.group3.Label = "Test";
            this.group3.Name = "group3";
            this.group3.Visible = false;
            // 
            // button3
            // 
            this.button3.Label = "Test State";
            this.button3.Name = "button3";
            this.button3.SuperTip = "Click to change the state";
            this.button3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Button3_Click);
            // 
            // state_timer
            // 
            this.state_timer.Enabled = true;
            this.state_timer.Tick += new System.EventHandler(this.State_timer_Tick);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab2);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label4;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label5;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        private System.Windows.Forms.Timer state_timer;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
