﻿using System;
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
            
        }
    }
}
