---
title: Manage Rows and Columns in PowerPoint Tables Using Python
linktitle: Rows and Columns
type: docs
weight: 20
url: /python-net/manage-rows-and-columns/
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
description: "Manage table rows and columns in PowerPoint and OpenDocument with Aspose.Slides for Python via .NET and speed up presentation editing and data updates."
---

To allow you to manage a table's rows and columns in a PowerPoint presentation, Aspose.Slides provides the [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) class, [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) interface, and many other types. 

## **Set First Row as Header**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation. 
2. Get a slide's reference through its index. 
3. Create an [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) object and set it to null.
4. Iterate through all [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) objects to find the relevant table. 
5. Set the table's first row as its header. 

This Python code shows you how to set a table's first row as its header:

```python
import aspose.slides as slides

# Instantiates the Presentation class
with slides.Presentation("table.pptx") as pres:
    # Accesses the first slide
    sld = pres.slides[0]

    # Initializes the null TableEx
    tbl = None

    # Iterates through the shapes and sets a reference to the table
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # Sets the first row of a table as its header 
    tbl.first_row = True
    
    # Saves the presentation to disk
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Clone Table's Row or Column**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation, 
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) object to the slide through the `add_table(x, y, column_widths, row_heights)` method.
6. Clone the table row.
7. Clone the table column.
8. Save the modified presentation.

This Python code shows you how to clone a PowerPoint table's row or column:

```python
 import aspose.slides as slides

# Instantiates the Presentation class
with slides.Presentation() as presentation:

    # Accesses the first slide
    sld = presentation.slides[0]

    # Defines columns with widths and rows with heights
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # Adds a table shape to the slide
    table = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Adds some text to the row 1 cell 1
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Adds some text to the row 1 cell 2
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Clones Row 1 at the end of table
    table.rows.add_clone(table.rows[0], False)

    # Adds some text to the row 2 cell 1
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Adds some text to the row 2 cell 2
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Clones Row 2 as 4th row of table
    table.rows.insert_clone(3,table.rows[1], False)

    # Clones first column at the end
    table.columns.add_clone(table.columns[0], False)

    # Clones 2nd column at 4th column index
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Saves the presentation to disk
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove Row or Column from Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation, 
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) object to the slide through the `add_table(x, y, column_widths, row_heights)` method.
6. Remove the table row.
7. Remove the table column.
8. Save the modified presentation. 

This Python code shows you how to remove a row or column from a table:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    colWidth =  [100, 50, 30] 
    rowHeight =  [30, 50, 30] 

    table = slide.shapes.add_table(100, 100, colWidth, rowHeight)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)
    pres.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Formatting on Table Row Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation, 
2. Get a slide's reference through its index. 
3. Access the relevant [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) object from the slide. 
4. Set the first-row cells' `font_height`.
5. Set the first-row cells' `alignment` and `margin_right`. 
6. Set the second-row cells' `text_vertical_type`.
7. Save the modified presentation.

This Python code demonstrates the operation.

```python
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    
    slide = presentation.slides[0]

    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Sets first row cells' font height
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.rows[0].set_text_format(portionFormat)

    # Sets first row cells' text alignment and right margin
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.rows[0].set_text_format(paragraphFormat)

    # Sets the second row cells' text vertical type
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.rows[1].set_text_format(textFrameFormat)
	
  # Saves the presentation to Disk
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Formatting on Table Column Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation, 
2. Get a slide's reference through its index. 
3. Access the relevant [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) object from the slide. 
4. Set the first-column cells' `font_height`.
5. Set the first-column cells' `alignment` and `margin_right`. 
6. Set the second-column cells' `text_vertical_type`.
7. Save the modified presentation. 

This Python code demonstrates the operation: 

```python
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as pres:
    slide = pres.slides[0]
    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Sets first column cells' font height
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.columns[0].set_text_format(portionFormat)

    # Sets first column cells' text alignment and right margin 
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.columns[0].set_text_format(paragraphFormat)

    # Sets second column cells' text vertical type
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.columns[1].set_text_format(textFrameFormat)

    # Saves the presentation to Disk
    pres.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Get Table Style Properties**

Aspose.Slides allows you to retrieve the style properties for a table so that you can use those details for another table or somewhere else. This Python code shows you how to get the style properties from a table preset style:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

