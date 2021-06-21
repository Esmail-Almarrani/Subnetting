using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubnettingTool
{
    public class IPoprations
    {
        public static string ANDing(string Bits,int Perfix)
        {
            string Str = "";
                string mask = "";
            mask = NetMask(Perfix);
                for (int Index = 0; Index < Perfix; Index++)
                {
                    if (Bits[Index] ==mask[Index])
                    {
                        if (Bits[Index] =='1')
                        {
                            Str += '1';
                        }
                        else
                            Str += '0';
                    }
                    else
                        Str += '0';
                }
            return Str;
        }
        public static string GetNetworkAddress(string Bits, int Perfix)
        {
            return ANDing(Bits, Perfix) + StringHelper.GenerateSequanceString('0', 32 - Perfix);
        }

        public static string GetBroadCastAddress(string Bits, int Perfix)
        {
            return ANDing(Bits, Perfix ) + StringHelper.GenerateSequanceString('1', 32 - Perfix);
        }
        public static string GetFirstUseableAddress(string Bits, int Perfix)
        {
           return StringHelper.ReplaceFromlast(GetNetworkAddress(Bits, Perfix), '1');
        }

        public static string GetLastUseableAddress(string Bits, int Perfix)
        {
            var s = GetBroadCastAddress(Bits, Perfix).ToString();
           s= StringHelper.ReplaceFromlast(s, '0');
            return s;
        }
        public static string NetMask(int Perfix)
        {
            
            return ( StringHelper.GenerateSequanceString('1', Perfix) + 
                StringHelper.GenerateSequanceString('0', 32 - Perfix));
        }
        public static int PerfixBasedOnHostNeeded(int NumberOfHost)
        {
            int Count = -1;
            for(int Index=32;Index>0;Index--)
            {
               if( SystemNumberConverter.GetCorrespondingValueOfIndex(32,Index)>=NumberOfHost+2)
                {
                    break;
                }
                Count++;
            }
            //Console.WriteLine("Host Bits : " + Count+" Number Of Usable Address  :"+(Math.Pow(2,Count)-2));
            return Count;
        }
        public static int AvalibaleHost(int Perfix)
        {
            return (int) Math.Pow(2, 32 - Perfix);
        }
    }
}
