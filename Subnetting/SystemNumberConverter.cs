using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubnettingTool
{
    public class SystemNumberConverter
    {
        public static int GetCorrespondingValueOfIndex(int bitLength,int Index)
        {
           return (int)Math.Pow
            (
                2, ((bitLength - 1) - Index)
            );
        }
        public static double BinaryToDecimal(string BinaryNumber)
        {
            int sum = 0;
            for (int Index = 0; Index < BinaryNumber.Length; Index++)
            {
                if (BinaryNumber[Index] == '1')
                {

                    sum += GetCorrespondingValueOfIndex(BinaryNumber.Length, Index);
                }
                else
                {
                    continue;
                }
            }
            return sum;
        }
        public static bool IsNumber(string Value)
        {
            long result;
           return long.TryParse(Value,out result);
        }
        public static string DecimalToBinary(double DecimalValue,int bitLength)
        {
            string BinaryNumber = "";
            for (int Index = 0; Index < bitLength; Index++)
            {
                if (DecimalValue >= GetCorrespondingValueOfIndex(bitLength,Index))
                {
                    BinaryNumber += "1";
                    DecimalValue -= GetCorrespondingValueOfIndex(bitLength, Index);
                }
                else
                {
                    BinaryNumber += "0";
                }
            }
            return BinaryNumber;
        }
        public static string Increment(string binaryValue)
        {
            var val = BinaryToDecimal(binaryValue);
            val++;
           return DecimalToBinary(val ,32);
        }
    }
}
