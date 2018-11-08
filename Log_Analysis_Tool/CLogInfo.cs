using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Log_Analysis_Tool
{
    public class CLogInfo
    {
        Dictionary<string, int> dKey2CodeNum = new Dictionary<string, int>();
           
        public string[] sArrKey;
        public ArrayList[] sALCode;
        public int[] iArrCodeNum;
        public int[][] iArrCode_Count;
    }
}
