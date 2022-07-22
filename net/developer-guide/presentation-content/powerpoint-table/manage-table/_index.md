---
title: Manage Table
type: docs
weight: 10
url: /net/manage-table/
keywords: "Table, create table, access table, table aspect ratio, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Create and manage table in PowerPoint presentations in C# or .NET"
---

## **Create Table from Scratch**
Aspose.Slides for .NET has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Iterate through each Cell to apply formatting to the Top, Bottom, Right, Left Borders.
- Merge first two cells of the first row of the table.
- Access the Text Frame of a Cell.
- Add some text to the Text Frame.
- Save the modified presentation as a PPTX file.

```c#
// Instantiate Presentation class that represents PPTX file
Presentation pres = new Presentation();

// Access first slide
ISlide sld = pres.Slides[0];

// Define columns with widths and rows with heights
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Add table shape to slide
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Set border format for each cell
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
// Merge cells 1 & 2 of row 1
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Add text to the merged cell
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Save PPTX to Disk
pres.Save("table.pptx", SaveFormat.Pptx);
```



## **Access Existing Table**
To access a table that already exists in a slide, please follow the steps below:

- Create an instance of `Presentation` class.
- Obtain the reference of a slide (that contains the table) by using its Position.
- Create an ITable object and set it to null.
- Iterate through all Shapes until you find the Table. If a slide contains only one table then you can simply check a shape and if it is found to be a Table then just typecast it as a Table object. But, if the slide contains more than one tables then it's better to find your desired table using its Alternative Text.
- After the Table is found, you can use ITable object to control the table. For example, in our case, we have added a new row in the desired table.
- Save the modified presentation as a PPT file.

```c#
// Instantiate Presentation class that represents PPTX// Instantiate Presentation class that represents PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Access the first slide
    ISlide sld = pres.Slides[0];

    // Initialize null TableEx
    ITable tbl = null;

    // Iterate through the shapes and set a reference to the table found
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Set the text of the first column of second row
    tbl[0, 1].TextFrame.Text = "New";

    //Write the PPTX to Disk
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **Align Text in Table**
Aspose.Slides for .NET has provided the simplest API to work with tables in an easiest way. To clone a table row or column in a slide, please follow the steps below:

- Create an instance of `Presentation` class.
- Obtain the reference of a slide by using its Index.
- Insert table in the slide.
- Access text frame.
- Access paragraph.
- Align text vertically.
- Save the presentation as a PPTX file.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();

// Get the first slide 
ISlide slide = presentation.Slides[0];

// Define columns with widths and rows with heights
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Add table shape to slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accessing the text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Create the Paragraph object for text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Create Portion object for paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligning the text vertically
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Save Presentation
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```



## **Set Text Formatting on Table Level**
Aspose.Slides for .NET has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells, please follow the steps below:

- Create an instance of `Presentation` class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set Table Cells Font Height.
- Set Table Cells Text Alignment and right Margin in one Call.
- Set Table Cells Vertical Type.
- Save the modified presentation as a PPTX file.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // let's say that the first shape on the first slide is a table

// setting table cells' font height
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// setting table cells' text alignment and right margin in one call
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// setting table cells' text vertical type
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **Numbering in Standard Table**
In a standard table numeration of cells is straightforward and zero-based. The first cell in a table is indexed as 0,0 (column 0, row 0). For example, the cells in a table with 4 columns and 4 rows will be numbered accordingly:

|(0, 0)|(1, 0)|(2, 0)|(3, 0)|
| :- | :- | :- | :- |
|(0, 1)|(1, 1)|(2, 1)|(3, 1)|
|(0, 2)|(1, 2)|(2, 2)|(3, 2)|
|(0, 3)|(1, 3)|(2, 3)|(3, 3)|

```c#
// Instantiate Presentation class that represents PPTX file
using (Presentation pres = new Presentation())
{

    // Access first slide
    ISlide sld = pres.Slides[0];

    // Define columns with widths and rows with heights
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Add table shape to slide
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Set border format for each cell
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

    //Write PPTX to Disk
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```




## **Lock Aspect Ratio of Table**
The aspect ratio of a geometric shape is the ratio of its sizes in different dimensions. You can lock aspect ratio of table using **ShapeLock.AspectRatioLocked** property. Below code example shows how to use this property.

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

