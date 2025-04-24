using System;
using System.Collections.Generic;
using System.Text;

namespace BindablePropertyGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class GenerateBindablePropertyAttribute : Attribute
    {
        public Type Type;

        public GenerateBindablePropertyAttribute(Type type)
        {
            Type = type;
        }
    }
}
