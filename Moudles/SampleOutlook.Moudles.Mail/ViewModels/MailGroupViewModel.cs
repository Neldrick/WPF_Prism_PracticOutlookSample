using Prism.Commands;
using Prism.Mvvm;
using SampleOutlook.Business;
using SampleOutlook.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleOutlook.Moudles.Mail.ViewModels
{
    public class MailGroupViewModel: ViewModelBase
    {
        private string _title = "HEEEE testing";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<NavigationItem> _items;
        public ObservableCollection<NavigationItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private DelegateCommand<NavigationItem> _selectedCommand;
        private readonly IApplicationCommands _applicationCommands;

        public DelegateCommand<NavigationItem> SelectedCommand =>
            _selectedCommand ?? (_selectedCommand = new DelegateCommand<NavigationItem>(ExecuteSelectedCommand));

        public MailGroupViewModel(IApplicationCommands applicationCommands)
        {
            GenerateMenu();
            _applicationCommands = applicationCommands;
        }
        void ExecuteSelectedCommand(NavigationItem navigationItem)
        {
            if(navigationItem != null)
            {
                _applicationCommands.NavigateCommand.Execute(navigationItem.NavigationPath);
            }
        }

		private void GenerateMenu()
        {
            Items = new ObservableCollection<NavigationItem>();
            var root = new NavigationItem(){Caption = "Personal Folder", NavigationPath="MailList?id=Default"};
			root.Items.Add(new NavigationItem(){Caption ="Inbox", NavigationPath= "MailList?id=Inbox" });
            root.Items.Add(new NavigationItem(){ Caption = "Delete", NavigationPath = "MailList?id=Delete" });
            root.Items.Add(new NavigationItem(){ Caption = "Sent", NavigationPath = "MailList?id=Sent" });
            Items.Add(root);
        }
    }
}
