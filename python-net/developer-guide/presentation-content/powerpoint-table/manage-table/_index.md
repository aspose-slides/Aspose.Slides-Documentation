---
title: Manage Table
type: docs
weight: 10
url: /python-net/manage-table/
keywords: "Table, create table, access table, table aspect ratio, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Create and manage table in PowerPoint presentations in Python"

---

A table in PowerPoint is an efficient way of displaying and portraying information. The information in a grid of cells (arranged in rows and columns) is straightforward and easy to understand.

Aspose.Slides provides the [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) class, [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) interface, [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) class, [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/) interface, and other types to allow you to create, update, and manage tables in all kinds of presentations. 

## **Create Table from Scratch**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Define an array of `columnWidth`.
4. Define an array of `rowHeight`.
5. Add an [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) object to the slide through the `add_table(x, y, column_widths, row_heights)` method.
6. Iterate through each [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/) to apply formatting to the top, bottom, right, and left borders.
7. Merge the first two cells of the table's first row. 
8. Access an [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). 
9. Add some text to the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
10. Save the modified presentation.

This Python code shows you how to create a table in a presentation:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiates a Presentation class that represents a PPTX file
with slides.Presentation() as pres:
    # Accesses the first slide
    sld = pres.slides[0]

    # Defines columns with widths and rows with heights
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # Adds a table shape to the slide
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Sets the border format for each cell
    for row in range(len(tbl.rows)):
        for cell in range(len(tbl.rows[row])):
            tbl.rows[row][cell].cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_top.width = 5

            tbl.rows[row][cell].cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            tbl.rows[row][cell].cell_format.border_bottom.width =5

            tbl.rows[row][cell].cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            tbl.rows[row][cell].cell_format.border_left.width = 5

            tbl.rows[row][cell].cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_right.width = 5
        

    # Merges cells 1 & 2 of row 1
    tbl.merge_cells(tbl.rows[0][0], tbl.rows[1][1], False)

    # Adds some text to the merged cell
    tbl.rows[0][0].text_frame.text = "Merged Cells"

    # Saves the presentation to Disk
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numbering in Standard Table**

In a standard table, the numeration of cells is straightforward and zero-based. The first cell in a table is indexed as 0,0 (column 0, row 0). 

For example, the cells in a table with 4 columns and 4 rows are numbered this way:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This Python code shows you how to specify the numbering for cells in a table:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiates a Presentation class that represents a PPTX file
with slides.Presentation() as pres:
    # Accesses the first slide
    sld = pres.slides[0]

    # Defines columns with widths and rows with heights
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Adds a table shape to slide
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Sets the border format for each cell
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # Saves presentation to disk
    pres.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Access Existing Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.

2. Get a reference to the slide containing the table through its index. 

3. Create an [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) object and set it to null.

4. Iterate through all [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) objects till the table is found.

   If you suspect the slide you are dealing with contains a single table, you can simply check all the shapes it contains. When a shape is identified as a table, you can typecast it as a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) object. But if the slide you are dealing with contains several tables, then you are better off searching for the table you need through its `alternative_text` . 

5. Use the [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) object to work with the table. In the example below, we added a new row to the table.

6. Save the modified presentation.

This Python code shows you how to access and work with an existing table:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiates a Presentation class that represents a PPTX file
with slides.Presentation(path + "UpdateExistingTable.pptx") as pres:
    # Accesses the first slide
    sld = pres.slides[0]

    # Initializes null TableEx
    tbl = None

    # Iterates through the shapes and sets a reference to the table found
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # Sets the text for the first column of the second row
    tbl.rows[0][1].text_frame.text = "New"

    # Saves the modified presentation to disk
    pres.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Align Text in Table**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Add an [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) object to the slide. 
4. Access an [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) object from the table. 
5. Access the [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).
6. Align the text vertically.
7. Save the modified presentation.

This Python code shows you how to align the text in a table:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    # Gets the first slide 
    slide = presentation.slides[0]

    # Defines columns with widths and rows with heights
    dblCols =  [120, 120, 120, 120] 
    dblRows =  [100, 100, 100, 100] 

    # Adds the table shape to the slide
    tbl = slide.shapes.add_table(100, 50, dblCols, dblRows)
    tbl.rows[1][0].text_frame.text = "10"
    tbl.rows[2][0].text_frame.text = "20"
    tbl.rows[3][0].text_frame.text = "30"

    # Accesses the text frame
    txtFrame = tbl.rows[0][0].text_frame

    # Creates the Paragraph object for the text frame
    paragraph = txtFrame.paragraphs[0]

    # Creates the Portion object for paragraph
    portion = paragraph.portions[0]
    portion.text = "text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Aligns the text vertically
    cell = tbl.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Saves the presentation to disk
    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Formatting on Table Level**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a slide's reference through its index. 
3. Access an [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) object from the Slide.
4. Set the `font_height` for the text. 
5. Set the `alignment` and `margin_right`. 
6. Set the `text_vertical_type`.
7. Save the modified presentation. 

This Python code shows you how to apply your preferred formatting options to the text in a table:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    someTable = presentation.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Sets the table cells' font height
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.set_text_format(portionFormat)

    # Sets the table cells' text alignment and right margin in one call
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.set_text_format(paragraphFormat)

    # Sets the table cells' text vertical type
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.set_text_format(textFrameFormat)


    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
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

## **Lock Aspect Ratio of Table**

The aspect ratio of a geometric shape is the ratio of its sizes in different dimensions. Aspose.Slides provided the `aspect_ratio_locked` property to allow you to lock the aspect ratio setting for tables and other shapes. 

This Python code shows you how to lock the aspect ratio for a table:

```c#
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])
    print("Lock aspect ratio set: {0}".format(table.shape_lock.aspect_ratio_locked))

    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked

    print("Lock aspect ratio set: {0}".format(table.shape_lock.aspect_ratio_locked))

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

