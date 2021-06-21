using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubnettingTool
{
    public class Address
    {
        List<Part> Parts;
        public int PerfixLegnth;
        public Address(List<Part> parts, int PerfixLegnth)
        {
            this.PerfixLegnth = PerfixLegnth;
            Parts = parts;
        }



        // void SetAddress(string address,int PerfixLegnth)
        //{
        //    this.PerfixLegnth = PerfixLegnth;
        //    List<string> temp = StringHelper.DottedPars(address);
        //    for (int Index=0;Index<temp.Count();Index++)
        //    {
        //        Parts.ElementAt(Index).SetValue(temp[Index]);
        //    }
        //}

        public string GetNetworkPortion()
        {
            return  StringHelper.Marge(Parts).Substring(0, PerfixLegnth);
        }
        public string NetMask()
        {
           return StringHelper.ToDottedFormat(StringHelper.OctSpliter( IPoprations.NetMask(PerfixLegnth), 8, true)) ;
           
        }
        public string AvalibaleHost()
        {
            return (IPoprations.AvalibaleHost(PerfixLegnth)-2).ToString();
        }
        //public string GetHostPortion()
        //{
        //    return ToBinaryFormat().Substring(PerfixLegnth,32-PerfixLegnth);
        //}
        public Address GetNetworkAddress()
        {
            return GetAddressObject( IPoprations.GetNetworkAddress(StringHelper.Marge(Parts),PerfixLegnth)); 
            //return null;
        }
        public Address GetFirstUseableAddress()
        {
            return GetAddressObject(IPoprations.GetFirstUseableAddress(StringHelper.Marge(Parts), PerfixLegnth));
        }
        public Address GetLastUseableAddress()
        {
            return GetAddressObject(IPoprations.GetLastUseableAddress(StringHelper.Marge(Parts), PerfixLegnth));
        }
        public Address GetBroadCastAddress()
        {
            return GetAddressObject(IPoprations.GetBroadCastAddress(StringHelper.Marge(Parts), PerfixLegnth));
        }
        public  string ToString(bool IsReadable = true)
        {
            return StringHelper.ToDottedFormat(StringHelper.PartListToStringList(Parts, IsReadable));
        }
        public Address GetNextNetwork()
        {
           return GetAddressObject(  SystemNumberConverter.Increment(IPoprations.GetBroadCastAddress(StringHelper.Marge(Parts), PerfixLegnth)));
        }
        Address GetAddressObject(string Str)
        {
           return Objects.NewAddress(StringHelper.OctSpliter(Str, 8, true), PerfixLegnth);
        }
    }
}
