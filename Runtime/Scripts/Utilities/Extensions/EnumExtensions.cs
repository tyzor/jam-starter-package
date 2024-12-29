using System;
using System.Collections.Generic;

namespace Utilities
{
    public static class EnumExtensions
    {
        private static Dictionary<Type, Enum[]> _enumsMap;
        
        public static T GetRandomEnum<T>() where T : Enum
        {
            var type = typeof(T);
            
            if (_enumsMap == null)
            {
                _enumsMap = new Dictionary<Type, Enum[]>();
            }

            if (_enumsMap.TryGetValue(type, out var enums) == false)
            {
                enums = (Enum[])Enum.GetValues(type);
                _enumsMap.Add(type, enums);
            }

            return (T)enums.PickRandomElement();
        }
    }
}