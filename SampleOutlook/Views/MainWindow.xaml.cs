using Prism.Regions;
using SampleOutlook.Core;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace SampleOutlook.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRegionManager _regionManager;

        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            _regionManager = regionManager;
        }

        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var group = ((TabControl)sender).Items[((TabControl)sender).SelectedIndex] as IOutlookBarGroup;
                if(group != null)
                {
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, group.DefaultNavigationPath);
                }
            }
        }
    }
}
