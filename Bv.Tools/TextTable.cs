using System;
using System.Collections.Generic;
using System.IO;
using Bv.Tools.Tables;

namespace Bv.Tools.Cons.Tables
{
     public class TextTableSource : ITableFactory
     {
         private TextWriter Writer;
         public TextTableSource(TextWriter writer)
         {
             this.Writer = writer;
         }

         public ITable NewTable()
         {
             return new TextTable(this.Writer);
         }
     }

     class TextTable : ITable
     {

         private TableStyle HeaderStyle;
         private TableStyle CellStyle;

         private IList<ObjectConsoleField> Columns = new List<ObjectConsoleField>();

         private TextWriter Writer;

         public ITable Field(int size)
         {
             Columns.Add(new ObjectConsoleField(size));
             return this;
         }

         public ITable Fields(params int[] sizes)
         {
             foreach (int size in sizes)
             {
                 Columns.Add(new ObjectConsoleField(size));
             }
             return this;
         }

         public ITable WithHeaderStyle(TableStyle style)
         {
             this.HeaderStyle = style;
             return this;
         }

         public ITable WithCellStyle(TableStyle style)
         {
             this.CellStyle = style;
             return this;
         }

         private char VerticalChar = '|';
         private char CornerChar = '+';
         private char HorizontalChar = '-';

         internal class ObjectConsoleField
         {
             private int Size;
             private TableAlignment Alignment;

             internal ObjectConsoleField(int size = 50,TableAlignment alignment = TableAlignment.Left)
             {
                 this.Size = size;
                 this.Alignment = alignment;
             }

             internal int Length()
             {
                 return Size;
             }

             internal string FormatField(object actualValue)
             {
                 String printValue = actualValue?.ToString()??"";

                 switch(this.Alignment) {
                     case TableAlignment.Left: 
					 	return printValue.PadRight(Size);
                     case TableAlignment.Right: 
					 	return printValue.PadLeft(Size);
//case TableAlignment.Centered: return actualValue.ToString().PadLeft(Size);
                     default: return printValue.PadRight(Size);
                 }
             }
         }

         public TextTable(TextWriter writer)
         {
             this.Writer = writer;
         }

         public ITable WriteHeader(params object[] list)
         {
             DrawLine();
             WriteRow(list);
             return DrawLine();
         }

         public ITable WriteRow(params object[] list)
         {
             int counter = 0;

             foreach (ObjectConsoleField field in this.Columns)
             {
                 Console.Write(VerticalChar + " ");
                 this.Writer.Write(field.FormatField(counter < list.Length ? list[counter] : ""));
                 counter++;
                 Console.Write(" ");
             }
             Console.WriteLine(VerticalChar);
             return this;
         }

         public ITable DrawLine()
         {
             foreach (ObjectConsoleField field in this.Columns)
             {
                 Console.Write("" + CornerChar + HorizontalChar);
                 this.Writer.Write(new string(HorizontalChar,field.Length()));
                 Console.Write("-");
             }
             Console.WriteLine(CornerChar);
             return this;
         }

         public ITable WriteEnd()
         {
             return DrawLine();
         }
     }
}
