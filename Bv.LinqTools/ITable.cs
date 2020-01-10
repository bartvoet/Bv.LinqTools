namespace Ucll.Tools.Tables
{
    public enum TableAlignment {
         Centered, Left, Right
     }

     public class TableStyle
     {
         public TableAlignment Alignment {get;set;}
     }

     public interface ITableFactory
     {
         public ITable NewTable();
     }

     public interface ITable
     {
         public ITable Field(int size = 50);
         public ITable Fields(params int[] size);
         public ITable WriteHeader(params object[] list);
         public ITable WriteRow(params object[] list);
         public ITable WriteEnd();
     }
}