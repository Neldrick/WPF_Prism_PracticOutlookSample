using System;
using System.Collections.Generic;
using System.Text;

namespace SampleOutlook.Core
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    public class DependentViewAttribute : Attribute
    {
        public Type Type { get; set; }

        public string Region { get; set; }

        public DependentViewAttribute(Type type, string region)
        {
            Region = region ?? throw new ArgumentNullException(nameof(region));

            Type = type ?? throw new ArgumentNullException(nameof(type));
        }
    }
}
