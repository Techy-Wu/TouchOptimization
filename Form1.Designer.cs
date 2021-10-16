namespace Touch_Slides_Optimization
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.上一张ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连续回退ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下一张ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.结束放映ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.停用触控优化加载项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_detector = new System.Windows.Forms.Timer(this.components);
            this.state_timer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上一张ToolStripMenuItem,
            this.连续回退ToolStripMenuItem,
            this.下一张ToolStripMenuItem,
            this.toolStripSeparator1,
            this.结束放映ToolStripMenuItem,
            this.toolStripSeparator2,
            this.停用触控优化加载项ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(222, 136);
            // 
            // 上一张ToolStripMenuItem
            // 
            this.上一张ToolStripMenuItem.Name = "上一张ToolStripMenuItem";
            this.上一张ToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.上一张ToolStripMenuItem.Text = "上一张";
            this.上一张ToolStripMenuItem.Click += new System.EventHandler(this.上一张ToolStripMenuItem_Click);
            // 
            // 连续回退ToolStripMenuItem
            // 
            this.连续回退ToolStripMenuItem.Name = "连续回退ToolStripMenuItem";
            this.连续回退ToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.连续回退ToolStripMenuItem.Text = "连续回退";
            this.连续回退ToolStripMenuItem.Click += new System.EventHandler(this.连续回退ToolStripMenuItem_Click);
            // 
            // 下一张ToolStripMenuItem
            // 
            this.下一张ToolStripMenuItem.Name = "下一张ToolStripMenuItem";
            this.下一张ToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.下一张ToolStripMenuItem.Text = "下一张";
            this.下一张ToolStripMenuItem.Click += new System.EventHandler(this.下一张ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // 结束放映ToolStripMenuItem
            // 
            this.结束放映ToolStripMenuItem.Name = "结束放映ToolStripMenuItem";
            this.结束放映ToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.结束放映ToolStripMenuItem.Text = "结束放映";
            this.结束放映ToolStripMenuItem.Click += new System.EventHandler(this.结束放映ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(218, 6);
            // 
            // 停用触控优化加载项ToolStripMenuItem
            // 
            this.停用触控优化加载项ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.停用触控优化加载项ToolStripMenuItem.Name = "停用触控优化加载项ToolStripMenuItem";
            this.停用触控优化加载项ToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.停用触控优化加载项ToolStripMenuItem.Text = "停用 触控优化 加载项";
            this.停用触控优化加载项ToolStripMenuItem.Click += new System.EventHandler(this.停用触控优化加载项ToolStripMenuItem_Click);
            // 
            // timer_detector
            // 
            this.timer_detector.Enabled = true;
            this.timer_detector.Interval = 30;
            this.timer_detector.Tick += new System.EventHandler(this.Timer_detector_Tick);
            // 
            // state_timer
            // 
            this.state_timer.Tick += new System.EventHandler(this.State_timer_Tick);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(812, 454);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Opacity = 0.1D;
            this.ShowIcon = false;
            this.Text = "Touch Optimazation";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.GotFocus += new System.EventHandler(this.Form1_GotFocus);
            this.LostFocus += new System.EventHandler(this.Form1_LostFocus);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 上一张ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连续回退ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下一张ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束放映ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停用触控优化加载项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Timer timer_detector;
        private System.Windows.Forms.Timer state_timer;
    }
}