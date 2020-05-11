using SampleOutlook.Business;
using SampleOutlook.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleOutlook.Services
{
    public class MailServices : IMailServices
    {
        static List<MailMessage> InboxItems = new List<MailMessage>()
        {
            new MailMessage()
            {
                Id = 1 ,
                From = "tester1@test.com",
                To = new ObservableCollection<string>(){"tester@to.com", "tester2@to.com"},
                Subject = "This is a test email",
                Body = "Testing body",
                DateSent = DateTime.Now.AddHours(-1)
            },
            new MailMessage()
            {
                Id = 2 ,
                From = "tester2@test.com",
                To = new ObservableCollection<string>(){"tester3@to.com", "tester4@to.com"},
                Subject = "This is a test email2",
                Body = "Testing body2",
                DateSent = DateTime.Now.AddHours(-2)
            },
            new MailMessage()
            {
                Id = 3 ,
                From = "tester3@test.com",
                To = new ObservableCollection<string>(){"tester5@to.com", "tester6@to.com"},
                Subject = "This is a test email3",
                Body = "Testing body3",
                DateSent = DateTime.Now.AddHours(-3)
            },
        };

        static List<MailMessage> SentItems = new List<MailMessage>();
        static List<MailMessage> DeletedItems = new List<MailMessage>();
        public IList<MailMessage> GetInboxItems()
        {
            return InboxItems;
        }

        IList<MailMessage> IMailServices.GetDeletedItems()
        {
            return DeletedItems;
        }

        IList<MailMessage> IMailServices.GetSentItems()
        {
            return SentItems;
        }
    }
}
