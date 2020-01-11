using System;
using System.Collections.Generic;

namespace Bv.Tools.Tables
{
     public class PropertiesTableWriter
     {
         public static PropertiesTableWriter<B> CreateWriter<B>(IEnumerable<B> instance)
         {
             return new PropertiesTableWriter<B>(instance);
         }
     }

     public class PropertiesTableWriter<T> : ITableWriter
     {
         private IEnumerable<T> Source;
         private SimpleTableMapper<T> TableWriter;

         public PropertiesTableWriter(IEnumerable<T> e)
         {
             this.Source = e;
             this.TableWriter = new SimpleTableMapper<T>(Source);
             Type[] at = e.GetType().GetGenericArguments();
             Type t = at[0];
             foreach (var p in t.GetProperties())
             {
                 this.TableWriter.Field(p.Name, (a) => p.GetValue(a).ToString());
             }
         }

         public void WriteTo(ITableFactory source)
         {
             this.TableWriter.WriteTo(source);
         }
     }
}