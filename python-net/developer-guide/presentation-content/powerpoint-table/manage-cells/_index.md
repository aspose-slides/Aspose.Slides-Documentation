---
title: Manage Cells
type: docs
weight: 30
url: /python-net/manage-cells/
keywords: "Table, merged cells, split cells, image in table cell, Python, Aspose.Slides for Python via .NET"
description: "Table cells in PowerPoint presentations in Python"
---

## **Identify Merged Table Cell**
1. Create an instance of the [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
2. Get the table from the first slide. 
3. Iterate through the table's rows and columns to find merge cells.
4. Print message when merged cells are found.

This Python code shows you how to identify merged table cells in a presentation:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "SomePresentationWithTable.pptx") as pres:
    table = pres.slides[0].shapes[0] # assuming that #0.Shape#0 is a table
    for i in range(len(table.rows)):
        for j in range(len(table.columns)):
            currentCell = table.rows[i][j]
            if currentCell.is_merged_cell:
                print("Cell 01 is a part of merged cell with RowSpan=2 and ColSpan=3 starting from Cell 45.".format(
                    i, j, currentCell.row_span, currentCell.col_span, currentCell.first_row_index, currentCell.first_column_index))
```

## **Remove Table Cells Border**
1. Create an instance of the `Presentation` class.
2. Get a slide's reference through its index. 
3. Define an array of columns with width.
4. Define an array of rows with height.
5. Add a table to the slide through the `AddTable` method.
6. Iterate through every cell to clear the top, bottom, right, and left borders.
7. Save the modified presentation as a PPTX file.

This Python code shows you how to remove the borders from table cells:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiates the Presentation class that represents a PPTX file
with slides.Presentation() as pres:
   # Accesses the first slide
    sld = pres.slides[0]

    # Defines columns with widths and rows with heights
    dblCols = [ 50, 50, 50, 50 ]
    dblRows = [ 50, 30, 30, 30, 30 ]

    # Adds a table shape to the slide
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Sets border format for each cell
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    #Writes the PPTX file to Disk
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Numbering in Merged Cells**
If we merge 2 pairs of cells (1, 1) x (2, 1) and (1, 2) x (2, 2), the resulting table will be numbered. This Python code demonstrates the process:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiates the Presentation class that represents a PPTX file
with slides.Presentation() as presentation:
    # Accesses the first slide
    sld = presentation.slides[0]

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

    # Merges cells (1, 1) x (2, 1)
    tbl.merge_cells(tbl.rows[1][1], tbl.rows[2][1], False)

    # Merges cells (1, 2) x (2, 2)
    tbl.merge_cells(tbl.rows[1][2], tbl.rows[2][2], False)

    presentation.save("MergeCells_out.pptx", slides.export.SaveFormat.PPTX)
```

We then merge the cells further by merging (1, 1) and (1, 2). The result is a table containing a large merged cell in its center: 

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiates the Presentation class that represents a PPTX file
with slides.Presentation() as presentation:
    # Accesses the first slide
    slide = presentation.slides[0]

    # Defines columns with widths and rows with heights
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70]

    # Adds a table shape to slide
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # Sets the border format for each cell
    for row in table.rows:
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

    # Merges cells (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Merges cells (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Merges cells (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][1], table.rows[1][2], True)

    #Writes the PPTX file to disk
    presentation.save("MergeCells1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Numbering in Splitted Cell**
In previous examples, when table cells got merged, the numeration or number system in other cells did not change. 

This time, we take a regular table (a table without merged cells) and then try to split cell (1,1) to get a special table. You may want to pay attention to this table's numbering, which may be considered strange. However, that is the way Microsoft PowerPoint numerates table cells and Aspose.Slides does the same thing. 

This Python code demonstrates the process we described:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiates the Presentation class that represents a PPTX file
with slides.Presentation() as presentation:
    # Accesses first slide
    slide = presentation.slides[0]

    # Defines columns with widths and rows with heights
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Adds a table shape to the slide
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # Sets the border format for each cell
    for row in table.rows:
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

    # Merges cells (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Merges cells (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Splits cell (1, 1). 
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    #Writes the PPTX file to disk
    presentation.save("CellSplit_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Change Table Cell Background Color**

This Python code shows you how to change a table cell's background color:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    dblCols = [ 150, 150, 150, 150 ]
    dblRows = [ 50, 50, 50, 50, 50 ]

    # create a new table
    table = slide.shapes.add_table(50, 50, dblCols, dblRows)

    # set the background color for a cell 
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Add Image Inside Table Cell**
1. Create an instance of the`Presentation` class.
2. Get a slide's reference through its index.
3. Define an array of columns with width.
4. Define an array of rows with height.
5. Add a table to the slide through the `AddTable` method. 
6. Create a `Bitmap` object to hold the image file.
7. Add the bitmap image to the `IPPImage` object.
8. Set the `FillFormat` for the Table Cell to `Picture`.
9. Add the image to the table's first cell.
10. Save the modified presentation as a PPTX file

This Python code shows you how to place an image inside a table cell when creating a table:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiates a Presentation class object
with slides.Presentation() as presentation:
    # Accesses the first slide
    islide = presentation.slides[0]

    # Defines columns with widths and rows with heights
    dblCols =  [150, 150, 150, 150] 
    dblRows =  [100, 100, 100, 100, 90] 

    # Adds a table shape to the slide
    tbl = islide.shapes.add_table(50, 50, dblCols, dblRows)

    # Creates a Bitmap Image object to hold the image file
    image = draw.Bitmap(path + "aspose-logo.jpg")

    # Creates an IPPImage object using the bitmap object
    imgx1 = presentation.images.add_image(image)

    # Adds the image to the first table cell
    tbl.rows[0][0].cell_format.fill_format.fill_type = slides.FillType.PICTURE
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture.image = imgx1

    # Saves the PPTX to disk
    presentation.save("Image_In_TableCell_out.pptx", slides.export.SaveFormat.PPTX)
```

