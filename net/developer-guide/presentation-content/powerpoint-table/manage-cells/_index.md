---
title: Manage Cells
type: docs
weight: 30
url: /net/manage-cells/
keywords: "Table, merged cells, split cells, image in table cell, C#, Csharp, Aspose.Slides for .NET"
description: "Table cells in PowerPoint presentations in C# or .NET"
---

## **Identify Merged Table Cell**

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Get the table from the first slide. 
3. Iterate through the table's rows and columns to find merge cells.
4. Print message when merged cells are found.

This C# code shows you how to identify merged table cells in a presentation:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
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
1. Create an instance of the `Presentation` class.
2. Get a slide's reference through its index. 
3. Define an array of columns with width.
4. Define an array of rows with height.
5. Add a table to the slide through the `AddTable` method.
6. Iterate through every cell to clear the top, bottom, right, and left borders.
7. Save the modified presentation as a PPTX file.

This C# code shows you how to remove the borders from table cells:

```c#
// Instantiates the Presentation class that represents a PPTX file
using (Presentation pres = new Presentation())
{
   // Accesses the first slide
    Slide sld = (Slide)pres.Slides[0];

    // Defines columns with widths and rows with heights
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Adds table shape to the slide
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Sets the border format for each cell
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Writes PPTX file to Disk
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Numbering in Merged Cells**
If we merge 2 pairs of cells (1, 1) x (2, 1) and (1, 2) x (2, 2), the resulting table will be numbered. This C# code demonstrates the process:

```c#
// Instantiates the Presentation class that represents a PPTX file
using (Presentation presentation = new Presentation())
{
    // Accesses the first slide
    ISlide sld = presentation.Slides[0];

    // Defines columns with widths and rows with heights
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Adds a table shape to the slide
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

    // Merges cells (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Merges cells (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

We then merge the cells further by merging (1, 1) and (1, 2). The result is a table containing a large merged cell in its center: 

```c#
// Instantiates the Presentation class that represents a PPTX file
using (Presentation presentation = new Presentation())
{
    // Accesses the first slide
    ISlide slide = presentation.Slides[0];

    // Defines columns with widths and rows with heights
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Adds a table shape to the slide
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Sets the border format for each cell
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

    // Merges cells (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Merges cells (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Merges cells (1, 2) x (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    //Writes the PPTX file to disk
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **Numbering in Splitted Cell**
In previous examples, when table cells got merged, the numeration or number system in other cells did not change. 

This time, we take a regular table (a table without merged cells) and then try to split cell (1,1) to get a special table. You may want to pay attention to this table's numbering, which may be considered strange. However, that is the way Microsoft PowerPoint numerates table cells and Aspose.Slides does the same thing. 

This C# code demonstrates the process we described:

```c#
// Instantiates the Presentation class that represents a PPTX file
using (Presentation presentation = new Presentation())
{
    // Accesses the first slide
    ISlide slide = presentation.Slides[0];

    // Defines columns with widths and rows with heights
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Adds a table shape to the slide
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Sets the border format for each cell
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

    // Merges cells (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Merges cells (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Splits cell (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    //Writes the PPTX file to disk
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **Change Table Cell Background Color**

This C# code shows you how to change a table cell's background color:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // create a new table
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // set the background color for a cell 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Add Image Inside Table Cell**

1. Create an instance of the`Presentation` class.
2. Get a slide's reference through its index.
3. Define an array of columns with width.
4. Define an array of rows with height.
5. Add a table to the slide through the `AddTable` method. 
6. Create a `Bitmap` object to hold the image file.
7. Add the bitmap image to the `IPPImage` object.
8. Set the `FillFormat` for the Table Cell to `Picture`.
9. Add the image to the table's first cell.
10. Save the modified presentation as a PPTX file

This C# code shows you how to place an image inside a table cell when creating a table:

~~Please check and confirm that this code works and review the steps.~~ XXX

```c#
// Instantiates the Presentation class that represents a PPTX file
using (Presentation presentation = new Presentation())
{

    // Accesses the first slide
    ISlide islide = presentation.Slides[0];

    // Defines columns with widths and rows with heights
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Adds a table shape to the slide
    ITable tbl = islide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Creates a bitmap Image object to hold the image file
    Bitmap image = new Bitmap("aspose-logo.jpg");

    // Creates an IPPImage object using the bitmap object
    IPPImage imgx1 = presentation.Images.AddImage(image);

    // Adds the image to the first table cell
    tbl[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    tbl[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    tbl[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = imgx1;

    // Saves the PPTX file to disk
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```
