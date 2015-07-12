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
    /// <remarks>There should be confidence that developers using this class will not be confused
    /// because of custom equality comparison implemented. 
    /// Implementing IEquatable interface does not provide any values here</remarks>
    internal class Food
    {
        private readonly string _name;
        private readonly FoodGroup _group;

        public string Name { get { return _name; } }
        public FoodGroup Group { get { return _group; } }

        public Food(string name, FoodGroup group)
        {
            _name = name;
            _group = group; 
        }

        public override string ToString()
        {
            return _name; 
        }

        public static bool operator ==(Food x, Food y)
        {
            return object.Equals(x, y);
        }

        public static bool operator !=(Food x, Food y)
        {
            return !object.Equals(x, y);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            if (obj.GetType() != this.GetType())
                return false;

            Food rhs = obj as Food; // this cast is safe because check for null was earlier
            return _name == rhs.Name && _group == rhs.Group;
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode() ^ _group.GetHashCode(); 
        }
    }
}
