using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SampleOutlook.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleOutlook.Moudles.Mail.ViewModels
{
    public class MailListViewModel : ViewModelBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public MailListViewModel()
        {

        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            Title = navigationContext.Parameters.GetValue<string>("id");
        }
    }
}
