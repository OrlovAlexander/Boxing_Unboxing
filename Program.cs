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
            long? unbox1 = (long?)(int?)box1; //unboxing (can be null)
            Console.WriteLine("d" + unbox1); //boxing
            
            // object? box1 = (int?)null; //boxing
            // long unbox1 = (long)(int)box1; //unboxing (здесь ошибка unboxing к int, а не к int?)
            // Console.WriteLine("" + unbox1); //boxing
            // // Ошибка в runtime "System.NullReferenceException: Ссылка на объект не указывает на экземпляр объекта."
            // -------------------------------------------------------
            
            object box2 = (int?)42; //boxing (int)
            short unbox2 = (short)box2; //unboxing (short)
            Console.WriteLine("" + unbox2); //boxing
            // Ошибка в runtime "System.InvalidCastException: Заданное приведение является недопустимым."
            // -------------------------------------------------------
            
            object box3 = (int?)42; //boxing (int)
            long unbox3 = (long)box3; //unboxing (long)
            Console.WriteLine("" + unbox3); //boxing
            // Ошибка в runtime "System.InvalidCastException: Заданное приведение является недопустимым."
            // -------------------------------------------------------
            
            // String.Concat example.
            // String.Concat has many versions. Rest the mouse pointer on
            // Concat in the following statement to verify that the version
            // that is used here takes three object arguments. Both 42 and
            // true must be boxed.
            Console.WriteLine(String.Concat("Answer", 42, true));
            // -------------------------------------------------------

            // List example.
            // Create a list of objects to hold a heterogeneous collection
            // of elements.
            List<object> mixedList = new List<object>();
            // -------------------------------------------------------

            // Add a string element to the list.
            mixedList.Add("First Group:");
            // -------------------------------------------------------

            // Add some integers to the list.
            for (int ind = 1; ind < 5; ind++)
            {
                // Rest the mouse pointer over ind to verify that you are adding
                // an int to a list of objects. Each element ind is boxed when
                // you add ind to mixedList.
                mixedList.Add(ind); // boxing
            }
            // -------------------------------------------------------

            // Add another string and more integers.
            mixedList.Add("Second Group:");
            for (int ind = 5; ind < 10; ind++)
            {
                mixedList.Add(ind); // boxing
            }
            // -------------------------------------------------------

            // Display the elements in the list. Declare the loop variable by
            // using var, so that the compiler assigns its type.
            foreach (var item in mixedList)
            {
                // Rest the mouse pointer over item to verify that the elements
                // of mixedList are objects.
                Console.WriteLine(item);
            }
            // -------------------------------------------------------

            // The following loop sums the squares of the first group of boxed
            // integers in mixedList. The list elements are objects, and cannot
            // be multiplied or added to the sum until they are unboxed. The
            // unboxing must be done explicitly.
            var sum = 0;
            for (var j = 1; j < 5; j++)
            {
                // The following statement causes a compiler error: Operator
                // '*' cannot be applied to operands of type 'object' and
                // 'object'.
                //sum += mixedList[j] * mixedList[j];

                // After the list elements are unboxed, the computation does
                // not cause a compiler error.
                sum += (int)mixedList[j] * (int)mixedList[j]; // unboxing
            }

            // The sum displayed is 30, the sum of 1 + 4 + 9 + 16.
            Console.WriteLine("Sum: " + sum); // object allocation

            // Output:
            // Answer42True
            // First Group:
            // 1
            // 2
            // 3
            // 4
            // Second Group:
            // 5
            // 6
            // 7
            // 8
            // 9
            // Sum: 30            
            // -------------------------------------------------------
            
            var structMy = new MyStruct();
            var structMy2 = (StructInheritance)structMy; // boxing
            structMy2.Foo();
            structMy2.Foo();
            
            var structMy3 = (MyStruct)structMy2; // unboxing
            structMy3.Foo();
        }
    }

    internal interface StructInheritance
    {
        void Foo();
    }

    internal struct MyStruct : StructInheritance
    {
        public void Foo()
        {
        }
    }
}