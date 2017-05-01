using Microsoft.Practices.Unity;
using WpfApplication2.Services;

namespace WpfApplication2
{
    public class IoCContainer : UnityContainer
    {
        public IoCContainer()
        {
            this.RegisterType<IWorkPermitRepository, WorkPermitRepository>();
        }
    }
}