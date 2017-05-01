using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApplication1
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private readonly IWorkPermitRepository _workPermitRepository;
        private readonly IAttachmentRepository _attachmentRepository;
        private WorkPermitViewModel _selectedPermit;
        private readonly SemaphoreSlim _initLock = new SemaphoreSlim(1, 1);
        private readonly SemaphoreSlim _createLock = new SemaphoreSlim(0, 1);

        public MainViewModel(IWorkPermitRepository workPermitRepository, IAttachmentRepository attachmentRepository)
        {
            _workPermitRepository = workPermitRepository;
            _attachmentRepository = attachmentRepository;
            WorkPermits = new ObservableCollection<WorkPermitViewModel>();
        }

        public async Task Initialize()
        {
            if (!await _initLock.WaitAsync(0))
            {
                return;
            }
            
            var list = await _workPermitRepository.FindAll();

            foreach (var workPermit in list)
            {
                var attachment = (await _attachmentRepository.FindAll()).Where(a => a.WorkPermitId == workPermit.Id);
                var permit = new WorkPermitViewModel(workPermit, attachment);
                WorkPermits.Add(permit);
            }

            _createLock.Release();
        }

        public ObservableCollection<WorkPermitViewModel> WorkPermits { get; }

        public WorkPermitViewModel SelectedPermit
        {
            get { return _selectedPermit; }
            set
            {
                _selectedPermit = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SavePermit()
        {
            if (SelectedPermit != null)
            {
                _workPermitRepository.Save(SelectedPermit.GetPersistanceEntity());
            }
        }

        public async Task CreateWorkPermit()
        {
            await _createLock.WaitAsync();
            var permit = new WorkPermitViewModel(null, null);
            SelectedPermit = permit;
            WorkPermits.Add(permit);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}