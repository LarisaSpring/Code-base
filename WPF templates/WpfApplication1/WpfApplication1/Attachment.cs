using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Attachment
    {
        public Guid Id { get; set; }

        public Guid WorkPermitId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
    }
}
