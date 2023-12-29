---
title: Manage Rows and Columns
type: docs
weight: 20
url: /net/manage-rows-and-columns/
keywords: "Table, table rows and columns, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Manage table rows and columns in PowerPoint presentations in C# or .NET"

---

To allow you to manage a table's rows and columns in a PowerPoint presentation, Aspose.Slides provides the [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) class, [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) interface, and many other types. 

## **Set First Row as Header**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class and load the presentation. 
2. Get a slide's reference through its index. 
3. Create an [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) object and set it to null.
4. Iterate through all [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) objects to find the relevant table. 
5. Set the table's first row as its header. 

This C# code shows you how to set a table's first row as its header:

```c#
// Instantiates the Presentation class
Presentation pres = new Presentation("table.pptx");

// Accesses the first slide
ISlide sld = pres.Slides[0];

// Initializes the null TableEx
ITable tbl = null;

// Iterates through the shapes and sets a reference to the table
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Sets the first row of a table as its header
tbl.FirstRow = true;

// Saves the presentation to disk
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **Clone Table's Row or Column**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class and load the presentation, 
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) object to the slide through the [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) method.
6. Clone the table row.
7. Clone the table column.
8. Save the modified presentation.

This C# code shows you how to clone a PowerPoint table's row or column:

```c#
 // Instantiates the Presentation class
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Accesses the first slide
    ISlide sld = presentation.Slides[0];

    // Defines columns with widths and rows with heights
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Adds a table shape to the slide
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Adds some text to the row 1 cell 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Adds some text to the row 1 cell 2
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Clones Row 1 at the end of table
    table.Rows.AddClone(table.Rows[0], false);

    // Adds some text to the row 2 cell 1
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Adds some text to the row 2 cell 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Clones Row 2 as the 4th row of table
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Clones first column at the end
    table.Columns.AddClone(table.Columns[0], false);

    // Clones 2nd column at 4th column index
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Saves the presentation to disk 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Remove Row or Column from Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class and load the presentation, 
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) object to the slide through the [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) method.
6. Remove the table row.
7. Remove the table column.
8. Save the modified presentation. 

This C# code shows you how to remove a row or column from a table:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Set Text Formatting on Table Row Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class and load the presentation, 
2. Get a slide's reference through its index. 
3. Access the relevant [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) object from the slide. 
4. Set the first-row cells' [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/). 
5. Set the first-row cells' [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) and [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/). 
6. Set the second-row cells' [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Save the modified presentation.

This C# code demonstrates the operation.

```c#
// Creates an instance of the Presentation class
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Let's assume that the first shape on the first slide is a table

// Sets first row cells' font height
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Sets the first row cells' text alignment and right margin
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Sets the second row cells' text vertical type
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Saves the presentation to disk
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Set Text Formatting on Table Column Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class and load the presentation, 
2. Get a slide's reference through its index. 
3. Access the relevant [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) object from the slide. 
4. Set the first-column cells' [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/). 
5. Set the first-column cells' [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) and [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/). 
6. Set the second-column cells' [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Save the modified presentation. 

This C# code demonstrates the operation: 

```c#
// Creates an instance of the Presentation class
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Let's assume that the first shape on the first slide is a table

// Sets the first column cells' font height
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Sets the first column cells' text alignment and right margin in one call
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Sets the second column cells' text vertical type
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Saves the presentation to disk
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **Get Table Style Properties**

Aspose.Slides allows you to retrieve the style properties for a table so that you can use those details for another table or somewhere else. This C# code shows you how to get the style properties from a table preset style: xxx

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // change the default style preset theme 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

