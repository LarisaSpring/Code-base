using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfApplication2.Services;

namespace WpfApplication2.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly IWorkPermitRepository _workPermitRepository;

        public ObservableCollection<WorkPermitViewModel> WorkPermits { get; private set; }
    
        private WorkPermitViewModel _selectedPermit;

        public MainViewModel(IWorkPermitRepository workPermitRepository)
        {
            _workPermitRepository = workPermitRepository;

            var listWorkPermits = _workPermitRepository.FindAll().Select(x => new WorkPermitViewModel(x));

            WorkPermits = new ObservableCollection<WorkPermitViewModel>(listWorkPermits);
        }

        public WorkPermitViewModel SelectedPermit
        {
            get { return _selectedPermit; }
            set
            {
                _selectedPermit = value;
                OnPropertyChanged();
            }
        }

        public void SavePermit()
        {
            if (SelectedPermit != null)
            {
                _workPermitRepository.Save(SelectedPermit.GetPersistentEntry());
            }
        }

        public void DeletePermit()
        {
            if (SelectedPermit != null)
            {
                _workPermitRepository.Delete(SelectedPermit.Id);
                WorkPermits.Remove(SelectedPermit);
            }
        }

        public void SortPermits()
        {
            WorkPermits = new ObservableCollection<WorkPermitViewModel>(WorkPermits.OrderBy(x => x.Name));
            OnPropertyChanged(nameof(WorkPermits));
        }


        public void CreatePermit()
        {
            var permit = new WorkPermitViewModel(null);
            SelectedPermit = permit;
            WorkPermits.Add(permit);
        }


        ///////////////////////////////////////ICommand////////////////////
        
        private ICommand _doSomething;
        private ICommand _doSomething2;

        public ICommand DoSomethingCommand
            => _doSomething ?? (_doSomething = new DelegateCommand(obj =>
            {
                MessageBox.Show("Executing command");
            }));

        public ICommand DoSomethingCommand2
            => _doSomething2 ?? (_doSomething2 = new DelegateCommand(OnDoSomething));

        private void OnDoSomething(object o)
        {
            var name =((WorkPermitViewModel) o).Name;
            MessageBox.Show("Executing command 2  " + name);
        }

        ///////////////////////////////////////////////////////////////////

    }
}