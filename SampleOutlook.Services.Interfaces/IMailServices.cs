using SampleOutlook.Business;
using System;
using System.Collections.Generic;

namespace SampleOutlook.Services.Interfaces
{
    public interface IMailServices
    {
        IList<MailMessage> GetInboxItems();
        IList<MailMessage> GetSentItems();
        IList<MailMessage> GetDeletedItems();
    }
}
