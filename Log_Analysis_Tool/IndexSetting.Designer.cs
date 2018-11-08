namespace Log_Analysis_Tool
{
    partial class IndexSetting
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
            this.TEXTBOX_INDEX = new System.Windows.Forms.TextBox();
            this.BTN_ADD_INDEX = new System.Windows.Forms.Button();
            this.COMBBOX_STATION = new System.Windows.Forms.ComboBox();
            this.LISTBOX_PACKET = new System.Windows.Forms.ListBox();
            this.BTN_DEL_INDEX = new System.Windows.Forms.Button();
            this.BTN_KEY_ADD = new System.Windows.Forms.Button();
            this.BTN_KEY_DEL = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TEXTBOX_INDEX
            // 
            this.TEXTBOX_INDEX.Location = new System.Drawing.Point(119, 67);
            this.TEXTBOX_INDEX.Name = "TEXTBOX_INDEX";
            this.TEXTBOX_INDEX.Size = new System.Drawing.Size(255, 21);
            this.TEXTBOX_INDEX.TabIndex = 7;
            // 
            // BTN_ADD_INDEX
            // 
            this.BTN_ADD_INDEX.Location = new System.Drawing.Point(384, 66);
            this.BTN_ADD_INDEX.Name = "BTN_ADD_INDEX";
            this.BTN_ADD_INDEX.Size = new System.Drawing.Size(61, 23);
            this.BTN_ADD_INDEX.TabIndex = 6;
            this.BTN_ADD_INDEX.Text = "Add";
            this.BTN_ADD_INDEX.UseVisualStyleBackColor = true;
            this.BTN_ADD_INDEX.Click += new System.EventHandler(this.BTN_ADD_INDEX_Click);
            // 
            // COMBBOX_STATION
            // 
            this.COMBBOX_STATION.FormattingEnabled = true;
            this.COMBBOX_STATION.Location = new System.Drawing.Point(119, 23);
            this.COMBBOX_STATION.Name = "COMBBOX_STATION";
            this.COMBBOX_STATION.Size = new System.Drawing.Size(121, 20);
            this.COMBBOX_STATION.TabIndex = 8;
            this.COMBBOX_STATION.DropDown += new System.EventHandler(this.COMBBOX_STATION_DropDown);
            this.COMBBOX_STATION.SelectedIndexChanged += new System.EventHandler(this.COMBBOX_STATION_SelectedIndexChanged);
            // 
            // LISTBOX_PACKET
            // 
            this.LISTBOX_PACKET.FormattingEnabled = true;
            this.LISTBOX_PACKET.ItemHeight = 12;
            this.LISTBOX_PACKET.Location = new System.Drawing.Point(12, 145);
            this.LISTBOX_PACKET.Name = "LISTBOX_PACKET";
            this.LISTBOX_PACKET.Size = new System.Drawing.Size(496, 208);
            this.LISTBOX_PACKET.TabIndex = 9;
            // 
            // BTN_DEL_INDEX
            // 
            this.BTN_DEL_INDEX.Location = new System.Drawing.Point(452, 66);
            this.BTN_DEL_INDEX.Name = "BTN_DEL_INDEX";
            this.BTN_DEL_INDEX.Size = new System.Drawing.Size(61, 23);
            this.BTN_DEL_INDEX.TabIndex = 10;
            this.BTN_DEL_INDEX.Text = "Delete";
            this.BTN_DEL_INDEX.UseVisualStyleBackColor = true;
            this.BTN_DEL_INDEX.Click += new System.EventHandler(this.BTN_DEL_INDEX_Click);
            // 
            // BTN_KEY_ADD
            // 
            this.BTN_KEY_ADD.Location = new System.Drawing.Point(250, 22);
            this.BTN_KEY_ADD.Name = "BTN_KEY_ADD";
            this.BTN_KEY_ADD.Size = new System.Drawing.Size(61, 23);
            this.BTN_KEY_ADD.TabIndex = 11;
            this.BTN_KEY_ADD.Text = "Add";
            this.BTN_KEY_ADD.UseVisualStyleBackColor = true;
            this.BTN_KEY_ADD.Click += new System.EventHandler(this.BTN_KEY_ADD_Click);
            // 
            // BTN_KEY_DEL
            // 
            this.BTN_KEY_DEL.Location = new System.Drawing.Point(320, 22);
            this.BTN_KEY_DEL.Name = "BTN_KEY_DEL";
            this.BTN_KEY_DEL.Size = new System.Drawing.Size(61, 23);
            this.BTN_KEY_DEL.TabIndex = 12;
            this.BTN_KEY_DEL.Text = "Delete";
            this.BTN_KEY_DEL.UseVisualStyleBackColor = true;
            this.BTN_KEY_DEL.Click += new System.EventHandler(this.BTN_KEY_DEL_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Key in LogName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Code in LogFile:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "Code List Of Each Key";
            // 
            // IndexSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 359);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_KEY_DEL);
            this.Controls.Add(this.BTN_KEY_ADD);
            this.Controls.Add(this.BTN_DEL_INDEX);
            this.Controls.Add(this.LISTBOX_PACKET);
            this.Controls.Add(this.COMBBOX_STATION);
            this.Controls.Add(this.TEXTBOX_INDEX);
            this.Controls.Add(this.BTN_ADD_INDEX);
            this.Name = "IndexSetting";
            this.Text = "IndexSetting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TEXTBOX_INDEX;
        private System.Windows.Forms.Button BTN_ADD_INDEX;
        private System.Windows.Forms.ComboBox COMBBOX_STATION;
        private System.Windows.Forms.ListBox LISTBOX_PACKET;
        private System.Windows.Forms.Button BTN_DEL_INDEX;
        private System.Windows.Forms.Button BTN_KEY_ADD;
        private System.Windows.Forms.Button BTN_KEY_DEL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}