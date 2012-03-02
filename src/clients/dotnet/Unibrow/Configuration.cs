using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Unibrow
{
    public class Configuration
    {
        private const string Undefined = "<undefined>";
        public ISource Source { get; private set;  }
        public ISubject Subject { get; private set;  }
        public KeyedCollection<string,IRecepient> Recipients { get; private set; }
        public Configuration()
            : this(new Sources.StaticName(Undefined), new Subjects.StaticName(Undefined, Undefined))
        {
        }
        public Configuration(ISource source, ISubject subject)
            : this(source, subject, new IRecepient[0])
        {

        }
        public Configuration(ISource source, ISubject subject, IEnumerable<IRecepient> recipients)
        {
            this.Source = source;
            this.Subject = subject;
            this.Recipients = new RecipientsCollection(recipients);
        }
        public Configuration AddRecipient(IRecepient recipient)
        {
            this.Recipients.Add(recipient);
            return this;
        }
        public Configuration SetDefaultSource(ISource source)
        {
            this.Source = source;
            return this;
        }
        public Configuration SetDefaultSubject(ISubject subject)
        {
            this.Subject = subject;
            return this;
        }

    }

    public class RecipientsCollection : KeyedCollection<string, IRecepient>
    {

        public RecipientsCollection(IEnumerable<IRecepient> recipients)
        {
            foreach (var r in recipients)
                base.Add(r);
        }
        protected override string GetKeyForItem(IRecepient item)
        {
            return item.Name;
        }
    }


}
