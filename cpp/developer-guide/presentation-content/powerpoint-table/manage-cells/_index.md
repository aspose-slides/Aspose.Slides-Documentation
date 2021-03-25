---
title: Manage Cells
type: docs
weight: 30
url: /cpp/manage-cells/
---

## **Identify Merged Cell**
Aspose.Slides for C++ has provided the simplest API to identify merge table cells in an easiest way. To identify merge cells in table, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the the table from first slide.
- Iterate through row and columns of table to find out merge cells.
- Print Message if cells are merged.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Tables-IdentifyingTheMergedCellsinTable-IdentifyingTheMergedCellsinTable.cs" >}}

## **Remove Table Cells Border**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. In order to remove the borders from table cells, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Iterate through each Cell to clear the Top, Bottom, Right, Left Borders.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Tables-TableWithCellBorders-TableWithCellBorders.cs" >}}

## **Numbering in Merged Cells**
If we merge 2 pairs of cells (1, 1) x (2, 1) and (1, 2) x (2, 2) then table will be numbered and look like this:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-MergeCells-MergeCells.cpp" >}}

Let's continue merging cells. Now we merge (1, 1) and (1, 2). As a result we have table with large merged cell in the middle:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-MergeCells-MergeCells.cpp" >}}

## **Numbering in Splitted Cell**
We could see in previous example when table cells are merged then numeration of other cells is not changed.Now let's return to our normal table (without merged cells) and try to split cell (1, 1). The result is strange enough but that is the way MS PowerPoint and Aspose.Slides for C++ numerate table cells.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CellSplit-CellSplit.cpp" >}}

## **Add Image to Cell**
Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. To add image in a table cell while creating a new table, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Define Array of Columns with Width.
- Define Array of Rows with Height.
- Add a Table to the slide using AddTable method exposed by IShapes object.
- Create a Bitmap object to hold the image file.
- Add the Bitmap image to IPPImage Object.
- Set Fill Format of the Table Cell as Picture.
- Add the image to the first cell of the table.
- Save the modified presentation as a PPTX file

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddImageinsideTableCell-AddImageinsideTableCell.cpp" >}}

## **Add Image inside Table Cell**
{{% alert color="primary" %}} 

Aspose.Slides for C++ also facilitates developers to add images to table cells. In this topic, we will explain that how developers can add an image to a cell of a table using Aspose.Slides for C++.

{{% /alert %}} 

Aspose.Slides for C++ has provided the simplest API to create tables in an easiest way. To add image in a table cell while creating a new table, please follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide by using its Index
- Define Array of Columns with Width
- Define Array of Rows with Height
- Add a Table to the slide using AddTable method exposed by IShapes object
- Create a Bitmap object to hold the image file
- Add the Bitmap image to IPPImage Object
- Set Fill Format of the Table Cell as Picture
- Add the image to the first cell of the table
- Save the modified presentation as a PPTX file

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddImageinsideTableCell-AddImageinsideTableCell.cpp" >}}
