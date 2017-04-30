using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo(2);
            var foo2 = new Foo(2);
            Console.WriteLine(foo.Equals(foo2));
            Console.ReadKey();
        }
    }

    public class Foo
    {
        public int FooId { get; }
        public string FooName { get; set; }

        public Foo(int id)
        {
            FooId = id;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Foo))
            {
                return false;
            }
           
            Foo fooItem = obj as Foo;

            return fooItem.FooId == this.FooId;
        }

        public override int GetHashCode()
        {
            return this.FooId.GetHashCode();
        }
    }
}
