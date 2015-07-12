using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Value types equality test");
            ValueTypesEquality();
            Console.WriteLine();

            Console.WriteLine("Reference types eqaulity test");
            ReferenceTypesEquality();
            Console.WriteLine();
        }

        internal static void DisplayWhetherEqual(Food food1, Food food2)
        {
            if (food1 == food2)
                Console.WriteLine(string.Format("{0,12} == {1}", food1, food2)); 
            else
                Console.WriteLine(string.Format("{0,12} != {1}", food1, food2));
        }


        /// <summary>
        /// Implements value types equality using structures
        /// </summary>
        /// <remarks>
        /// Own equality implementation for value type should be made in order to: 
        /// 1. Use == operator
        /// 2. Performance - avoid boxing and unboxing and also using reflection
        /// 3. Change meaning of Equals(), e.g. not all fields may be checked
        /// 
        /// Steps required to implement equality (best practice is to implement all 3): 
        /// 1. Override object.Equals() -> avoid reflection
        /// 2. Implement IEquatable<FoodItem> -> avoid boxing, give type safety
        /// 3. Allow using == operator 
        /// 4. Implement != operator
        /// 5. Implement object.GetHashCode() - required by Equals()
        /// </remarks>
        internal static void ValueTypesEquality()
        {
            FoodItem banana = new FoodItem("banana", FoodGroup.Fruits);
            FoodItem banana2 = new FoodItem("banana", FoodGroup.Fruits);
            FoodItem chocolate = new FoodItem("chocolate", FoodGroup.Sweets);

            Console.WriteLine("bananas: " + (banana == banana2));
            Console.WriteLine("banana and chocolate: "+ (banana == chocolate));
        }
        
        /// <summary>
        /// Implements reference types equality (classes)
        /// </summary>
        internal static void ReferenceTypesEquality()
        {
            Food apple = new Food("apple", FoodGroup.Fruits);
            CookedFood cookedApple = new CookedFood("apple", FoodGroup.Fruits, "stewed");
            Food apple2 = new Food("apple", FoodGroup.Fruits);
            CookedFood cookedApple2 = new CookedFood("apple", FoodGroup.Fruits, "stewed"); 

            DisplayWhetherEqual(apple, cookedApple);
            DisplayWhetherEqual(apple, apple2);
            DisplayWhetherEqual(cookedApple, cookedApple2);

        }
    }
}
