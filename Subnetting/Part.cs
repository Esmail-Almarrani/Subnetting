using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubnettingTool
{
    public class Part
    {
        private int PartLegnth;
        private string OctBits;

        
        public Part(string value,int Legnth=8)
        {
           OctBits = value;
           this.PartLegnth = Legnth;
        }
        public Part(int value, int Legnth = 8)
        {
            OctBits = SystemNumberConverter.DecimalToBinary(value,Legnth);
            this.PartLegnth = Legnth;
        }
        public void SetValue(string value)
        {
            if (SystemNumberConverter.IsNumber(value))
                OctBits = SystemNumberConverter.DecimalToBinary(int.Parse(value), PartLegnth);
        }
        public string ToReadableFormat()
        {
            return SystemNumberConverter.BinaryToDecimal(OctBits).ToString();
        }
        public int GetHostBits()
        {
            bool temp = false;
            int size = 0;
            foreach (int bit in OctBits)
            {
                if (bit == 0)
                {
                    temp = true;
                    size++;
                }
                else
                {
                    temp = false;
                }
            }
            return size;
        }
        public int GetNetworkBits()
        {
            bool temp = false;
            int size = 0;
            foreach (int bit in OctBits)
            {
                if(bit==1)
                {
                    temp = true;
                    size++;
                }
                else
                {
                    temp = false;
                }
            }
            return size;
        }
        public  string ToBinaryFormat()
        {
            return OctBits;
        }
        public  string ToString(bool IsReadable=true)
        {
            if(IsReadable)
            {
               return SystemNumberConverter.BinaryToDecimal(OctBits).ToString();
            }
            return SystemNumberConverter.BinaryToDecimal(OctBits).ToString();
        }
    }
}
