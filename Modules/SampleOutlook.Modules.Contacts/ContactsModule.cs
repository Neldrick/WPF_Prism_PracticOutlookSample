using SampleOutlook.Modules.Contacts.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SampleOutlook.Modules.Contacts.Menu;
using SampleOutlook.Core;

namespace SampleOutlook.Modules.Contacts
{
    public class ContactsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ContactsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(ContactGroup));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}