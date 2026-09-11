---
title: Manage Presentation Tables in Python
linktitle: Manage Table
type: docs
weight: 10
url: /python-java/manage-table/
keywords:
- add table
- create table
- access table
- aspect ratio
- align text
- text formatting
- table style
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Create & edit tables in PowerPoint slides with Aspose.Slides for Python via Java. Discover simple code examples to streamline your table workflows."
---

## **Introduction**

A table in PowerPoint is an efficient way of displaying information. The information in a grid of cells (arranged in rows and columns) is straightforward and easy to understand.

Aspose.Slides provides the [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) class, [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) class, and other types to allow you to create, update, and manage tables in all kinds of presentations.

## **Create a Table from Scratch**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Define a list of column widths.
4. Define a list of row heights.
5. Add a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object to the slide through the [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) method.
6. Iterate through each [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) to apply formatting to the top, bottom, right, and left borders.
7. Merge the first two cells of the table's first row.
8. Access a [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).
9. Add some text to the [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).
10. Save the modified presentation.

This Python code shows you how to create a table in a presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Instantiates a Presentation class that represents a PPTX file
presentation = Presentation()
try:

    # Accesses the first slide
    slide = presentation.getSlides().get_Item(0)

    # Defines columns with widths and rows with heights
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Adds a table shape to slide
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Sets the border format for each cell
    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    # Merges cells 1 & 2 of row 1
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Adds some text to the merged cell
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Saves the presentation to Disk
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numbering in a Standard Table**

In a standard table, the numbering of cells is straightforward and zero-based. The first cell in a table is indexed as 0,0 (column 0, row 0).

For example, the cells in a table with 4 columns and 4 rows are numbered this way:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This Python code shows you how to create a table with standard cell numbering:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Instantiates a Presentation class that represents a PPTX file
presentation = Presentation()
try:

    # Accesses first slide
    slide = presentation.getSlides().get_Item(0)

    # Defines columns with widths and rows with heights
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Adds a table shape to slide
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Sets the border format for each cell
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

    # Saves presentation to disk
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Access an Existing Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.

2. Get a reference to the slide containing the table through its index.

3. Initialize a variable for a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object and set it to `None`.

4. Iterate through all [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) objects until the table is found.

   If you suspect the slide you are dealing with contains a single table, you can simply check all the shapes it contains. When a shape is identified as a table, you can use it as a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object. But if the slide you are dealing with contains several tables, then you are better off searching for the table you need through its [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText).

5. Use the [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object to work with the table. In the example below, we update the text in the first column of the second row.

6. Save the modified presentation.

This Python code shows you how to access and work with an existing table:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Instantiates the Presentation class that represents a PPTX file
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Accesses the first slide
    slide = presentation.getSlides().get_Item(0)

    # Initialize the table reference.
    table = None

    # Iterates through the shapes and sets a reference to the table found
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Sets the text for the first column of the second row
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Saves the modified presentation to disk
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Find the Cell That Owns a Text Frame**

When generic text-processing code receives a [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) from a table, use the [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) method to retrieve the owning [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/). For a table-cell text frame, [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) returns the owner and [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) returns `None`, even though the table itself is a shape.

The cell coordinates are available through the read-only [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) and [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) methods. [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) also provides read-only navigation: it returns the owner but does not change ownership. Always check the returned cell for `None` before using it.

For a complete example that identifies table-cell and shape owners, including shapes associated with SmartArt nodes, see [Search and Replace Text](/slides/python-java/search-and-replace-text/).

## **Align Text in a Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Add a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object to the slide.
4. Access a [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) object from the table.
5. Access the [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) object's [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/).
6. Align the text vertically.
7. Save the modified presentation.

This Python code shows you how to align the text in a table:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Creates an instance of the Presentation class
presentation = Presentation()
try:

    # Gets the first slide
    slide = presentation.getSlides().get_Item(0)

    # Defines columns with widths and rows with heights
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Adds the table shape to the slide
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # Accesses the text frame
    text_frame = table.get_Item(0, 0).getTextFrame()

    # Access the first paragraph in the text frame.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # Access the first portion in the paragraph.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Aligns the text vertically
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # Saves the presentation to disk
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set Text Formatting on the Table Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Access a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object from the slide.
4. Set the text's font height with [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Set the alignment and right margin with [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) and [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Set the vertical text type with [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Save the modified presentation.

This Python code shows you how to apply your preferred formatting options to the text in a table:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Creates an instance of the Presentation class
presentation = Presentation("simpletable.pptx")
try:

    # Let's assume that the first shape on the first slide is a table
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Sets the table cells' font height
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Sets the table cells' text alignment and right margin in one call
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Sets the table cells' text vertical type
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Get Table Style Properties**

Aspose.Slides allows you to retrieve the style properties for a table so that you can use those details for another table or somewhere else. This Python code shows you how to get the style properties from a table preset style:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # change the default style preset theme

    # Gets the style preset of the table
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Applies the retrieved style preset to another table
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lock Aspect Ratio of a Table**

The aspect ratio of a geometric shape is the ratio of its sizes in different dimensions. Aspose.Slides provides the [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) method to allow you to lock the aspect ratio setting for tables and other shapes.

This Python code shows you how to lock the aspect ratio for a table:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # invert
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**

Yes. The table exposes a [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft) method, and paragraphs have [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). Using both ensures the correct RTL order and rendering inside cells.

**How can I prevent users from moving or resizing a table in the final file?**

Use [shape locks](/slides/python-java/applying-protection-to-presentation/) to disable moving, resizing, selection, etc. These locks apply to tables as well.

**Is inserting an image inside a cell as a background supported?**

Yes. You can set a [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) for a cell; the image will cover the cell area according to the chosen mode (stretch or tile).
