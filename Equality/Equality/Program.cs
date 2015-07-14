using System;
using System.Collections;
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

            Console.WriteLine("Sorting Food - reference type");
            SortingCustomCollection(); 
            Console.WriteLine();

            Console.WriteLine("Custom IEqualityComparer for FoodItem struct");
            HashSetFoodItemIgnoreCase(); 
            Console.WriteLine();

            Console.WriteLine("Structural equality");
            StructuralEquality(); 
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

        private static void SortingCustomCollection()
        {
            Console.WriteLine("First array of food");
            
            Food[] food = new Food[]{
                new Food("orange", FoodGroup.Fruits),
                new Food("banana", FoodGroup.Vegetables), 
                new Food("banana", FoodGroup.Fruits) // the same names but in different group -> sorting by multiple fields 
            };

            SortAndShowArray(food); 

            Console.WriteLine();

            Console.WriteLine("Second array - mixed food and cooked food");

            // There's no good solution for this sorting problem 
            Food[] mixedFood = new Food[]{
                new Food("apple", FoodGroup.Fruits), 
                new CookedFood("apple", FoodGroup.Fruits, "baked")
            };

            SortAndShowArray(mixedFood);
            
            Console.WriteLine();

            Console.WriteLine("Third array - mixed food and cooked food - reversed order");

            // There's no good solution for this sorting problem 
            Food[] mixedFoodReversedOrder = new Food[]{
                new CookedFood("apple", FoodGroup.Fruits, "baked"),
                new Food("apple", FoodGroup.Fruits)
            };

            SortAndShowArray(mixedFoodReversedOrder);
            Console.WriteLine();
        }

        /// <summary>
        /// Adds items to HashSet ignoring case
        /// </summary>
        private static void HashSetFoodItemIgnoreCase()
        {
            HashSet<FoodItem> foodItems = new HashSet<FoodItem>(FoodItemEqualityComparer.Instance);

            foodItems.Add(new FoodItem("apple", FoodGroup.Fruits));
            foodItems.Add(new FoodItem("Apple", FoodGroup.Fruits)); // we want apple only to be added once

            foreach (var item in foodItems)
                Console.WriteLine(item.ToString());

        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Structural equality means that both collection have the same elements in the same order
        /// Only two collections allow to use structural equality: array and tuple
        /// </remarks>
        private static void StructuralEquality()
        {
            // Arrays are reference types so when using == or equals references are compared, which returns false results
            string[] arr1 = new string[] { "banana", "apple" };
            string[] arr2 = new string[] { "banana", "apple" };
            Console.WriteLine(arr1 == arr2);
            Console.WriteLine(arr1.Equals(arr2));

            // In order to perform structural equality array requires casting to interface
            var arrEq = (IStructuralEquatable)arr1;
            bool areEqual = arrEq.Equals(arr2, StringComparer.OrdinalIgnoreCase); // NOTE: equality comparer is mandatory in such case
            Console.WriteLine(areEqual);
        
            // The same approach is valid for IStructuralComparable
        }

        private static void SortAndShowArray(Food[] array)
        {
            Array.Sort(array, FoodNameComparer.Instance);

            foreach(var item in array)
                Console.WriteLine(item.ToString());
        }
    }
}
