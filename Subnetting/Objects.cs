using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubnettingTool
{
    public class Objects
    {
        public static Address NewAddress(string address, int PerfixLegnth)
        {
            return new Address(NewPart(StringHelper.DottedPars(address)),PerfixLegnth);
        }
        public static Address NewAddress(List<string> Octs, int PerfixLegnth)
        {
           return  new Address(NewPart(Octs), PerfixLegnth);
        }
        public static Part NewPart(string Value)
        {
            return new Part(int.Parse(StringHelper.RemoveAnySymol(Value)));
        }
        public static List<Part> NewPart(List<string> list)
        {
            List<Part> parts = new List<Part>();
            foreach (string Item in list)
            {
                if (Item.Contains("."))
                {
                    Console.WriteLine("Symbole");
                }
                if ((Item!="")&& (Item != "."))
                parts.Add(NewPart(StringHelper.RemoveAnySymol(Item)));
            }
            return parts;
        }
    }
}
