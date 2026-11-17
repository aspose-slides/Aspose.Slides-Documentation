---
title: Manage Table Cells in Presentations with Python
linktitle: Manage Cells
type: docs
weight: 30
url: /python-net/manage-cells/
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
description: "Manage PowerPoint table cells in Python: identify merged cells, remove borders, split cells, and set background colors and images with Aspose.Slides for Python via .NET."
---

## **Overview**

Aspose.Slides allows you to access and modify table cells in PowerPoint presentations. This article explains how to identify merged table cells, remove cell borders, work with cell numbering after merging or splitting cells, change a cell’s background color, and add an image inside a table cell. The examples show how to create or open a presentation, get a table from a slide, update cell formatting through cell properties, and save the modified presentation as a PPTX file.

Aspose.Slides uses zero-based indices. Coordinates in this article are written as `(column, row)`.

## **Identify a Merged Table Cell**

The example opens an existing presentation and accesses the first shape on the first slide as a table. It assumes that the slide and shape exist and that the shape is a table. It then iterates through all rows and columns and uses [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) to identify cells in merged regions. For each match, it prints the cell coordinates in `row;column` order, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), and the region's starting coordinates, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) and [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Remove Table Cell Borders**

Create a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) and add a table to its first slide with [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Column widths, row heights, and the table position are specified in points. The example sets all four cell borders to [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), making them invisible.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Add Diagonal Cell Borders**

Use [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) to draw a line from the top-left corner to the bottom-right, and [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) to draw a line from the bottom-left corner to the top-right. A diagonal can mark a corner header; both diagonals can form an X to mark a cell as not applicable.

Each diagonal is a [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). In its [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/), set [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) to [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) and choose a [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). Set the line's [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) in points.

The example creates three cells in one row: a red downward diagonal, a blue upward diagonal, and both diagonals. It leaves the top, bottom, left, and right cell borders unchanged.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

A diagonal is a formatting property, not a cell split. Each cell retains a single [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/); the regions on either side of a diagonal cannot be edited independently.

The saved table, rendered in Microsoft PowerPoint:

![Three table cells showing a red diagonal from top-left to bottom-right, a blue diagonal from bottom-left to top-right, and both diagonals forming an X.](diagonal-cell-borders.png)

*Left to right: downward diagonal (red, 3 pt), upward diagonal (blue, 5 pt), and both diagonals.*

## **Merge Table Cells**

Use [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) to combine a rectangular range of table cells into one cell. Specify the cells at the top-left and bottom-right corners of the range. The final argument controls whether the merge may include cells outside the specified range; `False` keeps the merge within that range.

The example creates a 4-by-4 table with 70-point columns and rows, then merges the four central cells from `(1, 1)` through `(2, 2)`. The resulting cell spans two columns and two rows, while the table's underlying grid retains four columns and four rows. To access the merged cell's content or formatting, use its top-left position: `table.rows[1][1]` in this example. The other positions in the merged range remain part of the table grid, so the indices of cells outside the range do not change.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Split Table Cells**

Merging cells in the previous example preserves the table's grid. Splitting a cell can introduce a new grid column and change the column indices of cells to its right. Aspose.Slides follows PowerPoint's table grid model.

This example creates a 4-by-4 table with 70-point columns and rows and calls [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) on cell `(1, 1)`. Half of the cell's 70-point width is passed to create two equal-width cells.

After this split, the two halves are accessed as `table.rows[1][1]` and `table.rows[1][2]`. The table grid now has five columns: cells originally in columns 2 and 3 move to columns 3 and 4, respectively. Row indices remain unchanged. Use these updated column indices when accessing cells after the split.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```


<!-- visual-explanation:manage-cells:start -->
[![An unmerged 70-point cell splits into two 35-point cells, adding a fifth grid column and shifting the indices to its right.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*The width split affects cell (1, 1), using zero-based (column, row) indices. Other rows keep a cell spanning both new column positions.*
<!-- visual-explanation:manage-cells:end -->

### **Split Merged Cells by Row or Column Span**

To prepare merged template cells for data population, use [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) to split along an existing row boundary, or [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) to split along a column boundary.

The `index` argument counts rows in the upper part or columns in the left part of the split; it is relative to the merged region:

- Row split: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Column split: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

The example expects a presentation to have a table as the first shape on the first slide, with `(1, 2)` and `(1, 3)` merged vertically. Starting from the lower position, it uses [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) and [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) to locate the origin and checks both spans. `split_by_row_span` with an index of 1 then separates rows 2 and 3 for product names. For a horizontal two-column merge, use `split_by_col_span` with an index of 1 instead.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Retrieve the resulting cells from the table after splitting.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

The table grid and surrounding cell indices stay unchanged. Retrieve the resulting cells by their coordinates; here, both have spans of 1 and [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) prints `False`. Larger regions can remain partly merged after one split.

The original text and its formatting remain in the upper (or left) cell; the new cell is empty but inherits cell formatting such as fill, borders, and margins. Populate the cells after splitting and set any required text formatting explicitly.

The saved presentation contains separate "Product A" and "Product B" cells with the template's cell formatting retained. See the [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) for details.

### **Split a Cell at a Specific Height**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) takes the height of the upper part in points. [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) takes the number of existing grid rows in the upper part. To center a 40-point cell vertically in the right column, subtract 40 from the cell’s actual height and divide the remaining space equally above and below it.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

The first split adds a grid row, leaving the lower 90 points in `table.rows[1][1]`. The second split divides that cell into a 40-point middle cell and a 50-point bottom cell. The three cells in the right column are now 50, 40, and 50 points high from top to bottom. The left cell spans all three rows at its original height of 140 points.

![The left cell spans the full table height beside three cells with Middle in the center.](split-by-height.png)

## **Change the Table Cell Background Color**

This example creates a table with 150-point columns and 50-point rows. It sets [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) to solid and [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) to red for cell `(2, 3)`, in the third column and fourth row.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Add an Image Inside a Table Cell**

Place the input image in the working directory before running this example. It loads the image with [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) and adds it to the presentation's image collection with [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). It then assigns the image to the picture fill of cell `(0, 0)`, the first cell in the table.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) stretches the image to fill the cell, which may change its aspect ratio. Column widths and row heights are in points. The loaded image is disposed automatically when its `with` block ends.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I set different line thicknesses and styles for different sides of a single cell?**

Yes. The [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) borders have separate properties, so the thickness and style of each side can differ.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

The behavior depends on the [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). With stretching, the image adjusts to the new cell; with tiling, the tiles are recalculated.

**Can I assign a hyperlink to all the content of a cell?**

[Hyperlinks](/slides/python-net/manage-hyperlinks/) are set at the text (portion) level inside the cell’s text frame or at the level of the entire table/shape. In practice, you assign the link to a portion or to all the text in the cell.

**Can I set different fonts within a single cell?**

Yes. A cell’s text frame supports [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) with independent formatting—font family, style, size, and color.
