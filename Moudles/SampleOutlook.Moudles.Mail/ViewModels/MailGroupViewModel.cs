using Prism.Mvvm;
using SampleOutlook.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleOutlook.Moudles.Mail.ViewModels
{
    public class MailGroupViewModel: BindableBase
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

        public MailGroupViewModel()
        {
            GenerateMenu();
        }

		private void GenerateMenu()
        {
            Items = new ObservableCollection<NavigationItem>();
            var root = new NavigationItem(){Caption = "Personal Folder", NavigationPath="MailList"};
			root.Items.Add(new NavigationItem(){Caption ="Inbox", NavigationPath=""});
            root.Items.Add(new NavigationItem(){ Caption = "Delete", NavigationPath = "" });
            root.Items.Add(new NavigationItem(){ Caption = "Sent", NavigationPath = "" });
            Items.Add(root);
        }
    }
}
