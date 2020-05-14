using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SampleOutlook.Business;
using SampleOutlook.Core;
using SampleOutlook.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SampleOutlook.Moudles.Mail.ViewModels
{
    public class MailListViewModel : ViewModelBase
    {
        private ObservableCollection<MailMessage> _messages;
        private readonly IMailServices _mailServices;
        private readonly IDialogService _dialogService;

        public ObservableCollection<MailMessage> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        private MailMessage _seelectedMessage;
        public MailMessage SelectedMessage
        {
            get { return _seelectedMessage; }
            set { SetProperty(ref _seelectedMessage, value); }
        }

        private DelegateCommand<string> _messageCommand;
        public DelegateCommand<string> MessageCommand =>
            _messageCommand ?? (_messageCommand = new DelegateCommand<string>(ExecuteMessageCommand));

        void ExecuteMessageCommand(string parameter)
        {
            _dialogService.ShowDialog("MessageView", null, null);
        }
        public MailListViewModel(IMailServices mailServices, IDialogService dialogService)
        {
            _mailServices = mailServices;
            _dialogService = dialogService;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            var folder = navigationContext.Parameters.GetValue<string>(FolderParameters.FolderKey);

            // this can be putting into business logic to let db store it an make everthing simple
            switch (folder)
            {
                case FolderParameters.Inbox:
                    Messages = new ObservableCollection<MailMessage>(_mailServices.GetInboxItems());
                    break;
                case FolderParameters.Deleted:
                    Messages = new ObservableCollection<MailMessage>(_mailServices.GetDeletedItems());
                    break;
                case FolderParameters.Sent:
                    Messages = new ObservableCollection<MailMessage>(_mailServices.GetSentItems());
                    break;
                default:
                    break;
            }
        }
    }
}
