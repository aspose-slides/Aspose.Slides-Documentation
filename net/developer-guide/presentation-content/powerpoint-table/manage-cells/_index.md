---
title: Manage Cells
type: docs
weight: 30
url: /net/manage-cells/
---

## **Identify Merged Table Cell**
Aspose.Slides for .NET has provided the simplest API to identify merge table cells in an easiest way. To identify merge cells in table, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the the table from first slide.
- Iterate through row and columns of table to find out merge cells.
- Print Message if cells are merged.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Tables();

using (Presentation pres = new Presentation(dataDir + "SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // assuming that Slide#0.Shape#0 is a table
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```



## **Remove Table Cells Border**
Aspose.Slides for .NET has provided the simplest API to create tables in an easiest way. In order to remove the borders from table cells, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Iterate through each Cell to clear the Top, Bottom, Right, Left Borders.
- Save the modified presentation as a PPTX file.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Tables();

// Create directory if it is not already present.
bool IsExists = System.IO.Directory.Exists(dataDir);
if (!IsExists)
    System.IO.Directory.CreateDirectory(dataDir);

// Instantiate Presentation class that represents PPTX file
using (Presentation pres = new Presentation())
{
   // Access first slide
    Slide sld = (Slide)pres.Slides[0];

    // Define columns with widths and rows with heights
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Add table shape to slide

    // Add table shape to slide
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Set border format for each cell
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    //Write PPTX to Disk
    pres.Save(dataDir + "table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **Numbering in Merged Cells**
If we merge 2 pairs of cells (1, 1) x (2, 1) and (1, 2) x (2, 2) then table will be numbered and look like this:

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Tables();

// Instantiate Presentation class that represents PPTX file
using (Presentation presentation = new Presentation())
{
    // Access first slide
    ISlide sld = presentation.Slides[0];

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

    // Merging cells (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Merging cells (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save(dataDir + "MergeCells_out.pptx", SaveFormat.Pptx);
}
```



Let's continue merging cells. Now we merge (1, 1) and (1, 2). As a result we have table with large merged cell in the middle:

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Tables();

// Instantiate Presentation class that represents PPTX file
using (Presentation presentation = new Presentation())
{

    // Access first slide
    ISlide slide = presentation.Slides[0];

    // Define columns with widths and rows with heights
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Add table shape to slide
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Set border format for each cell
    foreach (IRow row in table.Rows)
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

    // Merging cells (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Merging cells (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Merging cells (1, 2) x (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    //Write PPTX to Disk
    presentation.Save(dataDir + "MergeCells1_out.pptx", SaveFormat.Pptx);
}
```



## **Numbering in Splitted Cell**
We could see in previous example when table cells are merged then numeration of other cells is not changed.Now let's return to our normal table (without merged cells) and try to split cell (1, 1). The result is strange enough but that is the way MS PowerPoint and Aspose.Slides for .NET numerate table cells.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Tables();

// Instantiate Presentation class that represents PPTX file
using (Presentation presentation = new Presentation())
{
    // Access first slide
    ISlide slide = presentation.Slides[0];

    // Define columns with widths and rows with heights
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Add table shape to slide
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Set border format for each cell
    foreach (IRow row in table.Rows)
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

    // Merging cells (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Merging cells (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // split cell (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    //Write PPTX to Disk
    presentation.Save(dataDir + "CellSplit_out.pptx", SaveFormat.Pptx);
}
```



## **Add Image Inside Table Cell**
Aspose.Slides for .NET has provided the simplest API to create tables in an easiest way. To add image in a table cell while creating a new table, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Create a Bitmap object to hold the image file.
- Add the Bitmap image to IPPImage Object.
- Set Fill Format of the Table Cell as Picture.
- Add the image to the first cell of the table.
- Save the modified presentation as a PPTX file

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Tables();

// Instantiate Presentation class object
Presentation presentation = new Presentation();

// Access first slide
ISlide islide = presentation.Slides[0];

// Define columns with widths and rows with heights
double[] dblCols = { 150, 150, 150, 150 };
double[] dblRows = { 100, 100, 100, 100, 90 };

// Add table shape to slide
ITable tbl = islide.Shapes.AddTable(50, 50, dblCols, dblRows);

// Creating a Bitmap Image object to hold the image file
Bitmap image = new Bitmap(dataDir + "aspose-logo.jpg");

// Create an IPPImage object using the bitmap object
IPPImage imgx1 = presentation.Images.AddImage(image);

// Add image to first table cell
tbl[0, 0].FillFormat.FillType = FillType.Picture;
tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

// Save PPTX to Disk
presentation.Save(dataDir + "Image_In_TableCell_out.pptx", SaveFormat.Pptx);
```

