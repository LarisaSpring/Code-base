using Microsoft.Practices.Unity;

namespace WpfApplication1
{
    public class IoCContainer : UnityContainer
    {
        public IoCContainer()
        {
            this.RegisterType<IWorkPermitRepository, WorkPermitRepository>();
            this.RegisterType<IAttachmentRepository, AttachmentRepository>();
        }
    }
}