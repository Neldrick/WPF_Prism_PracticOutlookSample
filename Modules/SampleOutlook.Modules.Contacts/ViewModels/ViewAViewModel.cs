using Prism.Commands;
using Prism.Mvvm;
using SampleOutlook.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleOutlook.Modules.Contacts.ViewModels
{
    public class ViewAViewModel : ViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel()
        {
            Message = "View A from your Prism Module";
        }
    }
}
