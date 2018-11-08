using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Log_Analysis_Tool
{
    public partial class IndexSetting : Form
    {
        public Setting setting;

        public IndexSetting()
        {
            InitializeComponent();
            setting = new Setting();
            StartPosition = FormStartPosition.CenterScreen;
            setting.XML_Read_Key();
            for (int i = 0; i < setting.log.sArrKey.Count(); i++)
            {
                COMBBOX_STATION.Items.Add(setting.log.sArrKey[i]);
            }
            if (setting.log.sArrKey.Count() != 0)
                COMBBOX_STATION.SelectedIndex = 0;
        }

        private void BTN_ADD_INDEX_Click(object sender, EventArgs e)
        {
            setting.XML_Add_Code(COMBBOX_STATION.SelectedIndex, TEXTBOX_INDEX.Text);
            LISTBOX_PACKET.Items.Add(TEXTBOX_INDEX.Text);
            MessageBox.Show("添加成功!");
            TEXTBOX_INDEX.Text = "";
        }

        private void BTN_DEL_INDEX_Click(object sender, EventArgs e)
        {
            setting.XML_Del_Code(COMBBOX_STATION.SelectedIndex, LISTBOX_PACKET.SelectedItem.ToString());
            LISTBOX_PACKET.Items.Remove(LISTBOX_PACKET.SelectedItem.ToString());
            MessageBox.Show("删除成功!");
        }
        
        private void COMBBOX_STATION_SelectedIndexChanged(object sender, EventArgs e)
        {
            setting.XML_Read_Code();
            LISTBOX_PACKET.Items.Clear();
            foreach (string errcode in setting.log.sALCode[COMBBOX_STATION.SelectedIndex].ToArray())
            {
                LISTBOX_PACKET.Items.Add(errcode);
            }
        }

        private void BTN_KEY_ADD_Click(object sender, EventArgs e)
        {
            setting.XML_Add_Key(COMBBOX_STATION.Text);
            MessageBox.Show("添加成功!");
        }

        private void BTN_KEY_DEL_Click(object sender, EventArgs e)
        {
            setting.XML_Del_Key(COMBBOX_STATION.Text);
            MessageBox.Show("删除成功!");
        }

        private void COMBBOX_STATION_DropDown(object sender, EventArgs e)
        {
            setting.XML_Read_Key();
            COMBBOX_STATION.Items.Clear();
            foreach (string key in setting.log.sArrKey)
            {
                COMBBOX_STATION.Items.Add(key);
            }
        }
    }
}