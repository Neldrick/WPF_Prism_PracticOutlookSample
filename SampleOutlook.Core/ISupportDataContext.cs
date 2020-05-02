using System;
using System.Collections.Generic;
using System.Text;

namespace SampleOutlook.Core
{
    public interface ISupportDataContext
    {
        object DataContext { get; set; }
    }
}
