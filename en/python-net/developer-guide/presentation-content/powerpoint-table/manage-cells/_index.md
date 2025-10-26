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
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Effortlessly manage table cells in PowerPoint and OpenDocument with Aspose.Slides for Python via .NET. Master accessing, modifying, and styling cells quickly for seamless slide automation."
---

## **Overview**

This article shows how to work with table cells in presentations using Aspose.Slides. You’ll learn how to detect merged cells, clear or customize cell borders, and understand how PowerPoint numbers cells after merge and split operations so you can predict indexing in complex layouts. The article also demonstrates common formatting tasks—such as changing a cell’s background fill—and shows how to place an image directly inside a table cell with picture fill settings. Each scenario is accompanied by concise Python examples that create or edit tables and then save the updated presentation, so you can adapt the snippets to your own slides quickly.

## **Identify Merged Table Cells**

Tables often contain merged cells for headers or to group related data. In this section, you’ll see how to determine whether a specific cell belongs to a merged region and how to reference the master (top-left) cell so you can read or format the whole block consistently.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get the table from the first slide.
1. Iterate through the table’s rows and columns to find merged cells.
1. Print a message when merged cells are found.

The following Python code identifies merged table cells in a presentation:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Assuming the first shape on the first slide is a table.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Remove Table Cell Borders**

Sometimes table borders distract from the content or create visual clutter. This section shows how to remove borders from selected cells—or specific sides of a cell—so you can achieve a cleaner layout and better align with your slide’s design.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get the slide by its index.
1. Define an array of column widths.
1. Define an array of row heights.
1. Add a table to the slide using the [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) method.
1. Iterate through each cell to clear the top, bottom, left, and right borders.
1. Save the modified presentation as a PPTX file.

The following Python code shows how to remove borders from table cells:

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define columns with widths and rows with heights.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Clear the border fill for each cell.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Save the PPTX file to disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numbering in Merged Cells**

If you merge two pairs of cells—for example, (1, 1) x (2, 1) and (1, 2) x (2, 2)—the resulting table will keep the same cell numbering as the table without merging. The following Python code demonstrates this behavior:

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define columns with widths and rows with heights.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Merge cells (1,1) and (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Merge cells (1, 2) and (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Print the cell indices.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Save the PPTX file to disk.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Output:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Numbering in Split Cells**

In previous example, when table cells were merged, the numbering in the other cells did not change. This time, we create a regular table (with no merged cells) and then split cell (1, 1) to produce a special table. Pay attention to this table’s numbering—it may look unusual. However, this is how Microsoft PowerPoint numbers table cells, and Aspose.Slides follows the same behavior.

The following Python code demonstrates this behavior:

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Split cell (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Print the cell indices.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Save the PPTX file to disk.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Output:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Change Table Cell Background Color**

The following Python example demonstrates how to change a table cell’s background color:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Create a new table.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Set the background color for a cell.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Insert Images into Table Cells**

This section shows how to insert an image into a table cell in Aspose.Slides. It covers applying a picture fill to the target cell and configuring display options such as stretch or tile.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a slide reference by its index.
1. Define an array of column widths.
1. Define an array of row heights.
1. Add a table to the slide with the [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) method.
1. Load the image from a file.
1. Add the image to the presentation’s images to obtain a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).
1. Set the table cell’s [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) to `PICTURE`.
1. Apply the image to the table cell and choose a fill mode (e.g., `STRETCH`).
1. Save the presentation as a PPTX file.

The following Python code shows how to place an image inside a table cell when creating a table:

```python
import aspose.slides as slides

# Instantiate a Presentation object.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Load the image and add it to the presentation to obtain a PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Apply the image to the first table cell.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Save the presentation to disk.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I set different line thicknesses and styles for different sides of a single cell?**

Yes. The [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) borders have separate properties, so the thickness and style of each side can differ. This logically follows from the per-side border control for a cell demonstrated in the article.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

The behavior depends on the [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). With stretching, the image adjusts to the new cell; with tiling, the tiles are recalculated. The article mentions the image display modes in a cell.

**Can I assign a hyperlink to all the content of a cell?**

[Hyperlinks](/slides/python-net/manage-hyperlinks/) are set at the text (portion) level inside the cell’s text frame or at the level of the entire table/shape. In practice, you assign the link to a portion or to all the text in the cell.

**Can I set different fonts within a single cell?**

Yes. A cell’s text frame supports [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) with independent formatting—font family, style, size, and color.
