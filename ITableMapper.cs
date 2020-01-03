using System;

namespace Ucll.Tools.Tables
{
     public interface ITableMapper<T> : ITableWriter
     {
         public ITableMapper<T> Field(string name, Func<T, string> f);
     }
}