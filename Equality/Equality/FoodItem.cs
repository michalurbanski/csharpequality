using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equality
{
    public struct FoodItem : IEquatable<FoodItem>
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

        #region Overrides

        public override string ToString()
        {
            return _name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks>Less performance than IEquatable but nothing more can be done to improve performance</remarks>
        public override bool Equals(object obj)
        {
            if (obj is FoodItem)
                return Equals((FoodItem)obj);
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>Needs to be implemented when Equals is implemented in order to work with HashTables</remarks>
        public override int GetHashCode()
        {
            return _name.GetHashCode() ^ _group.GetHashCode(); 
        }

        #endregion

        #region IEquatable

        public bool Equals(FoodItem other)
        {
            return _name == other.Name && _group == other.Group;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs">Value type so never will be null</param>
        /// <param name="rhs">Value type so never will be null</param>
        /// <returns></returns>
        public static bool operator ==(FoodItem lhs, FoodItem rhs)
        {
            return lhs.Equals(rhs); 
        }

        public static bool operator !=(FoodItem lhs, FoodItem rhs)
        {
            return !lhs.Equals(rhs); 
        }

    }
}
