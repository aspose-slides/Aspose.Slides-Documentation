---
title: Manage Table
type: docs
weight: 10
url: /net/manage-table/
keywords: "Table, create table, access table, table aspect ratio, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Create and manage table in PowerPoint presentations in C# or .NET"
---

A table in PowerPoint is an efficient way of displaying and portraying information. The information in a grid of cells (arranged in rows and columns) is straightforward and easy to understand.

Aspose.Slides provides the [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) class, [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) interface, [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) class, [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) interface, and other types to allow you to create, update, and manage tables in all kinds of presentations. 

## **Create Table from Scratch**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) object to the slide through the [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) method.
6. Iterate through each [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) to apply formatting to the top, bottom, right, and left borders.
7. Merge the first two cells of the table's first row. 
8. Access an [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/). 
9. Add some text to the [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/).
10. Save the modified presentation.

This C# code shows you how to create a table in a presentation:

```c#
// Instantiates a Presentation class that represents a PPTX file
Presentation pres = new Presentation();

// Accesses the first slide
ISlide sld = pres.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Adds a table shape to the slide
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Sets the border format for each cell
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// Merges cells 1 & 2 of row 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Adds some text to the merged cell
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Saves the presentation to Disk
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Numbering in Standard Table**

In a standard table, the numeration of cells is straightforward and zero-based. The first cell in a table is indexed as 0,0 (column 0, row 0). 

For example, the cells in a table with 4 columns and 4 rows are numbered this way:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This C# code shows you how to specify the numbering for cells in a table:

```c#
// Instantiates a Presentation class that represents a PPTX file
using (Presentation pres = new Presentation())
{

    // Accesses the first slide
    ISlide sld = pres.Slides[0];

    // Defines columns with widths and rows with heights
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Adds a table shape to slide
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Sets the border format for each cell
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Saves presentation to disk
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Access Existing Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.

2. Get a reference to the slide containing the table through its index. 

3. Create an [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) object and set it to null.

4. Iterate through all [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) objects till the table is found.

   If you suspect the slide you are dealing with contains a single table, you can simply check all the shapes it contains. When a shape is identified as a table, you can typecast it as a [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) object. But if the slide you are dealing with contains several tables, then you are better off searching for the table you need through its [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/).

5. Use the [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) object to work with the table. In the example below, we added a new row to the table.

6. Save the modified presentation.

This C# code shows you how to access and work with an existing table:

```c#
// Instantiates a Presentation class that represents a PPTX file
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Accesses the first slide
    ISlide sld = pres.Slides[0];

    // Initializes null TableEx
    ITable tbl = null;

    // Iterates through the shapes and sets a reference to the table found
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Sets the text for the first column of the second row
    tbl[0, 1].TextFrame.Text = "New";

    // Saves the modified presentation to disk
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Align Text in Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Get a slide's reference through its index. 
3. Add an [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) object to the slide. 
4. Access an [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) object from the table. 
5. Access the [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/).
6. Align the text vertically.
7. Save the modified presentation.

This C# code shows you how to align the text in a table:

```c#
// Creates an instance of the Presentation class
Presentation presentation = new Presentation();

// Gets the first slide 
ISlide slide = presentation.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Adds the table shape to the slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accesses the text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Creates the Paragraph object for the text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Creates the Portion object for paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligns the text vertically
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Saves the presentation to disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Set Text Formatting on Table Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Access an [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) object from the Slide.
4. Set the [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) for the text. 
5. Set the [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) and [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/). 
6. Set the [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Save the modified presentation. 

This C# code shows you how to apply your preferred formatting options to the text in a table:

```c#
// Creates an instance of the Presentation class
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Let's assume that the first shape on the first slide is a table

// Sets the table cells' font height
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Sets the table cells' text alignment and right margin in one call
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Sets the table cells' text vertical type
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Get Table Style Properties**

Aspose.Slides allows you to retrieve the style properties for a table so that you can use those details for another table or somewhere else. This C# code shows you how to get the style properties from a table preset style: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // change the default style preset theme 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Lock Aspect Ratio of Table**

The aspect ratio of a geometric shape is the ratio of its sizes in different dimensions. Aspose.Slides provided the `AspectRatioLocked` property to allow you to lock the aspect ratio setting for tables and other shapes. 

This C# code shows you how to lock the aspect ratio for a table:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // invert

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**

Yes. The table exposes a [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) property, and paragraphs have [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). Using both ensures the correct RTL order and rendering inside cells.

**How can I prevent users from moving or resizing a table in the final file?**

Use [shape locks](/slides/net/applying-protection-to-presentation/) to disable moving, resizing, selection, etc. These locks apply to tables as well.

**Is inserting an image inside a cell as a background supported?**

Yes. You can set a [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) for a cell; the image will cover the cell area according to the chosen mode (stretch or tile).
