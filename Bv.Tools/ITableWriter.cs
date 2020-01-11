namespace Bv.Tools.Tables
{
     public interface ITableWriter
     {
         void WriteTo(ITableFactory destination);
     }
}