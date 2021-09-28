---
title: Manage Rows and Columns
type: docs
weight: 20
url: /net/manage-rows-and-columns/
---

## **Set First Row as Header**
Aspose.Slides for .NET provides the feature to set the first row as header using the following methods of [ITable](https://apireference.aspose.com/net/slides/aspose.slides/itable) interface. Below code example shows how to set the first row as a header.

```c#
// Instantiate Presentation class that represents PPTX
Presentation pres = new Presentation("table.pptx");

// Access the first slide
ISlide sld = pres.Slides[0];

// Initialize null TableEx
ITable tbl = null;

// Iterate through the shapes and set a reference to the table found
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}


//Set the first row of a table as header with a special formatting.
tbl.FirstRow = true;
```




## **Clone Row or Column of Table**
Aspose.Slides for .NET has provided the simplest API to work with tables in an easiest way. To clone a table row or column in a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using addTable method exposed by IShapes object.
- Clone table row.
- Clone table column.
- Save the presentation as a PPTX file.

```c#
 // Instantiate presentationentation class that representationents PPTX file
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Access first slide
    ISlide sld = presentation.Slides[0];

    // Define columns with widths and rows with heights
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Add table shape to slide
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);


    // Add text to the row 1 cell 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Add text to the row 1 cell 2
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Clone Row 1 at end of table
    table.Rows.AddClone(table.Rows[0], false);

    // Add text to the row 2 cell 1
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Add text to the row 2 cell 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";


    // Clone Row 2 as 4th row of table
    table.Rows.InsertClone(3,table.Rows[1], false);

    //Cloning first column at end
    table.Columns.AddClone(table.Columns[0], false);

    //Cloning 2nd column at 4th column index
    table.Columns.InsertClone(3,table.Columns[1], false);
    

    // Write PPTX to Disk
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Remove Row or Column from Table**
Aspose.Slides for .NET has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Remove table row.
- Remove table column.
- Write the modified presentation as a PPTX file.

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
Aspose.Slides for .NET has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells on row level, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set first row Cells Font Height.
- Set first row Cells Text Alignment and right Margin in one Call.
- Set second row Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // let's say that the first shape on the first slide is a table

// setting first row cells' font height
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// setting first row cells' text alignment and right margin in one call
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// setting second row cells' text vertical type
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Set Text Formatting on Table Column Level**
Aspose.Slides for .NET has provided the simplest API to create tables in an easiest way. In order to remove Text Formatting from table cells on Column level, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Access Table from Slide.
- Set first Column Cells Font Height.
- Set first Column Cells Text Alignment and right Margin in one Call.
- Set second Column Cells text Vertical Type.
- Save the modified presentation as a PPTX file.

```c#
// Create an instance of Presentation class
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // let's say that the first shape on the first slide is a table

// setting first column cells' font height
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// setting first column cells' text alignment and right margin in one call
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// setting second column cells' text vertical type
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

