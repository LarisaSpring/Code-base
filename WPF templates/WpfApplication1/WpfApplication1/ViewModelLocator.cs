using Microsoft.Practices.Unity;

namespace WpfApplication1
{
    internal class ViewModelLocator
    {
        private readonly IoCContainer _iocContainer;

        public ViewModelLocator()
        {
            _iocContainer = new IoCContainer();
        }

        public MainViewModel MainViewModel => _iocContainer.Resolve<MainViewModel>();
    }
}