using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equality
{
    public struct FoodItem
    {
        private readonly string _name;
        private readonly FoodGroup _group;

        public string Name { get { return _name; } }
        public FoodGroup Group { get { return _group; } }

        public FoodItem(string name, FoodGroup group)
        {
            _name = name;
            _group = group; 
        }

        public override string ToString()
        {
            return _name; 
        }
    }
}
