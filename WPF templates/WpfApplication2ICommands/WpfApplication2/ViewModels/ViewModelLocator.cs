
using Microsoft.Practices.Unity;

namespace WpfApplication2.ViewModels
{
    internal class ViewModelLocator
    {
        private readonly IoCContainer _ioCContainer; 

        public ViewModelLocator()
        {
            _ioCContainer = new IoCContainer();
        }

        public MainViewModel MainViewModel => _ioCContainer.Resolve<MainViewModel>();
    }
}