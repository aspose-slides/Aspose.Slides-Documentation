---
title: Manage Rows and Columns in PowerPoint Tables Using Python
linktitle: Rows and Columns
type: docs
weight: 20
url: /python-java/manage-rows-and-columns/
keywords:
- table row
- table column
- first row
- table header
- clone row
- clone column
- copy row
- copy column
- remove row
- remove column
- row text formatting
- column text formatting
- table style
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Manage table rows and columns in PowerPoint with Aspose.Slides for Python via Java and speed up presentation editing and data updates."
---

## **Introduction**

To allow you to manage a table's rows and columns in a PowerPoint presentation, Aspose.Slides provides the [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) class and many other types.

## **Set the First Row as a Header**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation.
2. Get a reference to a slide by its index.
3. Create a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) reference and set it to `None`.
4. Iterate through all [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) objects to find the relevant table.
5. Set the table's first row as its header.

This Python code shows you how to set a table's first row as its header:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **Clone a Table Row or Column**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation.
2. Get a reference to a slide by its index.
3. Define a list of column widths.
4. Define a list of row heights.
5. Add a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object to the slide through the [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) method.
6. Clone the table row.
7. Clone the table column.
8. Save the modified presentation.

This Python code shows you how to clone a PowerPoint table's row or column:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Remove a Row or Column from a Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Define a list of column widths.
4. Define a list of row heights.
5. Add a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object to the slide through the [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) method.
6. Remove the table row.
7. Remove the table column.
8. Save the modified presentation.

This Python code shows you how to remove a row or column from a table:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set Text Formatting on the Table Row Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation.
2. Get a reference to a slide by its index.
3. Access the relevant [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object from the slide.
4. Set the font height of the first-row cells using [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Set the text alignment and right margin of the first-row cells using [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) and [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Set the vertical text type of the second-row cells using [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Save the modified presentation.

This Python code demonstrates the operation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Set Text Formatting on the Table Column Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and load the presentation.
2. Get a reference to a slide by its index.
3. Access the relevant [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) object from the slide.
4. Set the font height of the first-column cells using [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Set the text alignment and right margin of the first-column cells using [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) and [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Set the vertical text type of the second-column cells using [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Save the modified presentation.

This Python code demonstrates the operation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
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
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I apply PowerPoint themes/styles to a table that’s already created?**

Yes. The table inherits the slide/layout/master theme, and you can still override fills, borders, and text colors on top of that theme.

**Can I sort table rows like in Excel?**

No, Aspose.Slides tables don’t have built-in sorting or filters. Sort your data in memory first, then repopulate the table rows in that order.

**Can I have banded (striped) columns while keeping custom colors on specific cells?**

Yes. Turn on banded columns, then override specific cells with local formatting; cell-level formatting takes precedence over the table style.
