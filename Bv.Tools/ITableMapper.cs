using System;

namespace Bv.Tools.Tables
{
     public interface ITableMapper<T> : ITableWriter
     {
         ITableMapper<T> Field(string name, Func<T, string> f);
     }
}