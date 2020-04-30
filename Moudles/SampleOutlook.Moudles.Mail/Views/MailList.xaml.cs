using SampleOutlook.Core;
using SampleOutlook.Moudles.Mail.Menu;
using System.Windows.Controls;

namespace SampleOutlook.Moudles.Mail.Views
{
    /// <summary>
    /// Interaction logic for MailList
    /// </summary>
    [DependentViewAttribute(typeof(HomeTab),RegionNames.RibbonRegion)]
    public partial class MailList : UserControl
    {
        public MailList()
        {
            InitializeComponent();
        }
    }
}
