---
title: Manage Cells
type: docs
weight: 30
url: /java/manage-cells/
---


## **Cells Indexing**
{{% alert color="primary" %}} 

A table cells are indexed according to a placement within the table's columns and rows.

{{% /alert %}} 

In a standard table numeration of cells is straightforward and zero-based. The first cell in a table is indexed as 0,0 (column 0, row 0).

|**(0, 0)**|**(1, 0)**|**(2, 0)**|**(3, 0)**|
| :- | :- | :- | :- |
|(0, 1)|(1, 1)|(2, 1)|(3, 1)|
|(0, 2)|(1, 2)|(2, 2)|(3, 2)|
|(0, 3)|(1, 3)|(2, 3)|(3, 3)|
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-StandardTables-StandardTables.java" >}}


## **Merge Cells**
If we merge 2 pairs of cells (1, 1) x (2, 1) and (1, 2) x (2, 2) then the table will be numbered and look like this:

|![todo:image_alt_text](http://i.imgur.com/WyQ2rSt.png)|
| :- |
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-MergeCells-MergeCells.java" >}}

Let's continue merging cells. Now we merged (1, 1) and (1, 2). As a result, we have a table with large merged cell in the middle:

|![todo:image_alt_text](http://i.imgur.com/xOe90lq.png)|
| :- |
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-MergeCell-MergeCell.java" >}}

## **Split Cells**
We could see in the previous example when table cells are merged then the enumeration of other cells is not changed. Now let's return to our normal table (without merged cells) and try to split cells (1, 1). The result is strange enough but that is the way MS PowerPoint and Aspose.Slides for Java numerate table cells:

|![todo:image_alt_text](http://i.imgur.com/fKSeb0q.png)|
| :- |
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-CellSplit-CellSplit.java" >}}

## **Add Image to Table Cell**
{{% alert color="primary" %}} 

Aspose.Slides for Java facilitates developers to add images to table cells. In this topic, we will explain how developers can add an image to a cell.

{{% /alert %}} 

To create a new table and add an image in a table cell, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Create an array of columns's width.
- Create an array of rows' height.
- Add a table to the slide using **addTable** method exposed by [IShapeCollection](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IShapeCollection) object.
- Create a Buffered Image object to hold the image file.
- Add the image to [IPPImage](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IPPImage) object.
- Set Fill Format of the table cell as picture.
- Add the [IPPImage](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IPPImage) to the first cell of the table.
- Save the modified presentation as a PPTX file.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-AddAnImageInATableCell-AddAnImageInATableCell.java" >}}


## **Vertically Align Text in Table Cell**
{{% alert color="primary" %}} 

Aspose.Slides for Java facilitates developers to align text vertically in a table cell. In this topic, we will explain how developers can vertically align text present in a table cell using Aspose.Slides for Java.

{{% /alert %}} 

To vertically align the text in a table cell, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its index.
- Insert table in the slide.
- Access text frame.
- Access paragraph.
- Align text vertically.
- Save the presentation as a PPTX file.


{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-VerticallyAlignTheTextInTableCell-VerticallyAlignTheTextInTableCell.java" >}}

## **Remove Borders of Table Cell**
To remove borders of the table cells, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Create an Array of Columns' Width.
- Create an Array of Rows' Height.
- Add a Table to the slide using **addTable** method exposed by [ISlideCollection](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ISlideCollection) object.
- Iterate through each Cell to clear the Top, Bottom, Right and Left Borders.
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-RemoveBordersOfATableCells-RemoveBordersOfATableCells.java" >}}

|![todo:image_alt_text](http://i.imgur.com/clA2Skg.png)|
| :- |
|**Figure: Borders removed of the table cells**|

## **Identify Merge Table Cell**
Aspose.Slides for Java has provided the simplest API to identify merge table cells in an easiest way. To identify merge cells in table, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the the table from first slide.
- Iterate through row and columns of table to find out merge cells.
- Print Message if cells are merged.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-IdentifyingTheMergedCellsinTable-IdentifyingTheMergedCellsinTable.java" >}}