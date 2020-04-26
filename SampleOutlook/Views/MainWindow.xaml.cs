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
        private readonly IApplicationCommands _applicationCommands;

        public MainWindow(IApplicationCommands applicationCommands)
        {
            InitializeComponent();
            _applicationCommands = applicationCommands;
        }

        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var group = ((TabControl)sender).Items[((TabControl)sender).SelectedIndex] as IOutlookBarGroup;
                if(group != null)
                {
                    _applicationCommands.NavigateCommand.Execute(group.DefaultNavigationPath);
                }
            }
        }
    }
}
