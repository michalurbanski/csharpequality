using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equality
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Sealed class affects how you can implement equality - it allows to implement IEquatable 
    /// and do the comparison of _cookingMethod in implementation which will allow type safety. 
    /// It can be done only in sealed class. In base class implementation of interface will make it slower 
    /// (due to another method call)
    /// </remarks>
    internal sealed class CookedFood : Food //, IEquatable<CookedFood>
    {
        private string _cookingMethod;

        public string CookingMethod { get { return _cookingMethod; } }

        public CookedFood(string name, FoodGroup group, string cookingMethod)
            : base(name, group)
        {
            _cookingMethod = cookingMethod; 
        }

        public static bool operator ==(CookedFood food1, CookedFood food2)
        {
            return object.Equals(food1, food2);
        }

        public static bool operator !=(CookedFood food1, CookedFood food2)
        {
            return !object.Equals(food1, food2);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", _cookingMethod, Name);
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;

            CookedFood food = (CookedFood)obj;

            return _cookingMethod == food.CookingMethod;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ _cookingMethod.GetHashCode(); 
        }
    }
}
