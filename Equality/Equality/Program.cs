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
            ValueTypesEquality();
            ReferenceTypesEquality(); 
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
            throw new NotImplementedException();
        }
    }
}
