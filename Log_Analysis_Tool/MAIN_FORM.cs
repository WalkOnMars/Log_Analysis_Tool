using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;

namespace Log_Analysis_Tool
{
    public partial class MAIN_FORM : Form
    {
        public MAIN_FORM()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            setting = new Setting();
            CKB_COLLECT.Checked = true;
            CKB_REPORT.Checked = true;
        }

        public Setting setting;
        private int iChartNum;

        private void BTN_FILE_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择Log所在文件夹";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                TEXTBOX_FILE.Text = dialog.SelectedPath;
            }
        }

        public void AnalysisLog_Thread()
        {
            DateTime dateBegin=DateTime.Now;
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            setting.XML_Read_All();
            if (CKB_COLLECT.Checked)
            {
                for (int i = 0; i < setting.log.sArrKey.Count(); i++)
                {
                    string sPath = TXB_TARGET_DIR.Text + "\\" + setting.log.sArrKey[i].ToString();
                    if(Directory.Exists(sPath))
                        DelectDir(sPath);
                }
            }
            setting.log.iArrCode_Count = new int[setting.log.sArrKey.Count()][];

            for (int itemp = 0; itemp < setting.log.sArrKey.Count(); itemp++)
            {
                setting.log.iArrCode_Count[itemp] = new int[setting.log.iArrCodeNum[itemp]];
                for (int itemp1 = 0; itemp1 < setting.log.iArrCodeNum[itemp]; itemp1++)
                {
                    setting.log.iArrCode_Count[itemp][itemp1] = 0;
                }
            }

            ArrayList[] sAL_UndefineFile = new ArrayList[setting.log.sArrKey.Count()];
            for (int i = 0; i < setting.log.sArrKey.Count(); i++)
            {
                sAL_UndefineFile[i] = new ArrayList();
            }

            int[] iStationLogNum = new int[setting.log.sArrKey.Count()];
            IEnumerable<string> FileList = Directory.GetFiles(TEXTBOX_FILE.Text, "*.txt", SearchOption.AllDirectories);
            this.Invoke(new Action(delegate()
            {
                this.toolStripProgressBar1.Maximum = FileList.Count();
                this.toolStripProgressBar1.Minimum = 0;
                this.toolStripProgressBar1.Step = 1;
                this.toolStripProgressBar1.Value = 0;
            }));

            foreach (string ReportFile in FileList)
            {
                string ReportName = Path.GetFileName(ReportFile);
                StreamReader sr = new StreamReader(ReportFile, Encoding.Default);
                string strContent = sr.ReadToEnd();
                                
                const string pattern = "[~\\/<>:*?|\"]"; 
                Regex rx = new Regex(pattern);

                for (int itemp2 = 0; itemp2 < setting.log.sArrKey.Count(); itemp2++)
                {
                    if (ReportName.IndexOf(setting.log.sArrKey[itemp2]) != -1)//包含Key的Log
                    {
                        string subKeyfolder = TXB_TARGET_DIR.Text + "\\" + rx.Replace(setting.log.sArrKey[itemp2].ToString(),"");                        
                        if (CKB_COLLECT.Checked)
                        {                           
                            if (!Directory.Exists(subKeyfolder))
                                Directory.CreateDirectory(subKeyfolder);
                        }
                        iStationLogNum[itemp2]++;
                        bool bNotDefined = true;
                        for (int i = 0; i < setting.log.iArrCodeNum[itemp2]; i++)
                        {
                            if (strContent.IndexOf(setting.log.sALCode[itemp2][i].ToString()) != -1)
                            {
                                if (CKB_COLLECT.Checked)
                                {
                                    string subCodefolder = subKeyfolder + "\\" + rx.Replace(setting.log.sALCode[itemp2][i].ToString(),"");                                    
                                    if (!Directory.Exists(subCodefolder))
                                        Directory.CreateDirectory(subCodefolder);
                                    string target_file = subCodefolder + "\\" + ReportName;
                                    File.Copy(ReportFile, target_file);
                                }

                                bNotDefined = false;
                                setting.log.iArrCode_Count[itemp2][i]++;
                            }
                        }
                        if (bNotDefined)
                        {
                            sAL_UndefineFile[itemp2].Add(ReportName);
                            if (CKB_COLLECT.Checked)
                            {
                                string target_file = subKeyfolder + "\\" + ReportName;
                                File.Copy(ReportFile, target_file);
                            }
                        }
                    }
                }
                sr.Close();
                this.Invoke(new Action(delegate()
                {
                    toolStripProgressBar1.Value += toolStripProgressBar1.Step;
                }));
            }
            if (!bCKB_REPORT)
            {
                DateTime dateEnd = DateTime.Now;
                TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
                TimeSpan ts3 = ts1.Subtract(ts2).Duration();
                string sTime = string.Format("Finish! Time Elapse:{0}sec", ts3.Seconds);
                toolStripStatusLabel1.Text = sTime;
                return;
            }
            
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;
            try
            {
                oXL = new Excel.Application();
                oXL.Visible = true;
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                //oSheet = (Excel._Worksheet)oWB.ActiveSheet;
                oSheet = (Excel._Worksheet)oWB.Worksheets[2];

                for (int i = 0, index = 0; i < setting.log.sArrKey.Count(); i++, index+=2)
                {
                    oSheet.Cells[1, index + 1] = setting.log.sArrKey[i].ToString() + " Undefine Fils";
                    for (int j = 0; j < sAL_UndefineFile[i].Count; j++)
                        oSheet.Cells[j + 2, i + 1] = sAL_UndefineFile[i][j];
                }

                oSheet = (Excel._Worksheet)oWB.Worksheets[1];
                //Add table headers going cell by cell.

                for (int i = 0,index=0; i < setting.log.sArrKey.Count();i++, index+=4)
                {
                    oSheet.Cells[1, index + 1] = setting.log.sArrKey[i] + " distribute";
                    oSheet.Cells[1, index + 2] = iStationLogNum[i].ToString() + "pcs";

                    for (int j = 0; iStationLogNum[i] > 0 && j < setting.log.iArrCodeNum[i]; j++)
                    {
                        if (setting.log.iArrCodeNum[i] > 0)
                        {
                            oSheet.Cells[j + 2, index + 1] = setting.log.sALCode[i][j].ToString();
                            oSheet.Cells[j + 2, index + 2] = setting.log.iArrCode_Count[i][j].ToString();
                            oSheet.Cells[j + 2, index + 3] = ((float)setting.log.iArrCode_Count[i][j] / iStationLogNum[i]).ToString();
                        }
                    }
                }
                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "AF1").Font.Bold = true;
                oSheet.get_Range("A1", "AF1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                oSheet.get_Range("B1:C1,F1:G1,J1:K1,N1:O1", Missing.Value).EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                oRng = oSheet.get_Range("A1：A1,E1:E1,I1:I1,M1:M1", Missing.Value);
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("D1:D1,L1:L1,H1:H1", Missing.Value);
                oRng.ColumnWidth = 2;
                iChartNum = 1;
                for (int i = 0; i < setting.log.sArrKey.Count(); i++)
                {
                    if (iStationLogNum[i] == 0)
                    {
                        oRng = (Excel.Range)oSheet.Columns[i * 4 + 1, Missing.Value];
                        oRng = oRng.get_Resize(Missing.Value, 4);
                        oRng.EntireColumn.Hidden = true;
                        continue;
                    }
                    DisplayChart(oSheet, i);
                }

                oXL.Visible = true;
                oXL.UserControl = true;

                DateTime dateEnd = DateTime.Now;
                TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
                TimeSpan ts3 = ts1.Subtract(ts2).Duration();
                string sTime = string.Format("Finish! Time Elapse:{0}sec", ts3.Seconds);
                toolStripStatusLabel1.Text = sTime;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                MessageBox.Show(errorMessage, "Error");
            }
        }
       
        public void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void DisplayChart(Excel._Worksheet oSheet,int iStationIndex)
        {
            Excel._Workbook oWB;
            Excel.Range oResizeRange;
            Excel._Chart oChart;

            string[,] sArray = new string[4, 2];
            sArray[0, 0] = "A";
            sArray[0, 1] = "C";
            sArray[1, 0] = "E";
            sArray[1, 1] = "G";
            sArray[2, 0] = "I";
            sArray[2, 1] = "K";
            sArray[3, 0] = "M";
            sArray[3, 1] = "O";
            int[] iColor = { 36, 35, 34, 8 };
            //Excel.Series oSeries;
            
            int iUsedRow = oSheet.get_Range(sArray[iStationIndex, 0] + "1048576").get_End(Excel.XlDirection.xlUp).Row;
            string sRange = string.Format("{0}1:{1}", sArray[iStationIndex, 0], sArray[iStationIndex, 0]+iUsedRow.ToString());
            oResizeRange = oSheet.get_Range(sRange,Missing.Value).get_Resize(Missing.Value, 3);
            oResizeRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
            oResizeRange.Interior.ColorIndex = iColor[iStationIndex];
            string sRange1 = string.Format("{0}2:{1}", sArray[iStationIndex, 1], sArray[iStationIndex, 1] + iUsedRow.ToString());
            oResizeRange = oSheet.get_Range(sRange1,Missing.Value);
            oResizeRange.NumberFormat = "0.00%";

            sRange = string.Format("{0}2:{1},{2}2:{3}",sArray[iStationIndex, 0],sArray[iStationIndex, 0]+ iUsedRow.ToString(),sArray[iStationIndex, 1],sArray[iStationIndex, 1]+ iUsedRow.ToString());
            oWB = (Excel._Workbook)oSheet.Parent;
            oChart = (Excel._Chart)oWB.Charts.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            oResizeRange = oSheet.get_Range(sRange, Missing.Value);

            //Use the ChartWizard to create a new chart from the selected data.
            oChart.ChartWizard(oResizeRange, Excel.XlChartType.xlPieExploded, Missing.Value,
            Excel.XlRowCol.xlColumns, sArray[iStationIndex, 0], sArray[iStationIndex, 1], true,
            oSheet.Cells[1, sArray[iStationIndex, 0]], Missing.Value, Missing.Value, Missing.Value);
            oChart.ApplyDataLabels();
            oChart.Location(Excel.XlChartLocation.xlLocationAsObject, oSheet.Name);

            //Move the chart so as not to cover your data.
            string sChartName = string.Format("Chart {0}", iChartNum.ToString());
            oResizeRange = (Excel.Range)oSheet.Rows.get_Item(5, Missing.Value);
            oSheet.Shapes.Item(sChartName).Top = (float)(double)oResizeRange.Top;
            oResizeRange = (Excel.Range)oSheet.Columns.get_Item(iStationIndex*4+1, Missing.Value);
            oSheet.Shapes.Item(sChartName).Left = (float)(double)oResizeRange.Left;
            oSheet.Shapes.Item(sChartName).Width = 250;
            iChartNum++;
        }

        private void TEXTBOX_FILE_TextChanged(object sender, EventArgs e)
        {
            // StreamWriter sw1 = new StreamWriter("config.ini");          

        }

        private void 索引设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndexSetting dlg = new IndexSetting();
            dlg.TopMost = true;
            dlg.Show();
        }

        private void DisplayQuarterlySales(Excel._Worksheet oWS)
        {
            Excel._Workbook oWB;
            Excel.Series oSeries;
            Excel.Range oResizeRange;
            Excel._Chart oChart;
            String sMsg;
            int iNumQtrs;

            //Determine how many quarters to display data for.
            for (iNumQtrs = 4; iNumQtrs >= 2; iNumQtrs--)
            {
                sMsg = "Enter sales data for ";
                sMsg = String.Concat(sMsg, iNumQtrs);
                sMsg = String.Concat(sMsg, " quarter(s)?");

                DialogResult iRet = MessageBox.Show(sMsg, "Quarterly Sales?",
                MessageBoxButtons.YesNo);
                if (iRet == DialogResult.Yes)
                    break;
            }

            sMsg = "Displaying data for ";
            sMsg = String.Concat(sMsg, iNumQtrs);
            sMsg = String.Concat(sMsg, " quarter(s).");

            MessageBox.Show(sMsg, "Quarterly Sales");

            //Starting at E1, fill headers for the number of columns selected.
            oResizeRange = oWS.get_Range("E1", "E1").get_Resize(Missing.Value, iNumQtrs);
            oResizeRange.Formula = "=\"Q\" & COLUMN()-4 & CHAR(10) & \"Sales\"";

            //Change the Orientation and WrapText properties for the headers.
            oResizeRange.Orientation = 38;
            oResizeRange.WrapText = true;

            //Fill the interior color of the headers.
            oResizeRange.Interior.ColorIndex = 36;

            //Fill the columns with a formula and apply a number format.
            oResizeRange = oWS.get_Range("E2", "E6").get_Resize(Missing.Value, iNumQtrs);
            oResizeRange.Formula = "=RAND()*100";
            oResizeRange.NumberFormat = "$0.00";

            //Apply borders to the Sales data and headers.
            oResizeRange = oWS.get_Range("E1", "E6").get_Resize(Missing.Value, iNumQtrs);
            oResizeRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

            //Add a Totals formula for the sales data and apply a border.
            oResizeRange = oWS.get_Range("E8", "E8").get_Resize(Missing.Value, iNumQtrs);
            oResizeRange.Formula = "=SUM(E2:E6)";
            oResizeRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle
            = Excel.XlLineStyle.xlDouble;
            oResizeRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).Weight
            = Excel.XlBorderWeight.xlThick;

            //Add a Chart for the selected data.
            oWB = (Excel._Workbook)oWS.Parent;
            oChart = (Excel._Chart)oWB.Charts.Add(Missing.Value, Missing.Value,
            Missing.Value, Missing.Value);

            //Use the ChartWizard to create a new chart from the selected data.
            oResizeRange = oWS.get_Range("E2:E6", Missing.Value).get_Resize(Missing.Value, iNumQtrs);

            oChart.ChartWizard(oResizeRange, Excel.XlChartType.xl3DColumn, Missing.Value,
            Excel.XlRowCol.xlColumns, Missing.Value, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            oSeries = (Excel.Series)oChart.SeriesCollection(1);

            oSeries.XValues = oWS.get_Range("A2", "A6");
            for (int iRet = 1; iRet <= iNumQtrs; iRet++)
            {
                oSeries = (Excel.Series)oChart.SeriesCollection(iRet);
                String seriesName;
                seriesName = "=\"Q";
                seriesName = String.Concat(seriesName, iRet);
                seriesName = String.Concat(seriesName, "\"");
                oSeries.Name = seriesName;
            }

            oChart.Location(Excel.XlChartLocation.xlLocationAsObject, oWS.Name);

            //Move the chart so as not to cover your data.
            oResizeRange = (Excel.Range)oWS.Rows.get_Item(10, Missing.Value);
            oWS.Shapes.Item("Chart 1").Top = (float)(double)oResizeRange.Top;
            oResizeRange = (Excel.Range)oWS.Columns.get_Item(2, Missing.Value);
            oWS.Shapes.Item("Chart 1").Left = (float)(double)oResizeRange.Left;
        }

        private void CKB_COLLECT_CheckedChanged(object sender, EventArgs e)
        {
            if (CKB_COLLECT.Checked)
                TXB_TARGET_DIR.Enabled = true;
            else
                TXB_TARGET_DIR.Enabled = false;
        }

        private void BTN_TARGET_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择Log所在文件夹";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                TXB_TARGET_DIR.Text = dialog.SelectedPath;
            }
        }

        private bool bCKB_REPORT;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(TEXTBOX_FILE.Text))
            {
                MessageBox.Show("Log path does not exist", "warning");
                return;
            }

            if (CKB_COLLECT.Checked && !Directory.Exists(TXB_TARGET_DIR.Text))
            {
                MessageBox.Show("Target path does not exist", "warning");
                return;
            }
            bCKB_REPORT = CKB_REPORT.Checked;
            Thread m_thread = new Thread(AnalysisLog_Thread);
            m_thread.Start();
        }



    }
}
