using SampleOutlook.Core;
using SampleOutlook.Modules.Contacts.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SampleOutlook.Modules.Contacts.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    [DependentViewAttribute(typeof(HomeTab),RegionNames.RibbonRegion)]
    public partial class ViewA : UserControl
    {
        public ViewA()
        {
            InitializeComponent();
        }

    }
}
