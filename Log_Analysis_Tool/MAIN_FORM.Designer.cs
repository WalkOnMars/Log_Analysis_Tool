namespace Log_Analysis_Tool
{
    partial class MAIN_FORM
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.索引设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CKB_REPORT = new System.Windows.Forms.CheckBox();
            this.CKB_COLLECT = new System.Windows.Forms.CheckBox();
            this.TXB_TARGET_DIR = new System.Windows.Forms.TextBox();
            this.TEXTBOX_FILE = new System.Windows.Forms.TextBox();
            this.BTN_TARGET = new System.Windows.Forms.Button();
            this.BTN_FILE = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(567, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.索引设置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.设置ToolStripMenuItem.Text = "Setting";
            // 
            // 索引设置ToolStripMenuItem
            // 
            this.索引设置ToolStripMenuItem.Name = "索引设置ToolStripMenuItem";
            this.索引设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.索引设置ToolStripMenuItem.Text = "Index Setting";
            this.索引设置ToolStripMenuItem.Click += new System.EventHandler(this.索引设置ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 226);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(567, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Margin = new System.Windows.Forms.Padding(1, 3, 20, 3);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(250, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.CKB_REPORT);
            this.tabPage4.Controls.Add(this.CKB_COLLECT);
            this.tabPage4.Controls.Add(this.TXB_TARGET_DIR);
            this.tabPage4.Controls.Add(this.TEXTBOX_FILE);
            this.tabPage4.Controls.Add(this.BTN_TARGET);
            this.tabPage4.Controls.Add(this.BTN_FILE);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(559, 159);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Distribute";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Coll Dir:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Log Dir:";
            // 
            // CKB_REPORT
            // 
            this.CKB_REPORT.AutoSize = true;
            this.CKB_REPORT.Location = new System.Drawing.Point(199, 111);
            this.CKB_REPORT.Name = "CKB_REPORT";
            this.CKB_REPORT.Size = new System.Drawing.Size(96, 16);
            this.CKB_REPORT.TabIndex = 12;
            this.CKB_REPORT.Text = "Creat Report";
            this.CKB_REPORT.UseVisualStyleBackColor = true;
            // 
            // CKB_COLLECT
            // 
            this.CKB_COLLECT.AutoSize = true;
            this.CKB_COLLECT.Location = new System.Drawing.Point(74, 111);
            this.CKB_COLLECT.Name = "CKB_COLLECT";
            this.CKB_COLLECT.Size = new System.Drawing.Size(108, 16);
            this.CKB_COLLECT.TabIndex = 11;
            this.CKB_COLLECT.Text = "Log Collection";
            this.CKB_COLLECT.UseVisualStyleBackColor = true;
            this.CKB_COLLECT.CheckedChanged += new System.EventHandler(this.CKB_COLLECT_CheckedChanged);
            // 
            // TXB_TARGET_DIR
            // 
            this.TXB_TARGET_DIR.Location = new System.Drawing.Point(72, 70);
            this.TXB_TARGET_DIR.Name = "TXB_TARGET_DIR";
            this.TXB_TARGET_DIR.Size = new System.Drawing.Size(419, 21);
            this.TXB_TARGET_DIR.TabIndex = 10;
            // 
            // TEXTBOX_FILE
            // 
            this.TEXTBOX_FILE.Location = new System.Drawing.Point(72, 25);
            this.TEXTBOX_FILE.Name = "TEXTBOX_FILE";
            this.TEXTBOX_FILE.Size = new System.Drawing.Size(419, 21);
            this.TEXTBOX_FILE.TabIndex = 4;
            this.TEXTBOX_FILE.TextChanged += new System.EventHandler(this.TEXTBOX_FILE_TextChanged);
            // 
            // BTN_TARGET
            // 
            this.BTN_TARGET.Location = new System.Drawing.Point(498, 69);
            this.BTN_TARGET.Name = "BTN_TARGET";
            this.BTN_TARGET.Size = new System.Drawing.Size(54, 23);
            this.BTN_TARGET.TabIndex = 9;
            this.BTN_TARGET.Text = "...";
            this.BTN_TARGET.UseVisualStyleBackColor = true;
            this.BTN_TARGET.Click += new System.EventHandler(this.BTN_TARGET_Click);
            // 
            // BTN_FILE
            // 
            this.BTN_FILE.Location = new System.Drawing.Point(498, 24);
            this.BTN_FILE.Name = "BTN_FILE";
            this.BTN_FILE.Size = new System.Drawing.Size(54, 23);
            this.BTN_FILE.TabIndex = 3;
            this.BTN_FILE.Text = "...";
            this.BTN_FILE.UseVisualStyleBackColor = true;
            this.BTN_FILE.Click += new System.EventHandler(this.BTN_FILE_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(567, 185);
            this.tabControl1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(567, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Log_Analysis_Tool.Properties.Resources._572110;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Start";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // MAIN_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 248);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MAIN_FORM";
            this.Text = "Log Tool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 索引设置ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox TXB_TARGET_DIR;
        private System.Windows.Forms.TextBox TEXTBOX_FILE;
        private System.Windows.Forms.Button BTN_TARGET;
        private System.Windows.Forms.Button BTN_FILE;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox CKB_COLLECT;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.CheckBox CKB_REPORT;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

