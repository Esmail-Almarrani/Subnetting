using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubnettingTool
{
    public class StringHelper
    {
        public static List<string> DottedPars(string Value)
        {
            var temp = Value.Split('.');
            return temp.ToList();
        }
        public static List<string> OctSpliter(string abstring, int length,bool IsReadable=false)
        {
            List<string> temp = new List<string>();
            string remm = "";
            if (abstring.Length > length)
            {
                temp.Add(StringHelper.RemoveAnySymol( abstring.Substring(0, length)));
                remm = abstring.Remove(0, length);
            }
            else
            {
                temp.Add(abstring);
                return temp;
            }
            temp.AddRange(OctSpliter(remm, length));
            if(IsReadable)
            {
               temp= ToReadableList(temp);
            }
            return temp;
        }
        public static string Marge(List<Part> list)
        {
            string Str = "";
            foreach(Part /*string*/ Item in /*PartListToStringList(*/list/*)*/)
            {
                Str += Item.ToBinaryFormat();
            }
            return Str;
        }

        public static string Marge(List<string> list)
        {
            string Str = "";
            foreach (string /*string*/ Item in /*PartListToStringList(*/list/*)*/)
            {
                Str += Item;
            }
            return Str;
        }
        public static List<string> ToReadableList(List<string> list)
        {
            for (int Index = 0; Index < list.Count; Index++)
            {
                list[Index] = SystemNumberConverter.BinaryToDecimal(list[Index]).ToString();
            }
            return list;
        }
        public static string ToDottedFormat(List<string> list)
        {
            string DottedFormat = "";

            for (int Index=0;Index<list.Count();Index++)
            {
                DottedFormat +=StringHelper.RemoveAnySymol( list.ElementAt(Index));
                if (Index < list.Count-1)
                    DottedFormat += ".";
            }
            return DottedFormat;
        }
        public static bool IsLetter(char Character)
        {
            //a=97, A=65,z=122, Z=90
            if((((int)Character)>=65&& ((int)Character) <= 90)|| (((int)Character) >= 97 && ((int)Character) <= 122))
            {
                return true;
            }

            return false;
        }
        public static bool IsSymbol(char Character)
        {
            //a=97, A=65,z=122, Z=90
            if (IsLetter(Character)||IsDigit(Character))
            {
                return false;
            }
            return true;
        }
        public static string RemoveAnySymol(string value)
        {
            foreach(char Item in value)
            {
                if(char.IsSymbol(Item))
                {
                  value=  value.Remove(value.IndexOf(Item));
                }
            }
            return value;
        }
        public static bool IsDigit(char Character)
        {
            //a=97, A=65,z=122, Z=90
            if (!IsLetter(Character))
            {
                if (((int)Character)>=48 &&((int)Character) <= 57)
                    return true;
            }

            return false;
        }
        public static string GenerateSequanceString(char Character,int Length)
        {
            string Str = "";
            for (int Index = 0; Index < Length; Index++)
            {
                Str += Character;
            }
            return Str;
        }
        public static List<string> PartListToStringList(List<Part>Parts, bool IsReadable=true)
        {
            List<string> list = new List<string>();
            foreach(Part Item in Parts)
            {
                if (IsReadable == true)
                    list.Add(Item.ToReadableFormat());
                else
                    list.Add(Item.ToBinaryFormat());

            }
            return list;
        }
        public static string ReplaceFromlast(string Value,char Character)
        {
           var temp= Value.Remove(Value.Length - 1) ;
            temp += Character;
            return temp;
        }
        
    }
}
