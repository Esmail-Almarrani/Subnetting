using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SubnettingTool
{
    public class Subnetting
    {
        private static Address NetworkBasedOnHostNeeded(string addr,int HostNeeded)
        {

            var address = Objects.NewAddress(addr,32- IPoprations.PerfixBasedOnHostNeeded(HostNeeded));
            //Console.WriteLine(address.ToString());
            //Console.WriteLine(address.ToString(false));
            //Console.WriteLine("   " + address.GetNetworkAddress().ToString() + "          |         " + address.GetFirstUseableAddress().ToString() + "  --  " + address.GetLastUseableAddress().ToString() + "         |         " + address.GetBroadCastAddress().ToString() + "        |      "+ (Math.Pow(2, (32-address.PerfixLegnth)) - 2)+" ");
            //Console.WriteLine("Network in Decimal : " + address.GetNetworkAddress().ToString());
            ////Console.WriteLine("Network in Binary : " + address.GetNetworkAddress().ToString(false));

            //Console.WriteLine("First Usable Address in Decimal : " + address.GetFirstUseableAddress().ToString());
            //////Console.WriteLine("First Usable Address in Binary : " + address.GetFirstUseableAddress().ToString(false));

            //Console.WriteLine("Last Usable Address in Decimal : " + address.GetLastUseableAddress().ToString());
            //////Console.WriteLine("Last Usable Address in Binary : " + address.GetLastUseableAddress().ToString(false));

            //Console.WriteLine("BroadCast Address in Decimal : " + address.GetBroadCastAddress().ToString());
            //////Console.WriteLine("BroadCast Address in Binary : " + address.GetBroadCastAddress().ToString(false));

            ////Console.WriteLine("Next Network Address in Decimal : " + address.GetNextNetwork().ToString());
            ////Console.WriteLine("BroadCast Address in Binary : " + address.GetBroadCastAddress().ToString(false));
            //Console.WriteLine("---------------------------------------------------------------");
            return address;
        }
        public static List< Address> NetworkBasedOnHostNeeded(string addr,int Perfix, List<int> listHostNeeded)
        {
            List<Address> listNetwork = new List<Address>();
             listHostNeeded.Sort((a, b) => b.CompareTo(a));
            string nextNetwork = "";
            //nextNetwork = addr;
            var address = Objects.NewAddress(addr, Perfix);
            nextNetwork = address.ToString();
            //MessageBox.Show(nextNetwork);
            string MainNetworkPortion = address.GetNetworkPortion();
            //MessageBox.Show(MainNetworkPortion);
            foreach (int Item in listHostNeeded)
            {
                
                var addres = NetworkBasedOnHostNeeded(nextNetwork, Item);
                //MessageBox.Show(addres.GetNetworkPortion());
                if (MainNetworkPortion.Length > addres.GetNetworkPortion().Length)
                    continue;
                if (addres.GetNetworkPortion().Substring(0, MainNetworkPortion.Length) != MainNetworkPortion)
                    continue;
               // MessageBox.Show(addres.ToString());
                //Console.WriteLine("Network in Decimal : " + addres.GetNetworkAddress().ToString());
                nextNetwork = addres.GetNextNetwork().ToString();
                listNetwork.Add(addres);
            }
            return listNetwork;
        }
        public static List<Address> FixedSubnetting(string addr,int NumberOfNetwork, int HostNeededPerNetwork)
        {
            List<int> list = new List<int>();
            for (int Index = 0; Index < NumberOfNetwork; Index++)
            {
                list.Add(HostNeededPerNetwork);
            }
            return NetworkBasedOnHostNeeded(addr, 32 - IPoprations.PerfixBasedOnHostNeeded(HostNeededPerNetwork), list);
        }
    }
}
