using System;
using WpfApplication2.Models;

namespace WpfApplication2.ViewModels
{
    internal class WorkPermitViewModel : BaseViewModel
    {
        private string _description;
        private string _name;
        private DateTime? _periodFrom;
        private DateTime? _periodTo;

        public WorkPermitViewModel(WorkPermit workPermit)
        {
            if (workPermit != null)
            {
                Id = workPermit.Id;
                Name = workPermit.Name;
                Description = workPermit.Description;
                PeriodFrom = workPermit.PeriodFrom;
                PeriodTo = workPermit.PeriodTo;
            }
            else
            {
                Id = Guid.NewGuid();
            }
        }

        public Guid Id { get; }

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

        public WorkPermit GetPersistentEntry()
        {
            var permit = new WorkPermit
            {
                Id = Id,
                Name = Name,
                Description = Description,
                PeriodFrom = PeriodFrom,
                PeriodTo = PeriodTo
            };

            return permit;
        }
    }
}