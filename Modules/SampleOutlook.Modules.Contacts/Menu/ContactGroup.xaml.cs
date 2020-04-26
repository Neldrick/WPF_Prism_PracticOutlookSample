using SampleOutlook.Core;
using System.Windows.Controls;

namespace SampleOutlook.Modules.Contacts.Menu
{
    /// <summary>
    /// Interaction logic for ContactGroup
    /// </summary>
    public partial class ContactGroup : TabItem, IOutlookBarGroup
    {
        public ContactGroup()
        {
            InitializeComponent();
        }
        public string DefaultNavigationPath => "ViewA";
    }
}
