using SampleOutlook.Business;
using SampleOutlook.Core;
using System.Windows.Controls;

namespace SampleOutlook.Moudles.Mail.Menu
{
    /// <summary>
    /// Interaction logic for MailGroup.xaml
    /// </summary>
    public partial class MailGroup : TabItem, IOutlookBarGroup
    {
        public MailGroup()
        {
            InitializeComponent();
        }

        public string DefaultNavigationPath
        {
            get
            {
                var item = _dataTree.SelectedItem;
                if(item != null)
                {
                    return ((NavigationItem)item).NavigationPath;
                }
                return "MailList?id=Default";
            }
            
        }
    }
}
