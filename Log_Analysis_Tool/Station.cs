using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;



namespace Log_Analysis_Tool
{
    public class Station
    {
        public ArrayList AL_SN_ErrCode;
        public ArrayList AL_CAL_ErrCode;
        public ArrayList AL_CHECK_ErrCode;
        public ArrayList AL_PACKET_ErrCode;

        public int[] AL_SN_EC_Count;
        public int[] AL_CAL_EC_Count;
        public int[] AL_CHECK_EC_Count;
        public int[] AL_PACKET_EC_Count;

        public int nSN_EC_Row;
        public int nCAL_EC_Row;
        public int nCHECK_EC_Row;
        public int nPACKET_EC_Row;

        public string Station_Name;

        public Station()
        {
            AL_SN_ErrCode = new ArrayList();
            AL_CAL_ErrCode = new ArrayList();
            AL_CHECK_ErrCode = new ArrayList();
            AL_PACKET_ErrCode = new ArrayList();
        }
    }
}
