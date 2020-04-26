using SampleOutlook.Moudles.Mail.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SampleOutlook.Core;
using SampleOutlook.Moudles.Mail.Menu;
using Prism.Mvvm;
using SampleOutlook.Moudles.Mail.ViewModels;

namespace SampleOutlook.Moudles.Mail
{
    public class MailModule : IModule
    {
        private readonly IRegionManager _regionManager;
        
        public MailModule(IRegionManager regionManger)
        {
            _regionManager = regionManger;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(HomeTab));
            _regionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(MailGroup));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<MailGroup, MailGroupViewModel>();
            containerRegistry.RegisterForNavigation<MailList, MailListViewModel>();
        }
    }
}