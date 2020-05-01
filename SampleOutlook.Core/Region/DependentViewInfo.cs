using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleOutlook.Core.Region
{
    public class DependentViewInfo
    {
        public object View { get; set; }

        public string Region { get; set; }

        public DependentViewInfo()
        {

        }

        public DependentViewInfo(DependentViewAttribute att, IContainerExtension container)
        {
            Region = att.Region;
            View = container.Resolve(att.Type);       
        }
    }
}
