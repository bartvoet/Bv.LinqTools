using System;
using System.Collections.Generic;
using Bv.Tools.Tables;
using Bv.Tools.Cons.Tables;

namespace Bv.Tools.Cons.Demo
{
 
     public class Blabla
     {
         public string hello { get; set; }
         public string world { get; set; }
     }


     class Program
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

         static void Main(string[] args)
         {
             ITableFactory tableSource = new TextTableSource(Console.Out);

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
             SimpleTableMapper.CreateTableMapper(b)
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

			//responsability: writer zet waardes om naar primitieve waardes (number, date  of string)

             // TODO: still add styles...
             //Constructor with optional... ()
             //TODO: CENTER, LEFT, RIGHT (enums)
             //TODO: FORMATTING STRINGS
             //TODO: work with numbers
             // after this a menu-application
         }
     }
}



