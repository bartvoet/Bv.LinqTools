using System;
using Xunit;
using Bv.Tools.Tables;
using Bv.Tools.Cons.Tables;
using System.Collections.Generic;

namespace Bv.LinqTools.Tests
{
    public class Blabla
    {
        public string hello { get; set; }
        public string world { get; set; }
    }

    public class SimpleTableMapperTest
    {
        public static List<T> CreateList<T>(params T[] items)
        {
            List<T> result = new List<T>();
            foreach (T item in items)
            {
                result.Add(item);
            }
            return result;
        }


        [Fact]
        public void ConstructorDoesntAcceptANullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new SimpleTableMapper<String>(null));
        }
 /*           ITableFactory tableSource = new TextTableSource(Console.Out);

            new TextTableSource(Console.Out)
                .NewTable()
                .Field(20).Field(10)
                .WriteHeader("a", "b")
                .WriteRow("a", 1)
                .WriteRow("c", "d")
                .WriteRow("e", "f")
                .WriteEnd();

            List<Blabla> b = new List<Blabla>() {
                 new Blabla{ hello = "test",world = "a" },
                 new Blabla{ hello = "lala",world = "a" },
             };

            //new SimpleTableWriter<T>(b)
            SimpleTableWriter.CreateWriter(b)
                .Field("a", (a) => a.hello)  // ITableMapper extends TableWriter
                .Field("b", (a) => a.world)
                .WriteTo(tableSource); //TableWriter

            PropertiesTableWriter.CreateWriter(b)
                 .WriteTo(tableSource);

            var anomymous = CreateList(
                new { t = "test", world = "aa" },
                new { t = "lala", world = "a" });

            PropertiesTableWriter.CreateWriter(anomymous)
                 .WriteTo(tableSource);
*/
        
    }
}
