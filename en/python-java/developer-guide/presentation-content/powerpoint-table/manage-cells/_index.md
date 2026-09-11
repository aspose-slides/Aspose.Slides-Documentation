---
title: Manage Table Cells in Presentations Using Python
linktitle: Manage Cells
type: docs
weight: 30
url: /python-java/manage-cells/
keywords:
- table cell
- merge cells
- remove border
- split cell
- image in cell
- background color
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Effortlessly manage table cells in PowerPoint with Aspose.Slides for Python via Java. Master accessing, modifying, and styling cells quickly for seamless slide automation."
---

## **Overview**

Aspose.Slides allows you to access and modify table cells in PowerPoint presentations. This article explains how to identify merged table cells, remove cell borders, work with cell numbering after merging or splitting cells, change a cell’s background color, and add an image inside a table cell. The examples show how to create or open a presentation, get a table from a slide, update cell formatting through cell properties, and save the modified presentation as a PPTX file.

## **Identify a Merged Table Cell**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
2. Get the table from the first slide.
3. Iterate through the table's rows and columns to find merged cells.
4. Print a message when merged cells are found.

This Python code shows you how to identify merged table cells in a presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Assume that the first shape on the first slide is a table.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Remove Table Cell Borders**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Define a list of column widths.
4. Define a list of row heights.
5. Add a table to the slide through the [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) method.
6. Iterate through every cell to clear the top, bottom, right, and left borders.
7. Save the modified presentation as a PPTX file.

This Python code shows you how to remove the borders from table cells:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Access the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Define column widths and row heights.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table to the slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Set the border format for each cell.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Save the presentation as a PPTX file.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numbering in Merged Cells**

If we merge two pairs of cells, (1, 1) and (2, 1), and (1, 2) and (2, 2), the resulting table retains its cell numbering. This Python code demonstrates the process:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Access the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Define column widths and row heights.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Add a table to the slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Set the border format for each cell.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Merge cells (1, 1) and (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Merge cells (1, 2) and (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Save the presentation as a PPTX file.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

We then merge the cells further by merging (1, 1) and (1, 2). The result is a table containing a large merged cell in its center:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Access the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Define column widths and row heights.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Add a table to the slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Set the border format for each cell.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Merge cells (1, 1) and (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Merge cells (1, 2) and (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Merge cells (1, 1) and (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Save the presentation as a PPTX file.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numbering in a Split Cell**

In the previous examples, merging table cells did not change the numbering of the other cells.

This time, we take a regular table (a table without merged cells) and then try to split cell (1, 1) to get a special table. You may want to pay attention to this table's numbering, which may be considered strange. However, that is the way Microsoft PowerPoint numbers table cells and Aspose.Slides does the same thing.

This Python code demonstrates the process we described:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Access the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Define column widths and row heights.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Add a table to the slide.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Set the border format for each cell.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Split cell (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Save the presentation as a PPTX file.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Change the Table Cell Background Color**

This Python code shows you how to change a table cell's background color:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Access the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Define column widths and row heights.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Add a table to the slide.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Set the background color for a cell.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Save the presentation as a PPTX file.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Add an Image Inside a Table Cell**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Define a list of column widths.
4. Define a list of row heights.
5. Add a table to the slide through the [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) method.
6. Load the image file using [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile).
7. Add the image to the presentation to create a [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) object.
8. Set the table cell’s [FillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/) fill type to [FillType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/#Picture).
9. Add the image to the table's first cell.
10. Save the modified presentation as a PPTX file.

This Python code shows you how to place an image inside a table cell when creating a table:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Access the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Define column widths and row heights.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Add a table to the slide.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Create a presentation image from the image file.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Add the image to the first table cell.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Save the presentation as a PPTX file.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I set different line thicknesses and styles for different sides of a single cell?**

Yes. The [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) borders have separate properties, so the thickness and style of each side can differ. This logically follows from the per-side border control for a cell demonstrated in the article.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

The behavior depends on the [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). With stretching, the image adjusts to the new cell; with tiling, the tiles are recalculated. The article mentions the image display modes in a cell.

**Can I assign a hyperlink to all the content of a cell?**

[Hyperlinks](/slides/python-java/manage-hyperlinks/) are set at the text (portion) level inside the cell’s text frame or at the level of the entire table/shape. In practice, you assign the link to a portion or to all the text in the cell.

**Can I set different fonts within a single cell?**

Yes. A cell’s text frame supports [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (runs) with independent formatting—font family, style, size, and color.
