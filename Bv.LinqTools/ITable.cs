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
         ITable NewTable();
     }

     public interface ITable
     {
         ITable Field(int size = 50);
         ITable Fields(params int[] size);
         ITable WriteHeader(params object[] list);
         ITable WriteRow(params object[] list);
         ITable WriteEnd();
     }
}