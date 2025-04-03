using global::System;
using global::System.Collections.Generic;

namespace ConsoleApp__un_boxing
{
    internal enum EnumType { None }
    internal enum EnumType2 { None }

    internal static class Program
    {
        static void Main(string[] args)
        {
            var i = 5;
            Int32 b = i;
            object o = i; //boxing
            List<int> list = new List<int> { b, (int)o /*unboxin*/ };

            Console.WriteLine($"{list}"); //boxing
            Console.WriteLine("" + (int)o); //boxing
            // -------------------------------------------------------

            object boxEnum = EnumType.None; //boxing
            long unboxEnum2 = (long)(EnumType2)boxEnum; //unboxing  (EnumType2 а не EnumType!)
            Console.WriteLine("" + unboxEnum2); //boxing
            // -------------------------------------------------------
            
            object box = (int?)42; //boxing
            long unbox = (long)(int)box; //unboxing
            Console.WriteLine("" + unbox); //boxing
            // -------------------------------------------------------
            
            object? box1 = (int?)null; //boxing
            long unbox1 = (long)(int)box1; //unboxing (can be null)
            Console.WriteLine("" + unbox1); //boxing
            // -------------------------------------------------------
            
        }
    }
}