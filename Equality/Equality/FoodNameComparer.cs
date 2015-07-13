using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equality
{
    /// <summary>
    /// Alows food comparision by name
    /// </summary>
    /// <remarks>It's better to derive from base class than using interface, because base class implements both IComparer generic and non-generic</remarks>
    internal class FoodNameComparer : Comparer<Food>
    {
        private static FoodNameComparer _instance = new FoodNameComparer();
        public static FoodNameComparer Instance { get { return _instance; } }

        private FoodNameComparer() { }

        public override int Compare(Food x, Food y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;

            return string.Compare(x.Name, y.Name, StringComparison.CurrentCulture);

        }
    }
}
