using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApplication1
{
    public class WorkPermitViewModel : INotifyPropertyChanged
    {
        private string _description;
        private string _name;
        private DateTime? _periodFrom;
        private DateTime? _periodTo;

        public WorkPermitViewModel(WorkPermit workPermit, IEnumerable<Attachment> attachments)
        {
            if (workPermit != null)
            {
                Name = workPermit.Name;
                Description = workPermit.Description;
                PeriodFrom = workPermit.PeriodFrom;
                PeriodTo = workPermit.PeriodTo;
            }

            if (attachments != null)
            {
                Attachments = new ObservableCollection<Attachment>(attachments);
            }
            else
            {
                Attachments = new ObservableCollection<Attachment>();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public DateTime? PeriodFrom
        {
            get { return _periodFrom; }
            set
            {
                _periodFrom = value;
                OnPropertyChanged();
            }
        }

        public DateTime? PeriodTo
        {
            get { return _periodTo; }
            set
            {
                _periodTo = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Attachment> Attachments { get; private set; }

        public void CreateAttachment()
        {
            var attachment = new Attachment();
            Attachments.Add(attachment);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public WorkPermit GetPersistanceEntity()
        {
            var permit = new WorkPermit
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Description = Description,
                PeriodFrom = PeriodFrom,
                PeriodTo = PeriodTo
            };
            return permit;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}