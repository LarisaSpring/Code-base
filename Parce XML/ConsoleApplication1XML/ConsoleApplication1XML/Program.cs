using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApplication1XML
{
    public class GenerateXml
    {
        private static void Main()
        {
            var doc = new XDocument(
                new XElement("root",
                    new XElement("someNode", "someValue")
                    )
                );

            doc.Save(@"c:\foo.xml");

            Console.WriteLine(doc.ToString());
            Console.ReadKey();

        }
    }

}
