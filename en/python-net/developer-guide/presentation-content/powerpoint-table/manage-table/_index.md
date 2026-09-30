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

## **Introduction**

Tables in PowerPoint organize information into rows and columns, making it easier to read and compare values.

Aspose.Slides provides the [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) and [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) classes and other types to allow you to create, update, and manage tables in presentations.

## **Create a Table from Scratch**

Create a table by specifying its position, column widths, and row heights. After adding it to a slide, you can format cell borders, merge cells, and insert text.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a reference to the slide by its index.
3. Define a list of column widths in points.
4. Define a list of row heights in points.
5. Add a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) object to the slide through the [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) method.
6. Iterate through each [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) to apply formatting to the top, bottom, right, and left borders.
7. Merge the first two cells of the table's first row.
8. Access the merged cell through its [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) property.
9. Set the text in the merged cell.
10. Save the modified presentation.

The example below creates a table with three columns and five rows at (100, 50) points. It applies red borders with a width of 5 points, merges the first two cells in the first row, and saves the result as `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numbering in a Standard Table**

In a standard table, cell indices are zero-based and use the order (column, row). The first cell is indexed as (0, 0). In Python, access a cell with `table.rows[row_index][column_index]`; the row index comes first in this expression.

For example, the cells in a table with 4 columns and 4 rows are numbered this way:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

This example creates the 4 × 4 table illustrated above, with column widths and row heights of 70 points and red cell borders with a width of 5 points. The coordinates illustrate cell indices; the example leaves the cells empty and saves the table as `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Access an Existing Table**

Tables are stored in a slide's shape collection. Iterate through the shapes to locate a table, then use the [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) class to read or update its cells.

1. Load the presentation using the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a reference to the slide containing the table by its index.
3. Iterate through the [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) objects and stop when a table is found. If the slide contains several tables, use [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) to identify the one you need.
4. Update the text in the target cell.
5. Save the modified presentation.

The example below opens `UpdateExistingTable.pptx` and finds the first table on the first slide. It sets the cell at column 0, row 1 to `New` and saves the result as `table1_out.pptx`. The input must contain at least one slide, and the first table on that slide must have at least one column and two rows.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

To resize a row in an existing table and understand why its actual height can exceed the requested minimum, see [Control Row Height](/slides/python-net/manage-rows-and-columns/#control-row-height).

## **Find the Cell That Owns a Text Frame**

When generic text-processing code receives a [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) from a table, use the [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) property to retrieve the owning [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/). For a table-cell text frame, [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) is set and [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) is `None`, even though the table itself is a shape.

The cell coordinates are available through the read-only [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) and [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) properties. [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) is also read-only: it provides navigation to the owner but does not change ownership. Always check the returned cell for `None` before using it.

For a complete example that identifies table-cell and shape owners, including shapes associated with SmartArt nodes, see [Search and Replace Text](/slides/python-net/search-and-replace-text/).

## **Align Text in a Table**

You can control the vertical anchoring and text direction of individual table cells. The example in this section centers text within the first cell and rotates it by 270 degrees.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a reference to the slide by its index.
3. Add a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) object to the slide.
4. Access a [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) object from the table.
5. Access the first [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) and set its text and color.
6. Set the cell's [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) and [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/).
7. Save the modified presentation.

This example creates a 4 × 4 table with column widths of 120 points and row heights of 100 points. It formats the text in cell (0, 0), adds values to the remaining cells in the first row, and saves the result as `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Formatting on the Table Level**

Use [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) to apply text formatting to all cells in a table. Its overloads accept portion, paragraph, and text frame formatting, so you can set these properties without iterating through individual cells.

1. Load the presentation using the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a reference to the slide by its index.
3. Access a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) object from the slide.
4. Set the [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) for the text.
5. Set the [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) and [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/).
6. Set the [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/).
7. Save the modified presentation.

The example below opens `table.pptx`, which must contain at least one slide with a table as its first shape. It sets the font size to 25 points, right-aligns paragraphs with a right margin of 20 points, and makes the text vertical. The formatted presentation is saved as `result.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Get Table Style Properties**

Use [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) to read or assign a table's preset style. This example applies [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) to one table, prints the preset name, and assigns the same preset to a second table. Both tables are saved in `table-style.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Lock Aspect Ratio of a Table**

A table's aspect ratio is the ratio of its width to its height. Use [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) to lock this ratio for a table.

The example below opens `pres.pptx`, which must contain at least one slide with a table as its first shape. It prints the current lock state, enables the aspect ratio lock, prints the updated state (`True`), and saves the result as `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**

Yes. The table exposes a [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) property, and paragraphs have [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Using both ensures the correct RTL order and rendering inside cells.

**How can I prevent users from moving or resizing a table in the final file?**

Use [shape locks](/slides/python-net/applying-protection-to-presentation/) to disable moving, resizing, selection, etc. These locks apply to tables as well.

**Is inserting an image inside a cell as a background supported?**

Yes. You can set a [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) for a cell; the image will cover the cell area according to the chosen mode (stretch or tile).
