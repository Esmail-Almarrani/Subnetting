using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubnettingTool
{
    public class NetworksReport
    {
        private string networkAddress;
        private string subNetMask;
        private string firstUsableAddress;
        private string lastUsableAddress;
        private string broadeCastAddress;
        private string numberOfUsableHostAddress;
        

        public NetworksReport(Address address)
        {
            NetworkAddress = address.GetNetworkAddress().ToString();
            SubNetMask = address.NetMask();
            FirstUsableAddress = address.GetFirstUseableAddress().ToString();
            LastUsableAddress = address.GetLastUseableAddress().ToString();
            BroadeCastAddress = address.GetBroadCastAddress().ToString();
            NumberOfUsableHostAddress = address.AvalibaleHost();
        }

        public string NetworkAddress { get => networkAddress; set => networkAddress = value; }
        public string SubNetMask { get => subNetMask; set => subNetMask = value; }
        public string FirstUsableAddress { get => firstUsableAddress; set => firstUsableAddress = value; }
        public string LastUsableAddress { get => lastUsableAddress; set => lastUsableAddress = value; }
        public string BroadeCastAddress { get => broadeCastAddress; set => broadeCastAddress = value; }
        public string NumberOfUsableHostAddress { get => numberOfUsableHostAddress; set => numberOfUsableHostAddress = value; }
        

        




    }
}
