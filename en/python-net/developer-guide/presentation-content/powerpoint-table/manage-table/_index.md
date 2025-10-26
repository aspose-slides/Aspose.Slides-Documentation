---
title: Manage Presentation Tables with Python
linktitle: Manage Table
type: docs
weight: 10
url: /python-net/manage-table/
keywords:
- add table
- create table
- access table
- aspect ratio
- align text
- text formatting
- table style
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Create & edit tables in PowerPoint and OpenDocument slides with Aspose.Slides for Python via .NET. Discover simple code examples to streamline your table workflows."
---

## **Overview**

A table in PowerPoint is an efficient way to present information. Information arranged in a grid of cells (rows and columns) is straightforward and easy to understand.

Aspose.Slides provides the [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) class, the [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) class, and other related types to help you create, update, and manage tables in any presentation.

## **Create Tables from Scratch**

This section shows how to create a table from scratch in Aspose.Slides by adding a table shape to a slide, defining its rows and columns, and setting precise sizes. You’ll also see how to populate cells with text, adjust alignment and borders, and customize the table’s appearance.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a reference to a slide by its index.
3. Define an array of column widths.
4. Define an array of row heights.
5. Add a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) to the slide.
6. Iterate over each [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) and format its top, bottom, right, and left borders.
7. Merge the first two cells in the table’s first row.
8. Access the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) of a [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/).
9. Add text to the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
10. Save the modified presentation.

The following Python example shows how to create a table in a presentation:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Set the border format for each cell.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Merge cells from (row 0, col 0) to (row 1, col 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Add text to the merged cell.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Save the presentation to disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numbering in Standard Tables**

In a standard table, cell numbering is straightforward and zero-based. The first cell in a table is indexed as (0, 0) (column 0, row 0).

For example, in a table with 4 columns and 4 rows, the cells are numbered as follows:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

The following Python example shows how to reference cells using this zero-based numbering:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Access an Existing Table**

This section explains how to locate and work with an existing table in a presentation using Aspose.Slides. You’ll learn how to find the table on a slide, access its rows, columns, and cells, and update content or formatting.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a reference to the slide that contains the table by its index.
3. Iterate through all [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) objects until you find the table.
4. Use the [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) object to work with the table.
5. Save the modified presentation.

{{% alert color="info" %}}

If the slide contains several tables, it’s better to search for the table you need by its `alternative_text` property.

{{% /alert %}}

The following Python example shows how to access and work with an existing table:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class to load a PPTX file.
with slides.Presentation("sample.pptx") as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    table = None

    # Iterate through shapes and reference the first table found.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Set the text of the first cell in the first row.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Save the modified presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Align Text in Tables**

This section shows how to control text alignment inside table cells using Aspose.Slides. You’ll learn to set horizontal and vertical alignment for cells to keep your content clear and consistent.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a reference to the slide by its index.
3. Add a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) object to the slide.
4. Access a [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) object from the table.
5. Align the text vertically.
6. Save the modified presentation.

The following Python example shows how to align the text in a table:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Center the text and set vertical orientation.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Save the presentation to disk.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Formatting at the Table Level**

This section shows how to apply text formatting at the table level in Aspose.Slides so every cell inherits a consistent, unified style. You’ll learn to set font sizes, alignments, and margins globally.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a reference to the slide by its index.
3. Add a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) to the slide.
4. Set the font size (font height) for the text.
5. Set paragraph alignment and margins.
6. Set the vertical text orientation.
7. Save the modified presentation.

The following Python example shows how to apply your preferred formatting options to text in a table:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Set the font size for all table cells.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Set right-aligned text and a right margin for all table cells.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Set the vertical text orientation for all table cells.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Apply Built-In Table Styles**

Aspose.Slides lets you format tables using predefined styles directly in code. The example demonstrates creating a table, applying a built-in style, and saving the result—an efficient way to ensure consistent, professional formatting.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Lock Aspect Ratio of Tables**

The aspect ratio of a shape is the ratio of its dimensions. Aspose.Slides provides the `aspect_ratio_locked` property, which allows you to lock the aspect ratio for tables and other shapes.

The following Python example shows how to lock the aspect ratio for a table:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**

Yes. The table exposes a [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) property, and paragraphs have [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Using both ensures the correct RTL order and rendering inside cells.

**How can I prevent users from moving or resizing a table in the final file?**

Use [shape locks](/slides/python-net/applying-protection-to-presentation/) to disable moving, resizing, selection, etc. These locks apply to tables as well.

**Is inserting an image inside a cell as a background supported?**

Yes. You can set a [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) for a cell; the image will cover the cell area according to the chosen mode (stretch or tile).
