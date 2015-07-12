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
    /// <remarks>Sealed class affects how you can implement equality</remarks>
    internal sealed class CookedFood : Food
    {
        private string _cookingMethod;

        public string CookingMethod { get { return _cookingMethod; } }

        public CookedFood(string name, FoodGroup group, string cookingMethod)
            : base(name, group)
        {
            _cookingMethod = cookingMethod; 
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", _cookingMethod, Name);
        }
    }
}
