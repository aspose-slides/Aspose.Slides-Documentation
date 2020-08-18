---
title: Creating a Table from Scratch in Slide
type: docs
weight: 10
url: /cpp/creating-a-table-from-scratch-in-slide/
---

{{% alert color="primary" %}} 

This page is no longer maintained. For an updated page, please visit <http://www.aspose.com/docs/display/slidesnet/Adding%2C+Updating+and+Manipulating+Tables>

{{% /alert %}} {{% alert color="primary" %}} 

Aspose.Slides for C++ also facilitates developers to add custom tables in their slides from scratch. This is one of the newest features added in Aspose.Slides for C++ since last few versions. In this topic, we will explain that how can developers create and add tables to their slides using Aspose.Slides for C++.

This article explains how to create different types of charts:

- [Creating Table from Scratch](/slides/cpp/creating-a-table-from-scratch-in-slide/).
- [Remove Table Borders](/slides/cpp/creating-a-table-from-scratch-in-slide/).

{{% /alert %}} 
#### **Creating Table from Scratch**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. To create a table in a slide and perform some basic operations on the table, please follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide by using its Index
- Define Array of Columns with Width
- Define Array of Rows with Height
- Add a Table to the slide using AddTable method exposed by IShapes object
- Iterate through each Cell to apply formatting to the Top, Bottom, Right, Left Borders
- Merge first two cells of the first row of the table
- Access the Text Frame of a Cell
- Add some text to the Text Frame
- Savethe modified presentation as a PPTX file
#### **Example**
[**C#**]()

``` cpp

 //Instantiate Presentation class that represents PPTX file

using (Presentation pres = new Presentation())

{

    //Access first slide

    ISlide sld = pres.Slides[0];

    //Define columns with widths and rows with heights

    double[] dblCols = { 50, 50, 50 };

    double[] dblRows = { 50, 30, 30, 30, 30 };

    //Add table shape to slide

    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    //Set border format for each cell

    foreach (IRow row in tbl.Rows)

        foreach (ICell cell in row)

        {

            cell.BorderTop.FillFormat.FillType = FillType.Solid;

            cell.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;

            cell.BorderTop.Width = 5;

            cell.BorderBottom.FillFormat.FillType = FillType.Solid;

            cell.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;

            cell.BorderBottom.Width = 5;

            cell.BorderLeft.FillFormat.FillType = FillType.Solid;

            cell.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;

            cell.BorderLeft.Width = 5;

            cell.BorderRight.FillFormat.FillType = FillType.Solid;

            cell.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;

            cell.BorderRight.Width = 5;

        }

    //Merge cells 1 & 2 of row 1

    tbl.MergeCells(tbl[0, 0], tbl[1, 0], false);

    //Add text to the merged cell

    tbl[0, 0].TextFrame.Text = "Merged Cells";

    //Write PPTX to Disk

    pres.Save(path + "table.pptx", SaveFormat.Pptx);

}

```

[**Visual Basic**]()

``` cpp

 'Instantiate Presentation class that represents PPTX file

Using pres As New Presentation()

	'Access first slide

	Dim sld As ISlide = pres.Slides(0)

	'Define columns with widths and rows with heights

	Dim dblCols() As Double = { 50, 50, 50 }

	Dim dblRows() As Double = { 50, 30, 30, 30, 30 }

	'Add table shape to slide

	Dim tbl As ITable = sld.Shapes.AddTable(100, 50, dblCols, dblRows)

	'Set border format for each cell

	For Each row As IRow In tbl.Rows

		For Each cell As ICell In row

			cell.BorderTop.FillFormat.FillType = FillType.Solid

			cell.BorderTop.FillFormat.SolidFillColor.Color = Color.Red

			cell.BorderTop.Width = 5

			cell.BorderBottom.FillFormat.FillType = FillType.Solid

			cell.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red

			cell.BorderBottom.Width = 5

			cell.BorderLeft.FillFormat.FillType = FillType.Solid

			cell.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red

			cell.BorderLeft.Width = 5

			cell.BorderRight.FillFormat.FillType = FillType.Solid

			cell.BorderRight.FillFormat.SolidFillColor.Color = Color.Red

			cell.BorderRight.Width = 5

		Next cell

	Next row

	'Merge cells 1 & 2 of row 1

	tbl.MergeCells(tbl(0, 0), tbl(1, 0), False)

	'Add text to the merged cell

	tbl(0, 0).TextFrame.Text = "Merged Cells"

	'Write PPTX to Disk

	pres.Save(path & "table.pptx", SaveFormat.Pptx)

End Using



```

![todo:image_alt_text](creating-a-table-from-scratch-in-slide_1.png)

**Figure**: Table added to the slide
#### **Removing Table Cells Border**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. In order to remove the borders from table cells, please follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide by using its Index
- Define Array of Columns with Width
- Define Array of Rows with Height
- Add a Table to the slide using AddTable method exposed by IShapes object
- Iterate through each Cell to clear the Top, Bottom, Right, Left Borders
- Savethe modified presentation as a PPTX file
#### **Example**
[**C#**]()

``` cpp

 //Instantiate Presentation class that represents PPTX file

using (Presentation pres = new Presentation())

{

    //Access first slide

    Slide sld = (Slide)pres.Slides[0];

    //Define columns with widths and rows with heights

    double[] dblCols = { 50, 50, 50, 50 };

    double[] dblRows = { 50, 30, 30, 30, 30 };

    //Add table shape to slide

    //Add table shape to slide

    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    //Set border format for each cell

    foreach (IRow row in tbl.Rows)

        foreach (ICell cell in row)

        {

            cell.BorderTop.FillFormat.FillType = FillType.NoFill;

            cell.BorderBottom.FillFormat.FillType = FillType.NoFill;

            cell.BorderLeft.FillFormat.FillType = FillType.NoFill;

            cell.BorderRight.FillFormat.FillType = FillType.NoFill;

        }



    //Write PPTX to Disk

    pres.Save(path + "table.pptx", SaveFormat.Pptx);

}

//Instantiate Presentation class that represents PPTX file

```

[**Visual Basic**]()

``` cpp

 'Instantiate Presentation class that represents PPTX file

Using pres As New Presentation()

	'Access first slide

	Dim sld As ISlide = pres.Slides(0)

	'Define columns with widths and rows with heights

	Dim dblCols() As Double = { 50, 50, 50 }

	Dim dblRows() As Double = { 50, 30, 30, 30, 30 }

	'Add table shape to slide

	 Dim tbl As ITable = sld.Shapes.AddTable(100, 50, dblCols, dblRows)

	'Set border format for each cell

 	For Each row As IRow In tbl.Rows

		For Each cell As ICell In row

			cell.BorderTop.FillFormat.FillType = FillType.NoFill

			cell.BorderBottom.FillFormat.FillType = FillType.NoFill

			cell.BorderLeft.FillFormat.FillType = FillType.NoFill

			cell.BorderRight.FillFormat.FillType = FillType.NoFill

		Next cell

	Next row

	'Write PPTX to Disk

	pres.Save(path & "table.pptx", SaveFormat.Pptx)

End Using



```

![todo:image_alt_text](RemoveTableBorders-002.png)

**Figure**: Table added to the slide
